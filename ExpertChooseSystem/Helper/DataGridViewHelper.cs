using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExpertChooseSystem.Helper
{
    class DataGridViewHelper
    {
        public static void SetDataSourceAndHeader(DataGridView dataGridView, object dataSource, IList<string> headers)
        {
            dataGridView.DataSource = dataSource;
            int columnIndex = 0;
            foreach (var headerText in headers)
            {
                dataGridView.Columns[columnIndex].HeaderText = headerText;
                columnIndex++;
            }
        }
    }
}
