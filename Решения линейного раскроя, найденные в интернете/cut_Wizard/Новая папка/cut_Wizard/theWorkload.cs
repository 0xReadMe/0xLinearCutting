// Decompiled with JetBrains decompiler
// Type: OptimalCut.theWorkload
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;

namespace OptimalCut
{
  internal class theWorkload
  {
    public const int partLim = 8000;
    private mCFG parent;
    private Zadanie1 parentzad;
    private int msiz;
    private int W1;
    private int[] kol;
    private int idealSh;
    private int aost0;
    private double workload;
    private int LimSh_forTmpPart1;
    private double KPart;

    public int pgm { get; set; }

    public double Workload => this.workload;

    public int LimSh_forTmpOnePart => this.LimSh_forTmpPart1;

    public double KoefPart => this.KPart;

    public theWorkload(mCFG pparent)
    {
      this.parent = pparent;
      this.parentzad = this.parent.parentzad;
      this.msiz = this.parentzad.msiz;
      this.W1 = this.parentzad.W1;
      this.kol = this.parentzad.kol;
      this.idealSh = Convert.ToInt32(Math.Ceiling((double) this.parentzad.pgm / (double) this.W1));
      this.aost0 = this.idealSh * this.W1 - this.parentzad.pgm;
      this.workload = this.Get_workload(this.kol, this.aost0);
    }

    private double Get_workload(int[] pkol, int allost)
    {
      double num = 0.0;
      for (int idx = 0; idx < this.msiz; ++idx)
      {
        if (this.parent.the_is_prbm(idx))
          num += (double) pkol[idx] / (double) this.parentzad.wth[idx];
      }
      double wload = num * (double) (this.parent.parentPAC.Count * this.msiz * allost / this.W1);
      this.LimSh_forTmpPart1 = this.Get_LimSh_forTmpPart1(wload);
      this.KPart = (double) this.LimSh_forTmpPart1 / (double) this.idealSh;
      return wload;
    }

    private int Get_LimSh_forTmpPart1(double wload) => wload > 5.0 ? (wload > 50.0 ? (wload > 100.0 ? (wload > 500.0 ? (wload > 1000.0 ? (wload > 4000.0 ? 6 : 9) : 12) : 16) : 24) : 32) : this.idealSh;
  }
}
