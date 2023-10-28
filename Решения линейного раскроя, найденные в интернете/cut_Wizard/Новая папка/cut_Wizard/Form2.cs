// Decompiled with JetBrains decompiler
// Type: OptimalCut.Form2
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OptimalCut
{
  public class Form2 : Form
  {
    private Form1 parent;
    private List<mathPosition> UserData;
    public int W1 = 6000;
    private UserDataMathDGV dgv;
    private IContainer components;
    private DataGridView dataGridView1;
    private GroupBox groupBox1;
    private ComboBox comboBox1;
    private Button button1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private ComboBox comboBox3;
    private Button button2;
    private Button button3;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem файлToolStripMenuItem;
    private ToolStripMenuItem загрузитьИзФайлаToolStripMenuItem;
    private ToolStripMenuItem сохранитьВФайлКакToolStripMenuItem;
    private GroupBox groupBox4;
    private TextBox textBox1;
    private TextBox textBox2;

    public List<mathPosition> userData => this.UserData;

    public Form2() => this.InitializeComponent();

    public Form2(Form1 pp)
    {
      this.InitializeComponent();
      this.parent = pp;
      this.UserData = new List<mathPosition>();
      this.dgv = new UserDataMathDGV(this.dataGridView1);
      this.dgv.CreateUserClear();
      this.comboBox1.Text = this.W1.ToString();
      this.comboBox3.Items.Clear();
      for (int index = 1; index < 201; ++index)
        this.comboBox3.Items.Add((object) index);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.parent.Set_zadanie(this.W1, this.userData);
      this.Hide();
      this.parent.Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.textBox2.Text == "")
        return;
      if (this.comboBox3.Text == "")
        this.comboBox3.Text = "1";
      int pW = Convert.ToInt32(this.textBox2.Text);
      if (pW < mathPosition.minWth)
      {
        pW = mathPosition.minWth;
        this.textBox2.Text = pW.ToString();
      }
      else if (pW > this.W1)
      {
        pW = this.W1;
        this.textBox2.Text = pW.ToString();
      }
      int int32 = Convert.ToInt32(this.comboBox3.Text);
      if (pW > this.W1 || int32 <= 0)
        return;
      this.UserData.Add(new mathPosition(pW, int32, this.textBox1.Text));
      this.dgv.RefreshToUser(this.UserData);
    }

    private void button3_Click(object sender, EventArgs e) => this.Clear_Table();

    private void comboBox1_TextChanged(object sender, EventArgs e)
    {
      List<mathPosition> mathPositionList = new List<mathPosition>();
      foreach (mathPosition mathPosition in this.UserData)
      {
        if (mathPosition.wth <= this.W1)
          mathPositionList.Add(mathPosition);
      }
      this.UserData = mathPositionList;
      this.W1 = Convert.ToInt32(this.comboBox1.Text);
      mathPosition.minWth = 0;
    }

    private void Clear_Table()
    {
      this.UserData.Clear();
      this.dgv.Clear();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      DataGridView dataGridView = (DataGridView) sender;
      if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && MessageBox.Show("удалить строку " + (e.RowIndex + 1).ToString(), "Внимание !!!", MessageBoxButtons.OKCancel) == DialogResult.OK)
      {
        this.UserData.RemoveAt(e.RowIndex);
        this.dgv.RefreshToUser(this.UserData);
      }
      if (!(dataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn) || e.RowIndex < 0)
        return;
      this.UserData[e.RowIndex].No_enabled = !this.UserData[e.RowIndex].No_enabled;
      this.dgv.RefreshToUser(this.UserData);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.dataGridView1 = new DataGridView();
      this.groupBox1 = new GroupBox();
      this.comboBox1 = new ComboBox();
      this.button1 = new Button();
      this.groupBox2 = new GroupBox();
      this.groupBox3 = new GroupBox();
      this.comboBox3 = new ComboBox();
      this.button2 = new Button();
      this.button3 = new Button();
      this.menuStrip1 = new MenuStrip();
      this.файлToolStripMenuItem = new ToolStripMenuItem();
      this.загрузитьИзФайлаToolStripMenuItem = new ToolStripMenuItem();
      this.сохранитьВФайлКакToolStripMenuItem = new ToolStripMenuItem();
      this.groupBox4 = new GroupBox();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(12, 87);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ScrollBars = ScrollBars.Vertical;
      this.dataGridView1.Size = new Size(567, 364);
      this.dataGridView1.TabIndex = 5;
      this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.groupBox1.Controls.Add((Control) this.comboBox1);
      this.groupBox1.Location = new Point(12, 30);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(306, 52);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "  Размер заготовки, контейнера, рюкзака, болванки  ";
      this.comboBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[8]
      {
        (object) "6000",
        (object) "5000",
        (object) "4500",
        (object) "3000",
        (object) "2500",
        (object) "2000",
        (object) "1250",
        (object) "1000"
      });
      this.comboBox1.Location = new Point(86, 19);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(107, 28);
      this.comboBox1.TabIndex = 0;
      this.comboBox1.TextChanged += new EventHandler(this.comboBox1_TextChanged);
      this.button1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.button1.Location = new Point(481, 36);
      this.button1.Name = "button1";
      this.button1.Size = new Size(98, 39);
      this.button1.TabIndex = 6;
      this.button1.Text = "Готово";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.groupBox2.Controls.Add((Control) this.textBox2);
      this.groupBox2.Location = new Point(13, 457);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(134, 52);
      this.groupBox2.TabIndex = 7;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "  Размер ,  мм  ";
      this.groupBox3.Controls.Add((Control) this.comboBox3);
      this.groupBox3.Location = new Point(163, 457);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(134, 52);
      this.groupBox3.TabIndex = 8;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "  Количество ,  шт ";
      this.comboBox3.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.comboBox3.FormattingEnabled = true;
      this.comboBox3.Location = new Point(16, 19);
      this.comboBox3.Name = "comboBox3";
      this.comboBox3.Size = new Size(107, 24);
      this.comboBox3.TabIndex = 0;
      this.button2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.button2.Location = new Point(313, 468);
      this.button2.Name = "button2";
      this.button2.Size = new Size(98, 39);
      this.button2.TabIndex = 9;
      this.button2.Text = "Добавить";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button3.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.button3.Location = new Point(430, 468);
      this.button3.Name = "button3";
      this.button3.Size = new Size(150, 39);
      this.button3.TabIndex = 10;
      this.button3.Text = "Очистить таблицу";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.menuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.файлToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(592, 24);
      this.menuStrip1.TabIndex = 11;
      this.menuStrip1.Text = "menuStrip1";
      this.файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.загрузитьИзФайлаToolStripMenuItem,
        (ToolStripItem) this.сохранитьВФайлКакToolStripMenuItem
      });
      this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
      this.файлToolStripMenuItem.Size = new Size(45, 20);
      this.файлToolStripMenuItem.Text = "Файл";
      this.загрузитьИзФайлаToolStripMenuItem.Name = "загрузитьИзФайлаToolStripMenuItem";
      this.загрузитьИзФайлаToolStripMenuItem.Size = new Size(200, 22);
      this.загрузитьИзФайлаToolStripMenuItem.Text = "Загрузить из файла";
      this.сохранитьВФайлКакToolStripMenuItem.Name = "сохранитьВФайлКакToolStripMenuItem";
      this.сохранитьВФайлКакToolStripMenuItem.Size = new Size(200, 22);
      this.сохранитьВФайлКакToolStripMenuItem.Text = "Сохранить в файл как...";
      this.groupBox4.Controls.Add((Control) this.textBox1);
      this.groupBox4.Location = new Point(13, 515);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(566, 52);
      this.groupBox4.TabIndex = 12;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "  Комментарий";
      this.textBox1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.textBox1.Location = new Point(16, 19);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(544, 23);
      this.textBox1.TabIndex = 0;
      this.textBox2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.textBox2.Location = new Point(16, 19);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(100, 23);
      this.textBox2.TabIndex = 14;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(592, 573);
      this.Controls.Add((Control) this.groupBox4);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.groupBox3);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = nameof (Form2);
      this.Text = "  Формирование задания  ";
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
