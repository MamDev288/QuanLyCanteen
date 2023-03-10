using CanteenManagement.Models;
using CanteenManagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenManagement.FormsControl
{
    public partial class TaiKhoanForm : Form
    {
        public TaiKhoanForm()
        {
            InitializeComponent();
        }
        CanteenManagementEntities db = new CanteenManagementEntities();
        taikhoandn tk;
        int RowIndex = -1;
        private void TaiKhoanForm_Load(object sender, EventArgs e)
        {
            DataShowServices.initDataGridView(dgvData, renderGrid());
            groupBox1.Enabled = false;
        }
        private List<Object> renderGrid()
        {
            List<taikhoandn> render = db.taikhoandns.ToList();
            if (txtFilter.Text != "")
            {
                string key = txtFilter.Text;
                render = render.Where(u => u.hoten.Contains(key) || u.taikhoan.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new {
                id = u.id,
                TaiKhoan = u.taikhoan,
                HoTen = u.hoten,
                
            }).ToList<Object>();
            return list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tk != null)
            {
                if (tk.id == 0)
                    db.sp_addtaikhoan(txtTk.Text, txtMK.Text, txtName.Text);
                else if (tk.id > 1)
                {
                    db.sp_edittaikhoan(txtMK.Text, txtName.Text, tk.id);
                    db = new CanteenManagementEntities();
                }
                DataShowServices.initDataGridView(dgvData, renderGrid());
            }
            txtTk.ResetText();
            txtMK.ResetText();
            txtName.ResetText();
            groupBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tk = new taikhoandn();
            groupBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RowIndex >= 0)
            {
                int Id = (int)dgvData.Rows[RowIndex].Cells[0].Value;
                tk = db.taikhoandns.FirstOrDefault(u => u.id == Id);
                if(tk != null)
                {
                    txtTk.Text = tk.taikhoan;
                    txtMK.Text = tk.matkhau;
                    txtName.Text = tk.hoten;
                    groupBox1.Enabled = true;
                }else
                    MessageBox.Show("Không tìm thấy tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(RowIndex >= 0)
            {
                int Id =(int)dgvData.Rows[RowIndex].Cells[0].Value;
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    db.sp_deteletaikhoan(Id);
                DataShowServices.initDataGridView(dgvData, renderGrid());

            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;
        }
    }
}
