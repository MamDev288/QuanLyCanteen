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

namespace CanteenManagement.FormsControl
{
    public partial class Menufrm : Form
    {
        public Menufrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaiKhoanForm f = new TaiKhoanForm();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoaiSanPhamForm f = new LoaiSanPhamForm();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SanPhamForm s = new SanPhamForm();
            s.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DonHangForm s = new DonHangForm();
            s.ShowDialog();
        }
    }
}
