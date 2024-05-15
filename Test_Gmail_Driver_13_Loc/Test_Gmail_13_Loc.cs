using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Gmail_Driver_13_Loc
{
    public partial class Form_13_loc : Form
    {
        private Selenium_13_Loc selenium_13_Loc;
        public Form_13_loc()
        {
            InitializeComponent();
        }

        private void Form_13_loc_Load(object sender, EventArgs e)
        {
            selenium_13_Loc = new Selenium_13_Loc();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string email_13_loc = textBoxEmail.Text;
            string pass_13_loc = textBoxPassword.Text;

            string result = this.selenium_13_Loc.login_13_loc(email_13_loc, pass_13_loc);
            MessageBox.Show(result);
            if(result != "Logged in successfully")
                selenium_13_Loc.goToBaseUrl();
        }

        private void buttonSendEmail_Click(object sender, EventArgs e)
        {
            string receipients_13_loc = textBoxReceiver.Text;
            string subject_13_loc = textBoxSubject.Text;
            string content_13_loc = richTextBoxContent.Text;

            string result = this.selenium_13_Loc.sendEmail_13_loc(receipients_13_loc, subject_13_loc, content_13_loc);
            MessageBox.Show(result);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (this.selenium_13_Loc.search_13_loc(textBoxKeywords.Text))
            {
                MessageBox.Show("Tìm hoàn tất");
            } else
            {
                MessageBox.Show("Không tìm thấy");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.selenium_13_Loc.deleteMail_13_loc(textBoxKeywords.Text))
            {
                MessageBox.Show("Xóa hoàn tất");
            }
            else
            {
                MessageBox.Show("Không tìm thấy để xóa");
            }
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            if (this.selenium_13_Loc.signOut_13_loc())
            {
                MessageBox.Show("Đăng xuất thành công");
            } else
            {
                MessageBox.Show("Đăng xuất thất bại");
            }
        }

        private void Form_13_loc_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.selenium_13_Loc.close();
        }
    }
}
