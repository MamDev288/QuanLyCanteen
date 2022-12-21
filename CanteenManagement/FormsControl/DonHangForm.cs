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
    public partial class DonHangForm : Form
    {
        public DonHangForm()
        {
            InitializeComponent();
        }
        CanteenManagementEntities db = new CanteenManagementEntities();
        donhang tk;
        int RowIndex = -1;
        private List<Object> renderGrid()
        {
            List<donhang> render = db.donhangs.ToList();
            if (txtFilter.Text != "")
            {
                string key = txtFilter.Text;
                render = render.Where(u => u.tenkhachhang.Contains(key) || u.taikhoandn.hoten.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new {
                id = u.id,
                TenKhacHang = u.tenkhachhang,
                TongThanhToan = u.tongtien,
                GiamGia = u.giamgia,
                ThanhTien = u.thanhtoan,

            }).ToList<Object>();
            return list;
        }
        private void DonHangForm_Load(object sender, EventArgs e)
        {
            DataShowServices.initDataGridView(dgvData, renderGrid());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DonHangDetailForm f = new DonHangDetailForm();
            f.ShowDialog();
            db = new CanteenManagementEntities();
            DataShowServices.initDataGridView(dgvData, renderGrid());

        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RowIndex < 0)
                return;
            int Id = int.Parse(dgvData.Rows[RowIndex].Cells[0].Value.ToString());
            tk = db.donhangs.Include(u => u.chitietdonhangs).FirstOrDefault(u => u.id == Id);
            if(tk != null)
            {
                DonHangDetailForm f = new DonHangDetailForm(tk);
                f.ShowDialog();
                db = new CanteenManagementEntities();
                DataShowServices.initDataGridView(dgvData, renderGrid());
            }
            else
            {
                MessageBox.Show("Không tìm thấy đơn hàng", "Thông báo");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RowIndex < 0)
                return;
            int Id = int.Parse(dgvData.Rows[RowIndex].Cells[0].Value.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá đơn hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                db.sp_deteledonhang(Id);
            DataShowServices.initDataGridView(dgvData, renderGrid());

        }
    }
}
