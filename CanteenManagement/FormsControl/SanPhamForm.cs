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
    public partial class SanPhamForm : Form
    {
        public SanPhamForm()
        {
            InitializeComponent();
        }
        CanteenManagementEntities db = new CanteenManagementEntities();
        sanpham tk;
        int RowIndex = -1;
        private List<Object> renderGrid()
        {
            List<sanpham> render = db.sanphams.ToList();
            if (txtFilter.Text != "")
            {
                string key = txtFilter.Text;
                render = render.Where(u => u.tensanpham.Contains(key) || u.loaisanpham.tenloaisanpham.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new {
                id = u.id,
                TenSanPham = u.tensanpham,
                LoaiSanPham = u.loaisanpham.tenloaisanpham,
                GiaTien = u.giatien
            }).ToList<Object>();
            return list;
        }
        private void SanPhamForm_Load(object sender, EventArgs e)
        {
            DataShowServices.initDataGridView(dgvData, renderGrid());
            DataShowServices.initCombobox(comboBox1, db.loaisanphams.Select(u => new { id = u.id, name = u.tenloaisanpham }).ToList());
            groupBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tk != null)
            {
                if (tk.id == 0)
                    db.sp_addsanpham(txtName.Text,(int)comboBox1.SelectedValue,float.Parse(txtPrice.Text));
                else if (tk.id > 1)
                {
                    db.sp_editsanpham(txtName.Text, (int)comboBox1.SelectedValue, float.Parse(txtPrice.Text), tk.id);
                    db = new CanteenManagementEntities();
                }
                DataShowServices.initDataGridView(dgvData, renderGrid());
            }
            txtPrice.ResetText();
            txtName.ResetText();
            groupBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tk = new sanpham();
            groupBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(RowIndex.ToString());
            if (RowIndex >= 0)
            {
                int Id = (int)dgvData.Rows[RowIndex].Cells[0].Value;
                tk = db.sanphams.FirstOrDefault(u => u.id == Id);
                if (tk != null)
                {
                    txtName.Text = tk.tensanpham;
                    txtPrice.Text = tk.giatien.ToString();
                    comboBox1.SelectedValue = tk.loaisanphamid;
                    groupBox1.Enabled = true;
                }
                else
                    MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (RowIndex >= 0)
            {
                int Id = (int)dgvData.Rows[RowIndex].Cells[0].Value;
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    db.sp_detelesanpham(Id);
                DataShowServices.initDataGridView(dgvData, renderGrid());
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            DataShowServices.initDataGridView(dgvData, renderGrid());
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;
        }
    }
}
