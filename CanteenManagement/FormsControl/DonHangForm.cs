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
        loaisanpham tk;
        int RowIndex = -1;
        private List<Object> renderGrid()
        {
            List<donhang> render = db.donhangs.Include(u => u.chitietdonhangs).ToList();
            if (txtFilter.Text != "")
            {
                string key = txtFilter.Text;
                render = render.Where(u => u.tenkhachhang.Contains(key) || u.taikhoandn.hoten.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new {
                id = u.id,
                TenKhacHang = u.tenkhachhang,
                SoLuongSanPham = u.chitietdonhangs.Count(),
                ThanhTien = u.thanhtoan,
                GiamGia = u.giamgia,
                TongThanhToan = u.tongtien,

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
            DataShowServices.initDataGridView(dgvData, renderGrid());

        }
    }
}
