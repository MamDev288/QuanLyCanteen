using CanteenManagement.FormsControl;
using CanteenManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenManagement
{
    public partial class frmlogin : Form
    {
        CanteenManagementEntities db = new CanteenManagementEntities();
        public frmlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.tk = db.taikhoans.FirstOrDefault(u=> u.taikhoan1 == textBox1.Text && u.matkhau == textBox2.Text);
            if (Program.tk != null)
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Menufrm f = new Menufrm();
                f.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại, tài khoản và mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }
    }
}
