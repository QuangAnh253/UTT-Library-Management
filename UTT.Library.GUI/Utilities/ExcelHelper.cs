using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace UTT.Library.GUI.Utilities
{
    public static class ExcelHelper
    {
        public static void ExportToExcel(DataGridView dgv, string fileName)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = fileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    sb.Append(dgv.Columns[i].HeaderText);
                    sb.Append(",");
                }
                sb.AppendLine();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        string cell = row.Cells[i].Value == null ? "" : row.Cells[i].Value.ToString();
                        cell = cell.Replace(",", " ");
                        sb.Append(cell);
                        sb.Append(",");
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Xuất thành công!");
            }
        }
    }
}
