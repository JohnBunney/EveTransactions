using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTransactions.Domain
{
    class FastGridView : System.Windows.Forms.DataGridView
    {
        public FastGridView()
        {
            DoubleBuffered = true;
        }
    }
}