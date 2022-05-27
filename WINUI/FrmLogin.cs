using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAL;
using Common;

namespace WINUI
{
    public partial class FrmLogin : Form
    {
        private BaseUserService objBaseUserService = new BaseUserService();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //非空验证
            if (this.txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入用户名！", "用户登录");
                this.txtUserName.Focus();
                return;
            }
            if (this.txtPwd.Text.Length == 0)
            {
                MessageBox.Show("请输入密码！", "用户登录");
                this.txtUserName.Focus();
                return;
            }
            if (rdoTeacher.Checked)
            {
                //封装管理员（老师）对象
                BaseUser baseUser = new BaseUser()
                {
                    BaseUserName = this.txtUserName.Text.Trim(),
                    BaseUserPwd = new Encryptions().GetMd5x2(this.txtPwd.Text)
                };
                //提交验证
                try
                {
                    Program.__currentBaseUser = objBaseUserService.UserLogin(baseUser);
                    if (Program.__currentBaseUser == null)
                    {
                        MessageBox.Show("您输入的用户名或密码错误，请检查后重新输入！", "用户登录");
                        return;
                    }
                    if (Program.__currentBaseUser.BaseUserStatus == 0)
                    {
                        MessageBox.Show("您的账户已被冻结，请联系管理员！", "用户登录");
                        return;
                    }
                    if (Program.__currentBaseUser.BaseUserStatus == 2)
                    {
                        MessageBox.Show("您已不再被授权使用本系统！", "用户登录");
                        return;
                    }
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //此处为学生登录的代码
            }
            
            
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
