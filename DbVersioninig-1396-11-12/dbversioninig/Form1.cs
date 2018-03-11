using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using dbversioninig;

namespace DbVersioninig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int maxFile;
        private int maxDatabaseVersion;
        private string reultString = "Done";

        private void Form1_Load(object sender, EventArgs e)
        {
            groupConnection.Enabled = false;
            groupUpdate.Enabled = false;
            labelPath.BackColor = SystemColors.Highlight;
            labelConnection.BackColor = Color.DarkGray;
            labelUpdate.BackColor = Color.DarkGray;
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog =
                new FolderBrowserDialog { ShowNewFolderButton = true };
            var dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                textPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void TxtBrowsePath_TextChanged(object sender, EventArgs e)
        {
            if (textPath.Text == "")
            {
                Form1_Load(null, null);
            }
            else
            {
                labelPath.BackColor = Color.DarkCyan;
                labelConnection.BackColor = SystemColors.Highlight;
                groupConnection.Enabled = true;
            }
        }

        private void BtutonConnect_Click(object sender, EventArgs e)
        {
            var databaseExists = CheckDatabaseExists("LPR");
            if (databaseExists == false)
            {
                var result = FarsiMessageBox.MessageBox.Show("ایجاد دیتابیس", "دیتابیس شما ایجاد نشده است، آیا تمایل به ایجاد دیتابیس دارید؟", FarsiMessageBox.MessageBox.Buttons.YesNo, FarsiMessageBox.MessageBox.Icons.Question);
                if (result == DialogResult.Yes)
                {
                    var existDatabase = CreateDatabase();
                    if (existDatabase == true)
                    {
                        var sqlConnection = new SqlConnection(textConnectionString.Text);

                        try
                        {
                            sqlConnection.Open();
                            labelConnectionMood.Text = Messages.connectSuccessfull;
                        }

                        //Show exception message when database is not connected
                        catch (Exception)
                        {
                            labelConnectionMood.ForeColor = Color.Red;
                            labelConnectionMood.Text = Messages.connectUnSuccessfull;
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                var sqlConnection = new SqlConnection(textConnectionString.Text);

                try
                {
                    sqlConnection.Open();
                    labelConnectionMood.Text = Messages.connectSuccessfull;
                }

                //Show exception message when database is not connected
                catch (Exception)
                {
                    labelConnectionMood.ForeColor = Color.Red;
                    labelConnectionMood.Text = Messages.connectUnSuccessfull;
                    return;
                }
                var dateCheck =
                    new SqlCommand(
                        "IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES" +
                        " WHERE TABLE_NAME = 'DBVersion') SELECT 1 ELSE SELECT 0",
                        sqlConnection);
                var x = (Int32)dateCheck.ExecuteScalar();
                if (x == 0)
                {
                    var text = "CREATE TABLE [dbo].[DBVersion](" +
                               "[ID][int] IDENTITY(1, 1) NOT NULL," +
                               "[QueryScript] [text] NULL," +
                               "[version] [int] NULL," +
                               "[date] [datetime] NULL," +
                               "[status] [text] NULL," +
                               "[isSuccessfull] [bit] NULL" +
                               ") ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]" +

                               "ALTER TABLE[dbo].[DBVersion] ADD CONSTRAINT[DF_DBVersion_isSuccessfull]  DEFAULT((0)) FOR[isSuccessfull]";
                    var sqlCommand = new SqlCommand(text,
                            sqlConnection)
                    { Connection = sqlConnection };
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        reultString = exception.ToString();
                        textMessageUpdate.ForeColor = Color.Red;
                        textMessageUpdate.RightToLeft = 0;
                        textMessageUpdate.Font = new Font(FontFamily.GenericSerif,
                            0x7,
                            FontStyle.Italic);
                        textMessageUpdate.Text = reultString;
                        sqlConnection.Close();
                    }
                }
                sqlConnection.Close();
            }
            CheckUpdate(null, null);
        }

        private bool CreateDatabase()
        {
            bool createDatabase;
            var path = textPath.Text + @"\CreateDatabase\CreateDatabase.sql";
            var sqlConnection =
                new SqlConnection(
                    connectionString: "server=(localhost);Trusted_Connection=yes");
            var fileName = new FileInfo(path);
            var script = fileName.OpenText().ReadToEnd();
            try
            {
                using (var command = new SqlCommand())
                {
                    var scripts = Regex.Split(script, "\r\nGO\r\n");
                    command.Connection = sqlConnection;
                    command.CommandTimeout = 800;

                    foreach (var splitScript in scripts)
                    {
                        sqlConnection.Open();
                        command.CommandText = splitScript;
                        command.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                createDatabase = true;
                return createDatabase;
            }

            catch (Exception exception)
            {
                sqlConnection.Close();
                return false;
            }
        }

        private static bool CheckDatabaseExists(string databaseName)
        {
            bool result;

            try
            {
                var sqlConnection = new SqlConnection(connectionString: "server=(local);Trusted_Connection=yes");

                var sqlCreateDbQuery = string.Format(format: "SELECT database_id FROM sys.databases WHERE Name  = '{0}'", arg0: databaseName);

                using (sqlConnection)
                {
                    using (var sqlCommand = new SqlCommand(cmdText: sqlCreateDbQuery, connection: sqlConnection))
                    {
                        sqlConnection.Open();

                        var resultObject = sqlCommand.ExecuteScalar();

                        int databaseId = 0;

                        if (resultObject != null)
                        {
                            int.TryParse(s: resultObject.ToString(), result: out databaseId);
                        }

                        sqlConnection.Close();

                        result = (databaseId > 0);
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
        private void CheckUpdate(object sender, EventArgs e)
        {
            var sqlConnection = new SqlConnection(textConnectionString.Text);
            sqlConnection.Open();
            var sqlCommand =
                new SqlCommand("select max(version) from DBVersion where isSuccessfull=1", sqlConnection);
            var objectResult = sqlCommand.ExecuteScalar();

            //Find max value of version in database
            if (objectResult != DBNull.Value && objectResult != null)
            {
                maxDatabaseVersion = (int)objectResult;
            }
            else
            {
                maxDatabaseVersion = 0;
            }

            var statusMessage = @"آخرین ورژن دیتابیس:" + maxDatabaseVersion + "\n";
            var directoryInfo = new DirectoryInfo(textPath.Text);
            FileInfo[] fileNameFiles = directoryInfo.GetFiles("*.sql");
            maxFile = 0;

            //Find max name of files in txtPath
            foreach (var fileName in fileNameFiles)
            {
                var nameNoExtension =
                    Convert.ToInt32(fileName.Name.Replace(".sql", ""));
                if (nameNoExtension > maxFile)
                {
                    maxFile = nameNoExtension;
                }
            }
            statusMessage = $"{statusMessage}آخرین ورژن فایل ها:{maxFile}";

            if (maxDatabaseVersion != maxFile)
            {
                labelStatusMood.ForeColor = Color.Red;
                labelConnection.BackColor = Color.DarkCyan;
                labelUpdate.BackColor = SystemColors.Highlight;
                labelStatusMood.Text = statusMessage;
                groupUpdate.Enabled = true;
            }
            else
            {
                labelStatusMood.ForeColor = Color.SeaGreen;
                labelStatusMood.Text = statusMessage;
                labelConnection.BackColor = Color.DarkCyan;
                labelUpdate.BackColor = Color.DarkCyan;
                groupUpdate.Enabled = false;
            }
            sqlConnection.Close();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            var sqlConnection = new SqlConnection(textConnectionString.Text);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return;
            }
            var sqlCommand = new SqlCommand(
                        "delete from DBVersion where isSuccessfull=0",
                        sqlConnection)
            {
                Connection = sqlConnection
            };

            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                reultString = exception.ToString();
                textMessageUpdate.ForeColor = Color.Red;
                textMessageUpdate.RightToLeft = 0;
                textMessageUpdate.Font = new Font(FontFamily.GenericSerif,
                    0x7,
                    FontStyle.Italic);
                textMessageUpdate.Text = reultString;
            }

            var directoryInfo = new DirectoryInfo(textPath.Text);
            FileInfo[] filesNameFiles = directoryInfo.GetFiles("*.sql");
            sqlConnection = new SqlConnection(textConnectionString.Text);
            var flag = 0;
            var failedScript = "";
            var failedVersion = 0;

            sqlConnection.Open();
            foreach (var fileName in filesNameFiles)
            {
                var nameNoExtension =
                    Convert.ToInt32(fileName.Name.Replace(".sql", ""));

                //Read script files and insert to database
                if (nameNoExtension != Convert.ToInt32(maxDatabaseVersion) && nameNoExtension > Convert.ToInt32(maxDatabaseVersion))
                {
                    string script = fileName.OpenText().ReadToEnd();
                    string commandText =
                        "insert into DBVersion(QueryScript,version,date,status,isSuccessfull) values(@val1,@val2,@val3,@val4,@val5)";

                    using (var command = new SqlCommand())
                    {
                        command.Connection = sqlConnection;
                        command.CommandText = script;
                        try
                        {
                            command.ExecuteNonQuery();
                            reultString = "Done";
                            command.CommandText = commandText;
                            command.Parameters.AddWithValue("@val1", script);
                            command.Parameters.AddWithValue("@val2",
                                nameNoExtension);
                            command.Parameters.AddWithValue("@val3", DateTime.Now);
                            command.Parameters.AddWithValue("@val4", reultString);
                            command.Parameters.AddWithValue("@val5", '1');
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            flag = 1;
                            failedScript = script;
                            failedVersion = nameNoExtension;
                            reultString = ex.ToString();
                            command.CommandText = commandText;
                            command.Parameters.AddWithValue("@val1", script);
                            command.Parameters.AddWithValue("@val2",
                                nameNoExtension);
                            command.Parameters.AddWithValue("@val3", DateTime.Now);
                            command.Parameters.AddWithValue("@val4", reultString);
                            command.Parameters.AddWithValue("@val5", '0');
                            command.ExecuteNonQuery();
                            sqlConnection.Close();
                            break;
                        }
                    }
                }
            }
            if (flag == 0)
            {
                textMessageUpdate.TextAlign = HorizontalAlignment.Center;
                textMessageUpdate.Text = Environment.NewLine + Messages.updateSuccessfull;
                CheckUpdate(null, null);
            }
            else
            {
                textMessageUpdate.ForeColor = Color.Red;
                textMessageUpdate.Font = new Font(FontFamily.GenericSerif, 8, FontStyle.Italic);
                textMessageUpdate.Text =
                    @"به علت اجرا نشدن اسکریپت زیر با شماره ورژن" + @"  " +
                    failedVersion + Environment.NewLine + failedScript +
                    Environment.NewLine + Messages.updateUnSuccessfull +
                    Environment.NewLine;
                textMessageUpdate.Text =
                    textMessageUpdate.Text + Environment.NewLine +
                    @"پیغام خطا:" + Environment.NewLine + reultString;
                CheckUpdate(null, null);
            }
        }

        private void textConnectionString_TextChanged(object sender, EventArgs e)
        {

        }
    }
}