namespace WindowsFormsApp_SP365
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
            this.lWeb = new System.Windows.Forms.Label();
            this.tbSiteURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btLoadSite = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.lbLists = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbViews = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lWeb
            // 
            this.lWeb.AutoSize = true;
            this.lWeb.Location = new System.Drawing.Point(280, 58);
            this.lWeb.Name = "lWeb";
            this.lWeb.Size = new System.Drawing.Size(63, 13);
            this.lWeb.TabIndex = 1;
            this.lWeb.Text = "Not opened";
            // 
            // tbSiteURL
            // 
            this.tbSiteURL.Location = new System.Drawing.Point(69, 27);
            this.tbSiteURL.Name = "tbSiteURL";
            this.tbSiteURL.Size = new System.Drawing.Size(201, 20);
            this.tbSiteURL.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Site URL";
            // 
            // btLoadSite
            // 
            this.btLoadSite.Location = new System.Drawing.Point(276, 25);
            this.btLoadSite.Name = "btLoadSite";
            this.btLoadSite.Size = new System.Drawing.Size(70, 23);
            this.btLoadSite.TabIndex = 4;
            this.btLoadSite.Text = "Load";
            this.btLoadSite.UseVisualStyleBackColor = true;
            this.btLoadSite.Click += new System.EventHandler(this.btLoadSite_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Login";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(69, 53);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(201, 20);
            this.tbLogin.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "pwd";
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(69, 79);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(201, 20);
            this.tbPwd.TabIndex = 7;
            // 
            // lbLists
            // 
            this.lbLists.FormattingEnabled = true;
            this.lbLists.Location = new System.Drawing.Point(16, 132);
            this.lbLists.Name = "lbLists";
            this.lbLists.Size = new System.Drawing.Size(154, 186);
            this.lbLists.TabIndex = 9;
            this.lbLists.DoubleClick += new System.EventHandler(this.lbLists_DoubleClick);
            this.lbLists.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbLists_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lists";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Views";
            // 
            // lbViews
            // 
            this.lbViews.FormattingEnabled = true;
            this.lbViews.Location = new System.Drawing.Point(192, 132);
            this.lbViews.Name = "lbViews";
            this.lbViews.Size = new System.Drawing.Size(154, 186);
            this.lbViews.TabIndex = 11;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 329);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(330, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 364);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbViews);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbLists);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.btLoadSite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSiteURL);
            this.Controls.Add(this.lWeb);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O365 SharePoint List Items Updator from Excel Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lWeb;
        private System.Windows.Forms.TextBox tbSiteURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btLoadSite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.ListBox lbLists;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbViews;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

