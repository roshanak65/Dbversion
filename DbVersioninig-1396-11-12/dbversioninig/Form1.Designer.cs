using System;

namespace DbVersioninig
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpdate = new System.Windows.Forms.Button();
            this.labelUpdate = new System.Windows.Forms.Label();
            this.labelConnection = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.labelConnectionMood = new System.Windows.Forms.Label();
            this.lblconnection = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupConnection = new System.Windows.Forms.GroupBox();
            this.labelStatusMood = new System.Windows.Forms.Label();
            this.textConnectionString = new System.Windows.Forms.TextBox();
            this.textPath = new System.Windows.Forms.TextBox();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.groupPath = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupUpdate = new System.Windows.Forms.GroupBox();
            this.textMessageUpdate = new System.Windows.Forms.TextBox();
            this.groupConnection.SuspendLayout();
            this.groupPath.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdate.Location = new System.Drawing.Point(464, 70);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 53);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "بروزرسانی اسکریپت دیتابیس";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // labelUpdate
            // 
            this.labelUpdate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelUpdate.Location = new System.Drawing.Point(3, 241);
            this.labelUpdate.Name = "labelUpdate";
            this.labelUpdate.Size = new System.Drawing.Size(101, 193);
            this.labelUpdate.TabIndex = 2;
            this.labelUpdate.Text = "مرحله 3";
            // 
            // labelConnection
            // 
            this.labelConnection.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelConnection.Location = new System.Drawing.Point(3, 60);
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(101, 174);
            this.labelConnection.TabIndex = 1;
            this.labelConnection.Text = "مرحله 2";
            // 
            // labelPath
            // 
            this.labelPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPath.BackColor = System.Drawing.Color.DarkCyan;
            this.labelPath.Location = new System.Drawing.Point(3, 4);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(101, 49);
            this.labelPath.TabIndex = 0;
            this.labelPath.Text = "مرحله 1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStatus.Location = new System.Drawing.Point(375, 116);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(82, 36);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "وضعیت";
            // 
            // labelConnectionMood
            // 
            this.labelConnectionMood.AutoSize = true;
            this.labelConnectionMood.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelConnectionMood.ForeColor = System.Drawing.Color.SeaGreen;
            this.labelConnectionMood.Location = new System.Drawing.Point(155, 100);
            this.labelConnectionMood.Name = "labelConnectionMood";
            this.labelConnectionMood.Size = new System.Drawing.Size(0, 39);
            this.labelConnectionMood.TabIndex = 4;
            // 
            // lblconnection
            // 
            this.lblconnection.AutoSize = true;
            this.lblconnection.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblconnection.Location = new System.Drawing.Point(464, 35);
            this.lblconnection.Name = "lblconnection";
            this.lblconnection.Size = new System.Drawing.Size(169, 36);
            this.lblconnection.TabIndex = 0;
            this.lblconnection.Text = "کانکشن استرینگ";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnConnect.Location = new System.Drawing.Point(464, 112);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(105, 26);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "اتصال به دیتابیس";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtutonConnect_Click);
            // 
            // groupConnection
            // 
            this.groupConnection.Controls.Add(this.labelStatusMood);
            this.groupConnection.Controls.Add(this.textConnectionString);
            this.groupConnection.Controls.Add(this.btnConnect);
            this.groupConnection.Controls.Add(this.lblStatus);
            this.groupConnection.Controls.Add(this.lblconnection);
            this.groupConnection.Controls.Add(this.labelConnectionMood);
            this.groupConnection.Location = new System.Drawing.Point(38, 72);
            this.groupConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupConnection.Name = "groupConnection";
            this.groupConnection.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupConnection.Size = new System.Drawing.Size(575, 174);
            this.groupConnection.TabIndex = 2;
            this.groupConnection.TabStop = false;
            this.groupConnection.Text = "اتصال";
            // 
            // labelStatusMood
            // 
            this.labelStatusMood.AutoSize = true;
            this.labelStatusMood.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.labelStatusMood.Location = new System.Drawing.Point(196, 120);
            this.labelStatusMood.Name = "labelStatusMood";
            this.labelStatusMood.Size = new System.Drawing.Size(0, 39);
            this.labelStatusMood.TabIndex = 5;
            // 
            // textConnectionString
            // 
            this.textConnectionString.Location = new System.Drawing.Point(6, 16);
            this.textConnectionString.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textConnectionString.Multiline = true;
            this.textConnectionString.Name = "textConnectionString";
            this.textConnectionString.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textConnectionString.Size = new System.Drawing.Size(452, 58);
            this.textConnectionString.TabIndex = 1;
            this.textConnectionString.Text = "Data Source=localhost;Initial Catalog=LPR;Integrated Security=True";
            this.textConnectionString.TextChanged += new System.EventHandler(this.textConnectionString_TextChanged);
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(6, 18);
            this.textPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textPath.Name = "textPath";
            this.textPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textPath.Size = new System.Drawing.Size(452, 44);
            this.textPath.TabIndex = 2;
            this.textPath.TextChanged += new System.EventHandler(this.TxtBrowsePath_TextChanged);
            // 
            // btnbrowse
            // 
            this.btnbrowse.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnbrowse.Location = new System.Drawing.Point(464, 17);
            this.btnbrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(105, 26);
            this.btnbrowse.TabIndex = 0;
            this.btnbrowse.Text = "انتخاب مسیر";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // groupPath
            // 
            this.groupPath.Controls.Add(this.textPath);
            this.groupPath.Controls.Add(this.btnbrowse);
            this.groupPath.Location = new System.Drawing.Point(38, 12);
            this.groupPath.Name = "groupPath";
            this.groupPath.Size = new System.Drawing.Size(575, 53);
            this.groupPath.TabIndex = 1;
            this.groupPath.TabStop = false;
            this.groupPath.Text = "مسیر فایل";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.labelUpdate);
            this.panel1.Controls.Add(this.labelPath);
            this.panel1.Controls.Add(this.labelConnection);
            this.panel1.Location = new System.Drawing.Point(630, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 437);
            this.panel1.TabIndex = 4;
            // 
            // groupUpdate
            // 
            this.groupUpdate.Controls.Add(this.textMessageUpdate);
            this.groupUpdate.Controls.Add(this.btnUpdate);
            this.groupUpdate.Location = new System.Drawing.Point(38, 253);
            this.groupUpdate.Name = "groupUpdate";
            this.groupUpdate.Size = new System.Drawing.Size(575, 196);
            this.groupUpdate.TabIndex = 3;
            this.groupUpdate.TabStop = false;
            this.groupUpdate.Text = "بروزرسانی";
            // 
            // textMessageUpdate
            // 
            this.textMessageUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.textMessageUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textMessageUpdate.ForeColor = System.Drawing.Color.DarkCyan;
            this.textMessageUpdate.Location = new System.Drawing.Point(6, 15);
            this.textMessageUpdate.Multiline = true;
            this.textMessageUpdate.Name = "textMessageUpdate";
            this.textMessageUpdate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textMessageUpdate.Size = new System.Drawing.Size(452, 175);
            this.textMessageUpdate.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 461);
            this.Controls.Add(this.groupUpdate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupPath);
            this.Controls.Add(this.groupConnection);
            this.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بروزرسانی اسکریپت دیتابیس";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupConnection.ResumeLayout(false);
            this.groupConnection.PerformLayout();
            this.groupPath.ResumeLayout(false);
            this.groupPath.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupUpdate.ResumeLayout(false);
            this.groupUpdate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label labelUpdate;
        private System.Windows.Forms.Label labelConnection;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label labelConnectionMood;
        private System.Windows.Forms.Label lblconnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupConnection;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.TextBox textConnectionString;
        private System.Windows.Forms.GroupBox groupPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupUpdate;
        private System.Windows.Forms.Label labelStatusMood;
        private System.Windows.Forms.TextBox textMessageUpdate;
    }
}

