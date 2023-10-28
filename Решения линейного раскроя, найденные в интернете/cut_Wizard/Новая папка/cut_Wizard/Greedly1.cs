// Decompiled with JetBrains decompiler
// Type: OptimalCut.Greedly1
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;

namespace OptimalCut
{
  internal class Greedly1
  {
    private int W1 = 1250;
    private int msiz;
    private mathPosition[] zad;
    private int[] wth;
    private int[] kol;
    public int m_theSh;
    public int ultimate_pgm;

    public Greedly1(int conW, mathPosition[] pzad)
    {
      this.W1 = conW;
      this.msiz = pzad.Length;
      this.zad = new mathPosition[this.msiz];
      this.wth = new int[this.msiz + 1];
      this.kol = new int[this.msiz];
      for (int index = 0; index < this.msiz; ++index)
      {
        this.zad[index] = new mathPosition(pzad[index]);
        this.wth[index] = pzad[index].wth;
        this.kol[index] = pzad[index].kol;
      }
    }

    public Greedly1(Zadanie1 pzad)
    {
      this.W1 = pzad.W1;
      this.msiz = pzad.msiz;
      this.zad = new mathPosition[this.msiz];
      this.wth = new int[this.msiz + 1];
      this.kol = new int[this.msiz];
      for (int index = 0; index < this.msiz; ++index)
      {
        this.zad[index] = new mathPosition(pzad.zad[index]);
        this.wth[index] = pzad.zad[index].wth;
        this.kol[index] = pzad.zad[index].kol;
      }
    }

    public Answer1 GetAnswer()
    {
      this.m_theSh = 0;
      int scalerVectorVector = vaMatrix.Get_Scaler_Vector_Vector(this.wth, this.kol, this.msiz);
      List<AnswElem> answElemList = new List<AnswElem>();
      for (; scalerVectorVector > 0; scalerVectorVector = vaMatrix.Get_Scaler_Vector_Vector(this.wth, this.kol, this.msiz))
      {
        theCut pcut = theCut.NewCut_byGreedy(this.W1, this.msiz, this.wth, this.kol);
        int krAt = vaMatrix.GetKRAt(this.kol, pcut.vect, this.msiz);
        this.m_theSh += krAt;
        answElemList.Add(new AnswElem(pcut, krAt));
        this.kol = vaMatrix.GetVector_Sub_Vector_Vector(this.kol, vaMatrix.Get_Lyamda_Vector((double) krAt, pcut.vect, this.msiz), this.msiz);
      }
      answElemList.Sort((Comparison<AnswElem>) ((x, y) =>
      {
        if (x == null && y == null)
          return 0;
        if (x == null)
          return -1;
        return y == null ? 1 : x.CompareTo(y);
      }));
      this.ultimate_pgm = this.Get_ultimate_pgm(answElemList);
      return new Answer1(answElemList);
    }

    public int Get_ultimate_pgm(List<AnswElem> plist)
    {
      int ultimatePgm = 0;
      if (plist[plist.Count - 1].kra > 1)
        ultimatePgm = plist[plist.Count - 1].vect.pgm;
      else if (plist.Count > 1)
        ultimatePgm = plist[plist.Count - 2].vect.pgm;
      return ultimatePgm;
    }
  }
}
