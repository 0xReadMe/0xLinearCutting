// Decompiled with JetBrains decompiler
// Type: OptimalCut.Form1
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OptimalCut
{
  public class Form1 : Form
  {
    private const string dom0 = "http://orencod1.ru/";
    private const string dom1 = "http://orencod1.ru/";
    private const string dom2 = "https://orenstudent.ru/";
    private const string prm1 = "OptimalCut";
    private const string prm2 = "cut_Wizard";
    private const string webname = "OptimalCut.htm";
    private const string prms = "ep=cut_Wizard&dt=210219";
    private const string DMNS = "https://orenstudent.ru/";
    private List<mathPosition> mathData;
    private List<mathPosition> UserData;
    private int W1 = 6000;
    private UserDataMathDGV dgv;
    private Form2 oldF2;
    private Zadanie1 zad;
    private mCFG mdCfg;
    private Answer1 answ;
    private bool not_cert;
    private IContainer components;
    private Button button1;
    private Button button2;
    private GroupBox groupBox1;
    private Label label1;
    private DataGridView dataGridView1;
    private Button button3;
    private Timer timer1;
    private Label labelWeb1;
    private Label labelWeb2;

    public Form1()
    {
      this.InitializeComponent();
      this.mathData = new List<mathPosition>();
      this.WebReclam();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.zad.finish = true;
      this.timer1.Enabled = false;
    }

    private void zadTimerOn()
    {
      this.zad.finish = false;
      this.timer1.Enabled = true;
      this.Cursor = Cursors.WaitCursor;
    }

    public void Set_zadanie(int pW1, List<mathPosition> param)
    {
      if (param.Count == 0)
        return;
      Mon1.pasw1 = 0;
      Mon1.strKStr = "";
      this.W1 = pW1;
      this.UserData = new List<mathPosition>();
      this.mathData.Clear();
      foreach (mathPosition p in param)
      {
        if (!p.No_enabled)
        {
          this.UserData.Add(p);
          int index = this.IdxAlreadyWth(p.wth);
          if (index == -1)
            this.mathData.Add(new mathPosition(p));
          else
            this.mathData[index].kol += p.kol;
        }
      }
      this.ListSortByWth(this.mathData);
      this.button1.Visible = true;
      this.Show_zadanie();
      this.send1();
      if (this.not_cert || Mon1.pasw1 == 0)
        return;
      this.Prepare_zadanie();
    }

    public void ListSortByWth(List<mathPosition> collecti)
    {
      if (collecti.Count <= 1)
        return;
      collecti.Sort((Comparison<mathPosition>) ((x, y) =>
      {
        if (x == null && y == null)
          return 0;
        if (x == null)
          return 1;
        return y == null ? -1 : x.CompareTo(y);
      }));
    }

    private void Prepare_zadanie()
    {
      this.zad = new Zadanie1(this.W1, this.mathData.ToArray<mathPosition>());
      this.mdCfg = this.zad.mdCfg_links;
    }

    private int IdxAlreadyWth(int pwth)
    {
      int num = -1;
      for (int index = 0; index < this.mathData.Count; ++index)
      {
        if (this.mathData[index].wth == pwth)
        {
          num = index;
          break;
        }
      }
      return num;
    }

    public void Show_zadanie()
    {
      this.label1.Text = this.W1.ToString();
      this.dgv = new UserDataMathDGV(this.dataGridView1);
      this.dgv.CreateMathClear();
      this.dgv.RefreshToMath(this.mathData);
    }

    public void send1()
    {
      Mon1.sert = this.ReadCertific();
      if (this.not_cert)
        return;
      Mon1.sert678 = Mon1.sert.Substring(6, 3);
      Mon1.dat1 = DateTimeOffset.Now.ToUnixTimeSeconds();
      string str1 = "{\"UserData\":[";
      foreach (mathPosition mathPosition in this.UserData)
        str1 = str1 + mathPosition.PositionToJson_user() + ",";
      string str2 = str1.Substring(0, str1.Length - 1) + "]}";
      string str3 = HtmlDownloadHelper.DownloadHtml("http://orencod1.ru/optimi/enabli.php", "p1=" + this.W1.ToString() + "&p2=" + str2 + "&p3=" + Mon1.dat1.ToString() + "&p4=" + 456123.ToString() + "&p5=" + Mon1.sert678.ToString());
      if (!(str3 != ""))
        return;
      string[] strArray = str3.Split((char[]) null, 2);
      Mon1.pasw1 = Convert.ToInt32(strArray[0]);
      Mon1.strKStr = strArray[1];
      Mon1.strKStr_plusTimes();
    }

    private string send2(string dom)
    {
      string jsonMathData = Mon1.Get_JsonMathData(this.mathData);
      string closedJsonAnswer = Mon1.Get_ClosedJsonAnswer(this.zad.Best.answ);
      string reqString = "p1=" + Mon1.pasw1.ToString() + "&p2=" + Mon1.strKStr + "&p3=" + this.W1.ToString() + "&p4=" + jsonMathData + "&p5=" + closedJsonAnswer;
      string str = HtmlDownloadHelper.DownloadHtml(dom + "optimi/OptimalCut.php", reqString);
      if (str.Length > 65)
      {
        str = "";
        int num = (int) MessageBox.Show("Error in 2");
      }
      return str;
    }

    private void send3(string dom, string fn)
    {
      if (dom.Length > 0)
      {
        Process.Start(dom + "optimi/" + fn);
      }
      else
      {
        int num = (int) MessageBox.Show("Доступна для скачивания более свежая версия!");
      }
    }

    private void TestMon()
    {
      int startIndex1;
      Mon1 mon1_1 = new Mon1(startIndex1 = 1, Convert.ToInt32(Mon1.strKStr.Substring(startIndex1, 1)), 0);
      int num1;
      Mon1 mon1_2 = new Mon1(num1 = 2, -1, -1);
      int startIndex2;
      Mon1 mon1_3 = new Mon1(startIndex2 = 3, Convert.ToInt32(Mon1.strKStr.Substring(startIndex2, 1)), 0);
      Mon1 mon1_4 = new Mon1(num1 = 4, -1, -1);
      int num2 = (int) MessageBox.Show(mon1_1.Value.ToString() + "       " + mon1_2.Value.ToString() + "       " + mon1_3.Value.ToString() + "       " + mon1_4.Value.ToString());
    }

    public string ReadCertific()
    {
      string path = "cert.dat";
      if (!File.Exists(path))
      {
        this.not_cert = true;
        return "";
      }
      string str1 = "";
      using (StreamReader streamReader = new StreamReader(path, Encoding.Default))
      {
        string str2;
        while ((str2 = streamReader.ReadLine()) != null)
          str1 += str2;
      }
      return str1;
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.oldF2 = (Form2) null;
      Form2 form2 = new Form2(this);
      form2.Show();
      this.oldF2 = form2;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.oldF2 == null)
        return;
      this.oldF2.Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.not_cert)
      {
        int num = (int) MessageBox.Show("Нет сертификата приложения");
        this.Close();
      }
      if (this.mathData.Count == 0)
        return;
      if (Mon1.pasw1 == 0)
      {
        int num1 = (int) MessageBox.Show("Извините, сервер перегружен, попробуйте повторить позднее…");
      }
      else
      {
        if (!this.zad.primitive && this.mdCfg != null)
        {
          mProc mProc = new mProc(this.mdCfg);
          this.zadTimerOn();
          this.mdCfg.GetAnswer(mProc.Get_sumParts());
        }
        string fn = this.send2("https://orenstudent.ru/");
        if (fn != "")
          this.send3("https://orenstudent.ru/", fn);
        this.Cursor = Cursors.Default;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.button1 = new Button();
      this.button2 = new Button();
      this.groupBox1 = new GroupBox();
      this.label1 = new Label();
      this.dataGridView1 = new DataGridView();
      this.button3 = new Button();
      this.timer1 = new Timer(this.components);
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.button1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.button1.Location = new Point(216, 477);
      this.button1.Name = "button1";
      this.button1.Size = new Size(164, 39);
      this.button1.TabIndex = 0;
      this.button1.Text = "Изменить задание";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Visible = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.button2.Location = new Point(12, 522);
      this.button2.Name = "button2";
      this.button2.Size = new Size(368, 39);
      this.button2.TabIndex = 1;
      this.button2.Text = "Рассчитать и Вывести результат в браузер";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Location = new Point(46, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(306, 52);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "  Размер заготовки, контейнера, рюкзака, болванки  ";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label1.Location = new Point(123, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(64, 26);
      this.label1.TabIndex = 0;
      this.label1.Text = "6000";
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(48, 70);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ScrollBars = ScrollBars.Vertical;
      this.dataGridView1.Size = new Size(304, 389);
      this.dataGridView1.TabIndex = 3;
      this.button3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.button3.Location = new Point(12, 477);
      this.button3.Name = "button3";
      this.button3.Size = new Size(164, 39);
      this.button3.TabIndex = 4;
      this.button3.Text = "Новое задание";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.timer1.Interval = 57000;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(392, 596);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Name = nameof (Form1);
      this.Text = "  cut_Wizard  Оптимальное линейное разложение";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
    }

    private void WebReclam()
    {
      this.labelWeb1 = new Label();
      this.labelWeb1.AutoSize = true;
      this.labelWeb1.Cursor = Cursors.Hand;
      this.labelWeb1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, (byte) 204);
      this.labelWeb1.ForeColor = SystemColors.HotTrack;
      this.labelWeb1.BackColor = Color.Transparent;
      this.labelWeb1.Location = new Point(112, 570);
      this.labelWeb1.Name = "labelWeb1";
      this.labelWeb1.Size = new Size(168, 13);
      this.labelWeb1.TabIndex = 5;
      this.labelWeb1.Text = "https://orenstudent.ru/";
      this.labelWeb1.Click += new EventHandler(this.labelWeb1_Click);
      this.labelWeb2 = new Label();
      this.labelWeb2.AutoSize = true;
      this.labelWeb2.Cursor = Cursors.Hand;
      this.labelWeb2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, (byte) 204);
      this.labelWeb2.ForeColor = SystemColors.HotTrack;
      this.labelWeb2.BackColor = Color.Transparent;
      this.labelWeb2.Location = new Point(12, 280);
      this.labelWeb2.Name = "labelWeb2";
      this.labelWeb2.Size = new Size(101, 13);
      this.labelWeb2.TabIndex = 6;
      this.labelWeb2.Text = "О возможностях...";
      this.labelWeb2.Click += new EventHandler(this.labelWeb2_Click);
      this.Controls.Add((Control) this.labelWeb2);
      this.Controls.Add((Control) this.labelWeb1);
      this.FormClosed += new FormClosedEventHandler(this.WebReclam_FormClosed);
      this.labelWeb2.Visible = false;
    }

    private string Get_prot_domain(string str)
    {
      string protDomain = "http://" + str + ".ru/";
      if (str == "orenstudent")
        protDomain = "https://" + str + ".ru/";
      return protDomain;
    }

    private string dmntraf()
    {
      string str1 = "";
      string str2 = HtmlDownloadHelper.DownloadHtml(this.Get_prot_domain("orenstudent") + "includes/enableddomain.php", "drw=20200901");
      if (str2.Length > 5)
        str1 = this.Get_prot_domain(str2);
      else if (HtmlDownloadHelper.DownloadHtml(this.Get_prot_domain("orencod") + "includes/enabledtest.php", "drw=20200901") == "drwown")
      {
        str1 = this.Get_prot_domain("orencod");
      }
      else
      {
        for (int index = 1; index <= 153; ++index)
        {
          string protDomain = this.Get_prot_domain("orencod" + index.ToString());
          if (HtmlDownloadHelper.DownloadHtml(protDomain + "includes/enabledtest.php", "drw=20200901") == "drwown")
            return protDomain;
        }
      }
      return str1;
    }

    private void labelWeb1_Click(object sender, EventArgs e) => Process.Start("https://orenstudent.ru/OptimalCut.htm");

    private void labelWeb2_Click(object sender, EventArgs e) => Process.Start("https://orenstudent.ru/about.htm");

    private void WebReclam_FormClosed(object sender, FormClosedEventArgs e)
    {
      string str = this.dmntraf();
      if (str.Length > 0)
      {
        Process.Start(str + "drwcou.php?ep=cut_Wizard&dt=210219");
      }
      else
      {
        int num = (int) MessageBox.Show("Доступна для скачивания более свежая версия!");
      }
    }
  }
}
