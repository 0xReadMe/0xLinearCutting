// Decompiled with JetBrains decompiler
// Type: OptimalCut.byPart1ai
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimalCut
{
  internal class byPart1ai
  {
    private const double MaxLimit_allost_part = 0.25;
    private const double MinLimit_allost_part = 0.12;
    private mCFG parent;
    private Zadanie1 parentzad;
    private int msiz;
    private int W1;
    private int[] kol;
    private int idealSh;
    private int aost0;

    public int pgm { get; set; }

    public byPart1ai(mCFG pparent)
    {
      this.parent = pparent;
      this.parentzad = this.parent.parentzad;
      this.msiz = this.parentzad.msiz;
      this.W1 = this.parentzad.W1;
    }

    public int[] Get_Zad1(int[] pkol, double koefPart)
    {
      this.kol = pkol;
      int[] zad2 = new int[this.msiz];
      for (int index = 0; index < this.msiz; ++index)
        zad2[index] = (int) Math.Floor((double) this.kol[index] * koefPart);
      int pgm1 = this.parentzad.Get_pgm(zad2);
      double num1 = (double) (Convert.ToInt32(Math.Ceiling((double) pgm1 / (double) this.W1)) * this.W1 - pgm1) / (double) this.W1;
      int idx1 = 0;
      int num2 = int.MaxValue;
      for (; num1 > 0.25 && idx1 < this.msiz; ++idx1)
      {
        if (this.parent.the_is_prbm(idx1))
        {
          ++zad2[idx1];
          num2 = idx1;
          int pgm2 = this.parentzad.Get_pgm(zad2);
          num1 = (double) (Convert.ToInt32(Math.Ceiling((double) pgm2 / (double) this.W1)) * this.W1 - pgm2) / (double) this.W1;
        }
      }
      for (int idx2 = 0; num1 < 0.12 && idx2 < this.msiz; ++idx2)
      {
        if (!this.parent.the_is_prbm(idx2) || idx2 > num2)
        {
          --zad2[idx2];
          int pgm3 = this.parentzad.Get_pgm(zad2);
          double num3 = (double) (Convert.ToInt32(Math.Ceiling((double) pgm3 / (double) this.W1)) * this.W1 - pgm3) / (double) this.W1;
          if (num3 > 0.25)
            ++zad2[idx2];
          else
            num1 = num3;
        }
      }
      return zad2;
    }

    public int[] Get1_Zad1(int[] pkol, int limSheets)
    {
      this.kol = pkol;
      this.pgm = this.parentzad.Get_pgm(this.kol);
      this.idealSh = Convert.ToInt32(Math.Ceiling((double) this.pgm / (double) this.W1));
      this.aost0 = this.idealSh * this.W1 - this.pgm;
      double num1 = (double) limSheets / (double) this.idealSh;
      int[] numArray1 = new int[this.msiz];
      for (int index = 0; index < this.msiz; ++index)
        numArray1[index] = (int) Math.Round((double) this.kol[index] * num1);
      ((IEnumerable<int>) numArray1).Sum();
      double[] numArray2 = new double[this.msiz];
      for (int index = 0; index < this.msiz; ++index)
        numArray2[index] = (double) numArray1[index] - this.parentzad.Cm0[index] * (double) limSheets;
      int pgm1 = this.parentzad.Get_pgm(numArray1);
      double num2 = (double) (Convert.ToInt32(Math.Ceiling((double) pgm1 / (double) this.W1)) * this.W1 - pgm1) / (double) this.W1;
      int index1 = 0;
      int num3 = int.MaxValue;
      for (; num2 > 0.25 && index1 < this.msiz; ++index1)
      {
        if (numArray2[index1] < 0.0 && numArray1[index1] < this.kol[index1])
        {
          ++numArray1[index1];
          num3 = index1;
          int pgm2 = this.parentzad.Get_pgm(numArray1);
          num2 = (double) (Convert.ToInt32(Math.Ceiling((double) pgm2 / (double) this.W1)) * this.W1 - pgm2) / (double) this.W1;
        }
      }
      for (int index2 = 0; num2 < 0.12 && index2 < this.msiz; ++index2)
      {
        if (numArray2[index2] > 0.0 && numArray1[index2] > 0 || index2 > num3)
        {
          --numArray1[index2];
          int pgm3 = this.parentzad.Get_pgm(numArray1);
          double num4 = (double) (Convert.ToInt32(Math.Ceiling((double) pgm3 / (double) this.W1)) * this.W1 - pgm3) / (double) this.W1;
          if (num4 > 0.25)
            ++numArray1[index2];
          else
            num2 = num4;
        }
      }
      if (num2 > 0.25 || num2 < 0.12)
        numArray1 = this.Get1_Zad1(pkol, limSheets - 1);
      return numArray1;
    }

    public int[] Get2_Zad1(int[] pkol, ref int idealS, ref int allO)
    {
      this.kol = pkol;
      this.pgm = this.parentzad.Get_pgm(this.kol);
      this.idealSh = Convert.ToInt32(Math.Ceiling((double) this.pgm / (double) this.W1));
      this.aost0 = this.idealSh * this.W1 - this.pgm;
      int num = (int) Math.Round((double) this.parentzad.LimSh_forTmpOnePart / 1.25);
      int[] zad2 = new int[this.msiz];
      for (int index = 0; index < this.msiz; ++index)
        zad2[index] = (int) Math.Round((double) (this.kol[index] * num) / (double) this.parentzad.idealSheets);
      int pgm = this.parentzad.Get_pgm(zad2);
      idealS = Convert.ToInt32(Math.Ceiling((double) pgm / (double) this.W1));
      allO = idealS * this.W1 - pgm;
      return zad2;
    }
  }
}
