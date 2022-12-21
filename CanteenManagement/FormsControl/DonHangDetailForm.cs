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
        public float totalCount = 0;
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
            if(dh.id > 0)
            {
                txtKhachHang.Text = dh.tenkhachhang;
                txtDisscount.Text = dh.giamgia.ToString();
                foreach(chitietdonhang i in dh.chitietdonhangs)
                {
                    totalCount += i.thanhtien;
                    dataGridView1.Rows.Add(new object[] { i.sanphamid, i.sanpham.tensanpham, i.soluong, i.thanhtien });
                }
                lbtotal.Text = (totalCount - float.Parse(txtDisscount.Text)).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dh.id == 0)
            {
                dh.id = Convert.ToInt32(db.sp_adddonhang(txtKhachHang.Text, float.Parse(txtDisscount.Text), Program.tk.id).First());
            }
            else if (dh.id > 0)
            {
                db.sp_editdonhang(txtKhachHang.Text, float.Parse(txtDisscount.Text),dh.id);
            }
            db.chitietdonhangs.RemoveRange(db.chitietdonhangs.Where(u=>u.donhangid ==dh.id));
            db.SaveChanges();
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                db.sp_addchitietdonhang(int.Parse(r.Cells[0].Value.ToString()), float.Parse(r.Cells[2].Value.ToString()),dh.id);
            }
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sanpham = db.sanphams.FirstOrDefault(u => u.id == (int)comboBox1.SelectedValue);
            if (sanpham != null)
            {
                bool isLoop = false;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (int.Parse(r.Cells[0].Value.ToString()) == sanpham.id)
                    {
                        int soluongOld = int.Parse(r.Cells[2].Value.ToString());
                        r.Cells["amoutsp"].Value = soluongOld + float.Parse(textBox2.Text);
                        r.Cells["total"].Value = (soluongOld + float.Parse(textBox2.Text)) * sanpham.giatien;
                        isLoop = true;
                        break;
                    }
                }
                if (!isLoop)
                {
                    dataGridView1.Rows.Add(new object[] { comboBox1.SelectedValue, comboBox1.Text, textBox2.Text, float.Parse(textBox2.Text) * sanpham.giatien });
                }
            }
            totalCount += float.Parse(textBox2.Text) * sanpham.giatien;
            lbtotal.Text = (totalCount - float.Parse(txtDisscount.Text)).ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "delete")
            {
                DataGridViewRow r =  dataGridView1.Rows[e.RowIndex];
                totalCount -= float.Parse(r.Cells[3].Value.ToString());
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                lbtotal.Text = (totalCount - float.Parse(txtDisscount.Text)).ToString();
            }
        }

        private void txtDisscount_TextChanged(object sender, EventArgs e)
        {
            lbtotal.Text = (totalCount - float.Parse(txtDisscount.Text)).ToString();
        }
    }
}
