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

        private void TaiKhoanForm_Load(object sender, EventArgs e)
        {
            DataShowServices.initDataGridView(dgvData, renderGrid());
        }
        private List<Object> renderGrid()
        {
            List<taikhoan> render = db.taikhoans.ToList();
            if (txtFilter.Text != "")
            {
                string key = txtFilter.Text;
                render = render.Where(u => u.hoten.Contains(key) || u.taikhoan1.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new {
                id = u.id,
                TaiKhoan = u.taikhoan1,
                HoTen = u.hoten,
                
            }).ToList<Object>();
            return list;
        }
    }
}
