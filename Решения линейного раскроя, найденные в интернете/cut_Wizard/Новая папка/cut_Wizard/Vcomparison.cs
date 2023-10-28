// Decompiled with JetBrains decompiler
// Type: OptimalCut.Vcomparison
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;

namespace OptimalCut
{
  internal class Vcomparison
  {
    private int[] kolzad;
    private int allost;
    private int[] fltr;
    private int msiz;

    public Vcomparison(int[] pkol, int aost = -1)
    {
      this.msiz = pkol.Length;
      this.kolzad = pkol;
      this.allost = aost;
      int[] keys = new int[this.msiz];
      this.kolzad.CopyTo((Array) keys, 0);
      this.fltr = new int[this.msiz];
      for (int index = 0; index < this.msiz; ++index)
        this.fltr[index] = index;
      Array.Sort<int, int>(keys, this.fltr);
    }

    public int GetKRAt(int[] cut, int ost = -1, int limSh = -1)
    {
      if (cut.Length != this.msiz)
        return -1;
      int val1 = int.MaxValue;
      int val2 = int.MaxValue;
      if (ost > 0 && this.allost > -1)
        val2 = (int) Math.Floor((double) this.allost / (double) ost);
      if (limSh > -1 && limSh > val2)
        return -2;
      for (int index1 = 0; index1 < this.msiz; ++index1)
      {
        int index2 = this.fltr[index1];
        if (cut[index2] > 0)
        {
          double num = Math.Floor((double) this.kolzad[index2] / (double) cut[index2]);
          if (num < 1.0)
            return 0;
          if ((double) val1 > num)
            val1 = Convert.ToInt32(num);
        }
      }
      return Math.Min(val1, val2);
    }

    public int[] GetVector_Sum_with_Break(int[] cut1, int[] cut2, int ost1 = -1, int ost2 = -1)
    {
      if (cut1.Length != this.msiz || cut2.Length != this.msiz)
        return (int[]) null;
      if (ost1 + ost2 > this.allost)
        return (int[]) null;
      int[] vectorSumWithBreak = new int[this.msiz];
      for (int index1 = 0; index1 < this.msiz; ++index1)
      {
        int index2 = this.fltr[index1];
        vectorSumWithBreak[index2] = cut1[index2] + cut2[index2];
        if (vectorSumWithBreak[index2] > this.kolzad[index2])
          return (int[]) null;
      }
      return vectorSumWithBreak;
    }
  }
}
