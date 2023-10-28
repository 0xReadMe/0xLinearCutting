// Decompiled with JetBrains decompiler
// Type: OptimalCut.UserDataMathDGV
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OptimalCut
{
  internal class UserDataMathDGV
  {
    private const int colCountUser = 6;
    private const int colCountMath = 3;
    private DataGridView grid;

    public UserDataMathDGV(DataGridView dgv) => this.grid = dgv;

    public void Clear() => this.grid.Rows.Clear();

    public void CreateUserClear()
    {
      this.grid.Rows.Clear();
      this.grid.Columns.Clear();
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.HeaderText = "  № ";
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.Name = "num";
      dataGridViewColumn1.Frozen = true;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.grid.Columns.Add(dataGridViewColumn1);
      DataGridViewButtonColumn viewButtonColumn = new DataGridViewButtonColumn();
      viewButtonColumn.HeaderText = "";
      viewButtonColumn.Text = " Удалить";
      viewButtonColumn.UseColumnTextForButtonValue = true;
      viewButtonColumn.Width = 66;
      viewButtonColumn.Name = "delet";
      viewButtonColumn.Frozen = true;
      this.grid.Columns.Add((DataGridViewColumn) viewButtonColumn);
      DataGridViewCheckBoxColumn viewCheckBoxColumn = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn.HeaderText = " Откл ";
      viewCheckBoxColumn.Width = 50;
      viewCheckBoxColumn.Name = "off";
      viewCheckBoxColumn.Frozen = true;
      viewCheckBoxColumn.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      this.grid.Columns.Add((DataGridViewColumn) viewCheckBoxColumn);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.HeaderText = " Размер, мм ";
      dataGridViewColumn2.Width = 100;
      dataGridViewColumn2.ReadOnly = true;
      dataGridViewColumn2.Name = "wth";
      dataGridViewColumn2.Frozen = true;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.grid.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.HeaderText = " Количество, шт ";
      dataGridViewColumn3.Width = 100;
      dataGridViewColumn3.ReadOnly = true;
      dataGridViewColumn3.Name = "kol";
      dataGridViewColumn3.Frozen = true;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.grid.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.HeaderText = "  Комментарий ";
      dataGridViewColumn4.Width = 150;
      dataGridViewColumn4.ReadOnly = true;
      dataGridViewColumn4.Name = "comm";
      dataGridViewColumn4.Frozen = true;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.grid.Columns.Add(dataGridViewColumn4);
      this.grid.AllowUserToAddRows = false;
    }

    public void CreateMathClear()
    {
      this.grid.Rows.Clear();
      this.grid.Columns.Clear();
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.HeaderText = "  № ";
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.Name = "num";
      dataGridViewColumn1.Frozen = true;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.grid.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.HeaderText = " Размер, мм ";
      dataGridViewColumn2.Width = 100;
      dataGridViewColumn2.ReadOnly = true;
      dataGridViewColumn2.Name = "wth";
      dataGridViewColumn2.Frozen = true;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.grid.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.HeaderText = " Количество, шт ";
      dataGridViewColumn3.Width = 100;
      dataGridViewColumn3.ReadOnly = true;
      dataGridViewColumn3.Name = "kol";
      dataGridViewColumn3.Frozen = true;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.grid.Columns.Add(dataGridViewColumn3);
      this.grid.AllowUserToAddRows = false;
    }

    public void RefreshToUser(List<mathPosition> UserData)
    {
      this.Clear();
      for (int index1 = 0; index1 < UserData.Count; ++index1)
      {
        this.grid.Rows.Add((object) ((index1 + 1).ToString() + "."), null, null, (object) UserData[index1].wth, (object) UserData[index1].kol, (object) UserData[index1].comm1);
        this.grid.Rows[index1].Cells[1].Style.BackColor = Color.WhiteSmoke;
        this.grid.Rows[index1].Cells[2].Value = (object) UserData[index1].No_enabled;
        if (UserData[index1].No_enabled)
        {
          for (int index2 = 2; index2 < 6; ++index2)
            this.grid.Rows[index1].Cells[index2].Style.BackColor = Color.Silver;
        }
        else
        {
          for (int index3 = 2; index3 < 6; ++index3)
            this.grid.Rows[index1].Cells[index3].Style.BackColor = Color.White;
        }
        for (int index4 = 0; index4 < 6; ++index4)
          this.grid.Rows[index1].Cells[index4].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      }
    }

    public void RefreshToMath(List<mathPosition> mData)
    {
      this.Clear();
      for (int index1 = 0; index1 < mData.Count; ++index1)
      {
        this.grid.Rows.Add((object) ((index1 + 1).ToString() + "."), (object) mData[index1].wth, (object) mData[index1].kol);
        for (int index2 = 0; index2 < 3; ++index2)
          this.grid.Rows[index1].Cells[index2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      }
    }
  }
}
