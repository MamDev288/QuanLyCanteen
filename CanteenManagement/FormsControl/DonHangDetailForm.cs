using CanteenManagement.Models;
using CanteenManagement.Services;
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
    public partial class DonHangDetailForm : Form
    {
        public donhang dh;
        public DonHangDetailForm(donhang dh = null)
        {
            InitializeComponent();
            if (dh != null)
                this.dh = dh;
            else
                this.dh = new donhang();
        }
        CanteenManagementEntities db = new CanteenManagementEntities();
        private void DonHangDetailForm_Load(object sender, EventArgs e)
        {
            DataShowServices.initCombobox(comboBox1, db.sanphams.Select(u => new { id = u.id, name = u.tensanpham }).ToList());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dh.id == 0)
            {
                dh.id = Convert.ToInt32(db.sp_adddonhang(txtKhachHang.Text, float.Parse(txtDisscount.Text), Program.tk.id).First());
                this.Close();
            }
            else if (dh.id > 0)
            {
                db.sp_editdonhang(txtKhachHang.Text, float.Parse(txtDisscount.Text),dh.id);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(new object[] { comboBox1.SelectedValue, comboBox1.Text, textBox2.Text });
        }
    }
}
