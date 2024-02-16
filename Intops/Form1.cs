using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intops
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FakeDataGridView();
            SetColumnWidthsToFill(dataGridView1);
            SetColumnWidthsToFill(dataGridView2);
        }

        private void FakeDataGridView()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView2.ColumnCount = 4;

            dataGridView1.Columns[0].Name = "Time";
            dataGridView1.Columns[1].Name = "Model";
            dataGridView1.Columns[2].Name = "Module";
            dataGridView1.Columns[3].Name = "Result";

            dataGridView2.Columns[0].Name = "Time";
            dataGridView2.Columns[1].Name = "Model";
            dataGridView2.Columns[2].Name = "Module";
            dataGridView2.Columns[3].Name = "Result";

            // Add example data
            string[] row1 = { "13:49:12", "Canvas_V01", "1", "OK" };
            string[] row2 = { "13:49:12", "Canvas_V03", "2", "NG" };
            string[] row3 = { "13:49:12", "Canvas_V05", "3", "NG" };
            string[] row4 = { "13:49:12", "Canvas_V06", "3", "OK" };
            string[] row5 = { "13:49:12", "Canvas_V05", "4", "NG" };
            string[] row6 = { "13:49:12", "Canvas_V06", "3", "OK" };

            // Add rows to DataGridView
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
            dataGridView1.Rows.Add(row3);
            dataGridView1.Rows.Add(row4);
            dataGridView1.Rows.Add(row5);
            dataGridView1.Rows.Add(row6);

            dataGridView2.Rows.Add(row1);
            dataGridView2.Rows.Add(row2);
            dataGridView2.Rows.Add(row3);
            dataGridView2.Rows.Add(row4);
            dataGridView2.Rows.Add(row5);
            dataGridView2.Rows.Add(row6);
        }

        private void SetColumnWidthsToFill(DataGridView dataGridView)
        {
            int totalWidth = dataGridView.ClientSize.Width - dataGridView.RowHeadersWidth;

            // Calculate total width of visible columns
            int visibleColumnWidth = 0;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Visible)
                    visibleColumnWidth += column.Width;
            }

            // Set the width of each column proportionally
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Visible)
                {
                    float percentage = (float)column.Width / visibleColumnWidth;
                    column.Width = (int)(percentage * totalWidth);
                }
            }
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FormSearch fs = new FormSearch();
            fs.ShowDialog();
        }
    }
}
