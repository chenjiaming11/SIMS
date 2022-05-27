namespace WINUI
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblServe = new System.Windows.Forms.Label();
            this.lblKovi = new System.Windows.Forms.Label();
            this.rdoTeacher = new System.Windows.Forms.RadioButton();
            this.rdoStudent = new System.Windows.Forms.RadioButton();
            this.groupBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxLogin.Controls.Add(this.rdoTeacher);
            this.groupBoxLogin.Controls.Add(this.rdoStudent);
            this.groupBoxLogin.Controls.Add(this.txtPwd);
            this.groupBoxLogin.Controls.Add(this.txtUserName);
            this.groupBoxLogin.Controls.Add(this.lblPwd);
            this.groupBoxLogin.Controls.Add(this.lblUserName);
            this.groupBoxLogin.Controls.Add(this.btnCancel);
            this.groupBoxLogin.Controls.Add(this.btnOK);
            this.groupBoxLogin.ForeColor = System.Drawing.Color.White;
            this.groupBoxLogin.Location = new System.Drawing.Point(248, 18);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(282, 144);
            this.groupBoxLogin.TabIndex = 1;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "用户登录";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(99, 60);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(156, 21);
            this.txtPwd.TabIndex = 5;
            this.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(99, 32);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(156, 21);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(38, 63);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(53, 12);
            this.lblPwd.TabIndex = 3;
            this.lblPwd.Text = "密  码：";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(38, 35);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(53, 12);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "用户名：";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(180, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.DimGray;
            this.btnOK.Location = new System.Drawing.Point(99, 115);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblServe
            // 
            this.lblServe.AutoSize = true;
            this.lblServe.BackColor = System.Drawing.Color.Transparent;
            this.lblServe.Font = new System.Drawing.Font("华文琥珀", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblServe.ForeColor = System.Drawing.Color.Snow;
            this.lblServe.Location = new System.Drawing.Point(12, 118);
            this.lblServe.Name = "lblServe";
            this.lblServe.Size = new System.Drawing.Size(230, 25);
            this.lblServe.TabIndex = 4;
            this.lblServe.Text = "Management System";
            // 
            // lblKovi
            // 
            this.lblKovi.AutoSize = true;
            this.lblKovi.BackColor = System.Drawing.Color.Transparent;
            this.lblKovi.Font = new System.Drawing.Font("华文琥珀", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKovi.ForeColor = System.Drawing.Color.Snow;
            this.lblKovi.Location = new System.Drawing.Point(86, 72);
            this.lblKovi.Name = "lblKovi";
            this.lblKovi.Size = new System.Drawing.Size(139, 25);
            this.lblKovi.TabIndex = 3;
            this.lblKovi.Text = "Student Info";
            // 
            // rdoTeacher
            // 
            this.rdoTeacher.AutoSize = true;
            this.rdoTeacher.Checked = true;
            this.rdoTeacher.Location = new System.Drawing.Point(99, 93);
            this.rdoTeacher.Name = "rdoTeacher";
            this.rdoTeacher.Size = new System.Drawing.Size(71, 16);
            this.rdoTeacher.TabIndex = 5;
            this.rdoTeacher.TabStop = true;
            this.rdoTeacher.Text = "老师登录";
            this.rdoTeacher.UseVisualStyleBackColor = true;
            // 
            // rdoStudent
            // 
            this.rdoStudent.AutoSize = true;
            this.rdoStudent.Location = new System.Drawing.Point(184, 93);
            this.rdoStudent.Name = "rdoStudent";
            this.rdoStudent.Size = new System.Drawing.Size(71, 16);
            this.rdoStudent.TabIndex = 6;
            this.rdoStudent.Text = "学生登录";
            this.rdoStudent.UseVisualStyleBackColor = true;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WINUI.Properties.Resources.bg1;
            this.ClientSize = new System.Drawing.Size(549, 176);
            this.Controls.Add(this.lblServe);
            this.Controls.Add(this.lblKovi);
            this.Controls.Add(this.groupBoxLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblServe;
        private System.Windows.Forms.Label lblKovi;
        private System.Windows.Forms.RadioButton rdoTeacher;
        private System.Windows.Forms.RadioButton rdoStudent;
    }
}