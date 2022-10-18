using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI
{
    internal class MyProgramUtils
    {
        public MyProgramUtils()
        {

        }

        public object getFieldOfSelectedCell(DataGridView dt, int idx)
        {
            int idrow = dt.SelectedCells[0].RowIndex;
            return dt.Rows[idrow].Cells[idx].Value;
        }

        public object getFieldOfComboBoxSelectedItem(ComboBox cb, int idx)
        {
            DataRowView row = (DataRowView)cb.SelectedItem;
            return row[idx];
        }

        public object getItemOfRowComboBox(ComboBox cb, int row, int idx)
        {
            DataRowView rowfin = (DataRowView)cb.Items[row];
            return rowfin[idx];
        }
    }
}
