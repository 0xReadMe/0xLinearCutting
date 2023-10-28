// Decompiled with JetBrains decompiler
// Type: OptimalCut.fromSh
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;

namespace OptimalCut
{
  internal class fromSh
  {
    private Zadanie0 parent;
    private int idealSh;
    private int GreedlySh;
    private int aost0;
    private int cmsiz;
    private double[,] cmMatrix;
    private double[] cm0;

    public int idealSheets => this.idealSh;

    public int allost0 => this.aost0;

    public int minSheets => this.parent.minSheets;

    public double[] Cm0 => this.cm0;

    public fromSh(Zadanie0 pp)
    {
      this.parent = pp;
      this.idealSh = Convert.ToInt32(Math.Ceiling((double) this.parent.pgm / (double) this.parent.W1));
      this.aost0 = this.idealSh * this.parent.W1 - this.parent.pgm;
      this.cm0 = new double[this.parent.msiz + 1];
      for (int index = 0; index < this.parent.msiz; ++index)
        this.cm0[index] = (double) this.parent.kol[index] / (double) this.idealSh;
      this.cm0[this.parent.msiz] = (double) this.aost0 / (double) this.idealSh;
    }

    public void afterGreedly(int GreedlySheets)
    {
      this.GreedlySh = GreedlySheets;
      if (this.GreedlySh == this.idealSh)
        return;
      this.cmsiz = this.GreedlySh - this.idealSh + 1;
      this.cmMatrix = new double[this.parent.msiz + 1, this.cmsiz];
      for (int index = 0; index < this.parent.msiz + 1; ++index)
        this.cmMatrix[index, 0] = this.cm0[index];
      for (int index1 = 1; index1 < this.cmsiz; ++index1)
      {
        for (int index2 = 0; index2 < this.parent.msiz; ++index2)
          this.cmMatrix[index2, index1] = (double) this.parent.kol[index2] / (double) (this.idealSh + index1);
        this.cmMatrix[this.parent.msiz, index1] = (double) (this.aost0 + this.parent.W1 * index1) / (double) (this.idealSh + index1);
      }
    }

    public bool Is_Golden(int ppos)
    {
      int num = this.parent.W1 / this.parent.wth[ppos];
      return (double) (this.parent.W1 - this.parent.wth[ppos] * num) <= this.cm0[this.parent.msiz];
    }
  }
}
