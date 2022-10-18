using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI
{
    internal class MessageManager
    {
        public MessageManager()
        {

        }

        public void ShowError(string msg)
        {
            MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInfo(string msg)
        {
            MessageBox.Show(msg, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
