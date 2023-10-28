// Decompiled with JetBrains decompiler
// Type: OptimalCut.theCut
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;

namespace OptimalCut
{
  internal class theCut : IComparable<theCut>
  {
    private static Zadanie0 zad0;
    private static Zadanie1 zad10;
    public int pgm;
    public int ost;
    public int Lim0;
    private int msiz;
    public int[] vect;
    public double[] sen;
    public double otn_prbm_all;
    public int idxPAC = -1;

    public static Zadanie0 zadanie0
    {
      set => theCut.zad0 = value;
    }

    public theCut()
    {
    }

    public theCut(int[] pkol)
    {
      this.msiz = pkol.Length;
      this.vect = new int[this.msiz];
      pkol.CopyTo((Array) this.vect, 0);
      this.pgm = vaMatrix.Get_Scaler_Vector_Vector(theCut.zad0.wth, this.vect, this.msiz);
      this.ost = theCut.zad0.W1 - this.pgm;
      this.Lim0 = this.Get_Lim();
      this.sen = new double[this.msiz];
    }

    public bool Is_DD(int posi) => (this.Lim0 + 1) * this.vect[posi] > theCut.zad0.kol[posi];

    public int Get_Lim(int[] zad2 = null, int pallost = -1) => zad2 == null ? theCut.zad0.zad_compari.GetKRAt(this.vect, this.ost) : vaMatrix.GetKRAt(zad2, this.vect, this.msiz, pallost, this.ost);

    public double Get_Krit1(int ost, int[] zad2, int aost = -1)
    {
      int krAt = vaMatrix.GetKRAt(zad2, this.vect, this.msiz);
      return ((double) ost + 1.0) / (double) krAt;
    }

    public double Get_Krit2(int ost, int lim, int aost = -1) => ((double) ost + 1.0) / (double) lim / (double) lim;

    public void set_otn(double[] pzad_otn)
    {
      for (int index = 0; index < this.msiz; ++index)
        this.sen[index] = (double) this.vect[index] - pzad_otn[index];
    }

    public static bool NoEquals(theCut vec1, theCut vec2) => vec1.ost != vec2.ost || vec1.vect.Length != vec2.vect.Length || vaMatrix.IsNoEqualsImmediately(vec1.vect, vec2.vect, vec1.vect.Length);

    public int CompareTo(theCut compareCut)
    {
      int num = 1;
      if (compareCut != null)
      {
        if (this.ost < compareCut.ost)
          num = -1;
        else if (this.ost == compareCut.ost)
        {
          if (this.Lim0 > compareCut.Lim0)
            num = -1;
          else if (this.Lim0 == compareCut.Lim0)
          {
            for (int index = 0; index < this.msiz; ++index)
            {
              if (this.vect[index] > compareCut.vect[index])
              {
                num = -1;
                break;
              }
              if (this.vect[index] < compareCut.vect[index])
              {
                num = 1;
                break;
              }
            }
          }
        }
      }
      return num;
    }

    public int CompareToAfterPrbm(theCut compareCut)
    {
      int afterPrbm = 1;
      if (compareCut != null)
      {
        if (this.ost < compareCut.ost)
          afterPrbm = -1;
        else if (this.ost == compareCut.ost)
        {
          if (this.Lim0 > compareCut.Lim0)
            afterPrbm = -1;
          else if (this.Lim0 == compareCut.Lim0)
          {
            for (int index1 = 0; index1 < this.msiz; ++index1)
            {
              int index2 = theCut.zad10.mdCfg_links.prbm[index1];
              if (this.vect[index2] > compareCut.vect[index2])
              {
                afterPrbm = -1;
                break;
              }
              if (this.vect[index2] < compareCut.vect[index2])
              {
                afterPrbm = 1;
                break;
              }
            }
          }
        }
      }
      return afterPrbm;
    }

    public static theCut NewCut_byGreedy(int pW, int psiz, int[] pwth, int[] pkol)
    {
      theCut theCut = new theCut();
      theCut.vect = new int[psiz];
      int num1 = pW;
      for (int index = 0; index < psiz; ++index)
      {
        if (pkol[index] > 0 && num1 >= pwth[index])
        {
          int num2 = Math.Min(pkol[index], num1 / pwth[index]);
          if (num2 > 0)
          {
            theCut.vect[index] = num2;
            num1 -= num2 * pwth[index];
          }
        }
      }
      theCut.ost = num1;
      theCut.pgm = pW - num1;
      return theCut;
    }
  }
}
