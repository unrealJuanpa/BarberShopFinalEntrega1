using System;
using System.Collections.Generic;
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
    }
}
