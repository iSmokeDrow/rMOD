using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rdbCore.Structures;

namespace rMOD.Functions
{
    public class Grid
    {
        public static void LoadData(bool columnsSet)
        {
            if (!columnsSet) { generateColumns(); }
            GUI.Instance.TabControls.SetGridRowcount(GUI.Instance.rCore.RowCount);
        }

        private static void generateColumns()
        {
            int colCount = GUI.Instance.rCore.FieldCount;

            DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[colCount];

            for (int i = 0; i < colCount; i++)
            {
                LuaField field = GUI.Instance.rCore.GetField(i);

                columns[i] = new DataGridViewTextBoxColumn()
                {
                    Name = field.Name,
                    HeaderText = field.Name,
                    Width = 100,
                    Resizable = DataGridViewTriState.True,
                    Visible = field.Show
                };
            }

            GUI.Instance.TabControls.AddGridColumns(columns);
        }

        public static void Grid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (GUI.Instance.rCore != null)
            {
                int rowCount = GUI.Instance.rCore.RowCount;

                if (e.RowIndex == rowCount - 1) return;
                if (e.RowIndex == 0 & rowCount == 0) { return; }
                Row row = GUI.Instance.rCore.GetRow(e.RowIndex);
                e.Value = row[e.ColumnIndex];
            }
        }
    }
}
