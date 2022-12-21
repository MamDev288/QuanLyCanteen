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
    public partial class LoaiSanPhamForm : Form
    {
        public LoaiSanPhamForm()
        {
            InitializeComponent();
        }
        CanteenManagementEntities db = new CanteenManagementEntities();
        loaisanpham tk;
        int RowIndex = -1;
        private List<Object> renderGrid()
        {        
            List<loaisanpham> render = db.loaisanphams.ToList();
            if (txtFilter.Text != "")
            {
                string key = txtFilter.Text;
                render = render.Where(u => u.tenloaisanpham.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new {
                id = u.id,
                TenLoaiSanPham = u.tenloaisanpham,
            }).ToList<Object>();
            return list;
        }
        private void LoaiSanPhamForm_Load(object sender, EventArgs e)
        {
            DataShowServices.initDataGridView(dgvData, renderGrid());
            groupBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tk = new loaisanpham();
            groupBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RowIndex >= 0)
            {
                int Id = (int)dgvData.Rows[RowIndex].Cells[0].Value;
                tk = db.loaisanphams.FirstOrDefault(u => u.id == Id);
                if (tk != null)
                {
                    txtName.Text = tk.tenloaisanpham;              
                    groupBox1.Enabled = true;
                }
                else
                    MessageBox.Show("Không tìm thấy loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (RowIndex >= 0)
            {
                int Id = (int)dgvData.Rows[RowIndex].Cells[0].Value;
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    db.sp_deteleloaisanpham(Id);
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (tk != null)
            {
                if (tk.id == 0)
                    db.sp_addloaisanpham(txtName.Text);
                else if (tk.id > 1)
                {
                    db.sp_editloaisanpham(txtName.Text, tk.id);
                    db = new CanteenManagementEntities();
                }
                DataShowServices.initDataGridView(dgvData, renderGrid());
            }
            txtName.ResetText();
            groupBox1.Enabled = false;
        }
    }
}
