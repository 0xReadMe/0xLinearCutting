// Decompiled with JetBrains decompiler
// Type: OptimalCut.Zadanie0
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OptimalCut
{
  internal class Zadanie0
  {
    private static Zadanie1 parent;
    private Answer1 GreedyAnsw;
    private int G_Sh;
    private int minSh;
    private int ultimate_pgm;
    private int[] vectlim;
    private fromSh fr_Sh;
    public int[] wth;
    public int[] kol;
    public mathPosition[] zad;
    private Vcomparison compari;
    public bool IsBig;

    public Answer1 GreedyAnswer => this.GreedyAnsw;

    public int idealSheets => this.fr_Sh.idealSheets;

    public int minSheets => this.minSh;

    public int GreedlySh => this.G_Sh;

    public int allost => this.fr_Sh.allost0;

    public int ultimatePgm => this.ultimate_pgm;

    public int[] VectLim => this.vectlim;

    public double[] Cm0 => this.fr_Sh.Cm0;

    public bool Is_Golden(int ppos) => this.fr_Sh.Is_Golden(ppos);

    public bool Is_arrivedIdeal => this.G_Sh == this.idealSheets;

    public int W1 { get; set; }

    public int msiz { get; set; }

    public int pgm { get; set; }

    public Vcomparison zad_compari => this.compari;

    public Zadanie0(int pW, string pwth, string pkol)
    {
      if (pwth == "" || pkol == "")
        return;
      this.W1 = pW;
      char[] chArray = new char[1]{ ';' };
      string[] strArray1 = pwth.Split(chArray);
      string[] strArray2 = pkol.Split(chArray);
      if (strArray1.Length == strArray2.Length)
      {
        this.msiz = strArray1.Length;
        this.wth = new int[this.msiz];
        this.kol = new int[this.msiz];
        this.zad = new mathPosition[this.msiz];
        for (int index = 0; index < this.msiz; ++index)
        {
          this.wth[index] = Convert.ToInt32(strArray1[index]);
          this.kol[index] = Convert.ToInt32(strArray2[index]);
          this.zad[index] = new mathPosition(this.wth[index], this.kol[index]);
        }
        this.pgm = this.Get_pgm(this.kol);
        this.fr_Sh = new fromSh(this);
        Greedly1 greedly1 = new Greedly1(this.W1, this.zad);
        this.GreedyAnsw = greedly1.GetAnswer();
        this.ultimate_pgm = greedly1.ultimate_pgm;
        if (this.ultimate_pgm < this.W1 - this.wth[this.msiz - 1])
          this.ultimate_pgm = this.W1 - this.wth[this.msiz - 1];
        this.G_Sh = greedly1.m_theSh;
        if (this.pgm < this.W1)
          return;
        if (this.G_Sh > this.idealSheets)
          this.fr_Sh.afterGreedly(this.G_Sh);
        this.vectlim = this.Get_VectLim();
        this.minSh = this.Get_More_idealSh(this.fr_Sh.idealSheets);
        this.compari = new Vcomparison(this.kol, this.fr_Sh.allost0);
      }
      else
      {
        int num = (int) MessageBox.Show("Несовпадение по длине векторов Wth и Kol ...", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.msiz = 0;
      }
    }

    public Zadanie0(int pW, int[] pwth, int[] pkol)
    {
      this.W1 = pW;
      this.msiz = pwth.Length;
      this.wth = pwth;
      this.kol = pkol;
      this.zad = new mathPosition[this.msiz];
      for (int index = 0; index < this.msiz; ++index)
        this.zad[index] = new mathPosition(this.wth[index], this.kol[index]);
      this.pgm = this.Get_pgm(this.kol);
      this.fr_Sh = new fromSh(this);
      Greedly1 greedly1 = new Greedly1(this.W1, this.zad);
      this.GreedyAnsw = greedly1.GetAnswer();
      this.ultimate_pgm = greedly1.ultimate_pgm;
      if (this.ultimate_pgm < this.W1 - this.wth[this.msiz - 1])
        this.ultimate_pgm = this.W1 - this.wth[this.msiz - 1];
      this.G_Sh = greedly1.m_theSh;
      if (this.pgm < this.W1)
        return;
      if (this.G_Sh > this.idealSheets)
        this.fr_Sh.afterGreedly(this.G_Sh);
      this.vectlim = this.Get_VectLim();
      this.minSh = this.Get_More_idealSh(this.fr_Sh.idealSheets);
      this.compari = new Vcomparison(this.kol, this.fr_Sh.allost0);
    }

    public Zadanie0(int pW, mathPosition[] pzad)
    {
      this.W1 = pW;
      this.zad = pzad;
      this.msiz = pzad.Length;
      this.wth = new int[this.msiz];
      this.kol = new int[this.msiz];
      for (int index = 0; index < this.msiz; ++index)
      {
        this.wth[index] = this.zad[index].wth;
        this.kol[index] = this.zad[index].kol;
      }
      this.pgm = this.Get_pgm(this.kol);
      this.fr_Sh = new fromSh(this);
      Greedly1 greedly1 = new Greedly1(this.W1, this.zad);
      this.GreedyAnsw = greedly1.GetAnswer();
      this.ultimate_pgm = greedly1.ultimate_pgm;
      if (this.ultimate_pgm < this.W1 - this.wth[this.msiz - 1])
        this.ultimate_pgm = this.W1 - this.wth[this.msiz - 1];
      this.G_Sh = greedly1.m_theSh;
      if (this.pgm < this.W1)
        return;
      if (this.G_Sh > this.idealSheets)
        this.fr_Sh.afterGreedly(this.G_Sh);
      this.vectlim = this.Get_VectLim();
      this.minSh = this.Get_More_idealSh(this.fr_Sh.idealSheets);
      this.compari = new Vcomparison(this.kol, this.fr_Sh.allost0);
    }

    public int[] Get_VectLim()
    {
      int[] vectLim = new int[this.msiz];
      for (int index = 0; index < this.msiz; ++index)
        vectLim[index] = Math.Min(this.W1 / this.wth[index], this.kol[index]);
      return vectLim;
    }

    public int Get_More_idealSh(int idealSh)
    {
      int val2 = 0;
      int[] source = new int[this.msiz];
      int[] numArray = new int[this.msiz];
      int num1 = 0;
      int num2 = 0;
      for (int index = 0; index < this.msiz; ++index)
      {
        if (this.kol[index] == 0)
        {
          source[index] = 0;
        }
        else
        {
          if ((double) this.wth[index] > (double) this.W1 / 2.0)
            val2 += this.kol[index];
          if (index > 0)
          {
            if (source[index - 1] > 0)
            {
              num1 = this.W1 - this.wth[index - 1] * this.vectlim[index - 1];
              num2 = source[index - 1];
            }
            if (this.wth[index] > num1)
            {
              source[index] = (int) Math.Ceiling((Decimal) this.kol[index] / (Decimal) this.vectlim[index]);
              numArray[index - 1] = source[index];
            }
            else if (num2 > 0)
            {
              int num3 = (int) Math.Floor((double) num1 / (double) this.wth[index]);
              int num4 = this.kol[index] - num3 * num2;
              if (num4 > 0)
              {
                source[index] = (int) Math.Ceiling((Decimal) num4 / (Decimal) this.vectlim[index]);
                numArray[index - 1] = source[index];
              }
              else
                num2 -= this.kol[index] / num3;
            }
            else
            {
              source[index] = (int) Math.Ceiling((Decimal) this.kol[index] / (Decimal) this.vectlim[index]);
              numArray[index - 1] = source[index];
            }
          }
          else
            source[index] = (int) Math.Ceiling((Decimal) this.kol[index] / (Decimal) this.vectlim[index]);
        }
      }
      int val1 = ((IEnumerable<int>) source).Max();
      for (int index = 0; index < this.msiz; ++index)
      {
        if (source[index] == val1)
        {
          val1 += numArray[index];
          break;
        }
      }
      int moreIdealSh = Math.Max(Math.Max(val1, val2), idealSh);
      this.IsBig = val2 == moreIdealSh;
      return moreIdealSh;
    }

    public int Get_pgm(int[] pkol) => pkol.Length != this.msiz ? -1 : vaMatrix.Get_Scaler_Vector_Vector(this.wth, pkol, this.msiz);
  }
}
