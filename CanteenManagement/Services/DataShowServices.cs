using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenManagement.Services
{
    public class DataShowServices
    {
        public static void initCombobox(ComboBox cbb, dynamic data)
        {
            cbb.DataSource = data;
            cbb.ValueMember = "id";
            cbb.DisplayMember = "name";
            cbb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public static void initDataGridView(DataGridView dgv, dynamic data)
        {
            if (data.Count == 0)
            {
                return;
            }
            dgv.Columns.Clear();
            dgv.DataSource = data;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           
        }
    }
}
