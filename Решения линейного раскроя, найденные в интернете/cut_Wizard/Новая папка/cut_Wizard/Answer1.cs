// Decompiled with JetBrains decompiler
// Type: OptimalCut.Answer1
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;

namespace OptimalCut
{
  internal class Answer1
  {
    public int elemCount;
    public AnswElem[] answ;
    public AnswElem[] answByKra;
    public int msiz;
    public int[] Res1;
    public int shCount;
    public int allOst;
    public int ShankerOst;
    public int ShankerKra;
    public double razgon;

    public Answer1(List<AnswElem> ppa)
    {
      if (ppa == null)
        return;
      List<AnswElem> answElemList = this.forMerge(ppa);
      this.elemCount = answElemList.Count;
      if (this.elemCount == 0)
        return;
      this.Res1 = new int[this.msiz];
      this.answ = new AnswElem[this.elemCount];
      this.shCount = 0;
      this.allOst = 0;
      for (int index1 = this.elemCount - 1; index1 > -1; --index1)
      {
        this.answ[index1] = new AnswElem(answElemList[index1].vect, answElemList[index1].kra);
        this.shCount += answElemList[index1].kra;
        this.allOst += answElemList[index1].kra * answElemList[index1].vect.ost;
        for (int index2 = 0; index2 < this.msiz; ++index2)
          this.Res1[index2] += answElemList[index1].vect.vect[index2] * answElemList[index1].kra;
      }
      this.ShankerOst = this.answ[this.answ.Length - 1].vect.ost;
      this.ShankerKra = this.answ[this.answ.Length - 1].kra;
      this.razgon = this.GetRazgon();
    }

    public Answer1(Answer1 old)
    {
      if (old == null)
        return;
      this.elemCount = old.elemCount;
      if (this.elemCount == 0)
        return;
      this.msiz = old.msiz;
      this.Res1 = new int[this.msiz];
      this.answ = new AnswElem[this.elemCount];
      int num = 0;
      foreach (AnswElem answElem in old.answ)
      {
        this.answ[num++] = new AnswElem(answElem.vect, answElem.kra);
        for (int index = 0; index < this.msiz; ++index)
          this.Res1[index] += answElem.vect.vect[index] * answElem.kra;
      }
      this.shCount = old.shCount;
      this.allOst = old.allOst;
      this.ShankerOst = old.ShankerOst;
      this.ShankerKra = old.ShankerKra;
      this.razgon = old.razgon;
    }

    public List<AnswElem> forMerge(List<AnswElem> pa)
    {
      List<AnswElem> answElemList = new List<AnswElem>();
      this.elemCount = pa.Count;
      if (this.elemCount == 0)
        return answElemList;
      this.msiz = pa[0].vect.vect.Length;
      int num = 0;
      for (int index = 1; index < this.elemCount; ++index)
      {
        if (theCut.NoEquals(pa[index].vect, pa[index - 1].vect))
        {
          answElemList.Add(new AnswElem(pa[index - 1]));
          if (num != 0)
          {
            answElemList[answElemList.Count - 1].kra = num;
            num = 0;
          }
        }
        else if (num == 0)
          num = pa[index - 1].kra + pa[index].kra;
        else
          num += pa[index].kra;
      }
      answElemList.Add(new AnswElem(pa[pa.Count - 1]));
      if (num != 0)
        answElemList[answElemList.Count - 1].kra = num;
      return answElemList;
    }

    private double GetRazgon()
    {
      double d = 0.0;
      double num1 = (double) (this.allOst / this.shCount);
      int length = this.answ.Length;
      if (this.ShankerKra == 1 && this.shCount > 1)
      {
        num1 = (double) ((this.allOst - this.ShankerOst) / (this.shCount - 1));
        --length;
      }
      for (int index = 0; index < length; ++index)
      {
        AnswElem answElem = this.answ[index];
        double num2 = Math.Abs(num1 - (double) answElem.vect.ost);
        d += num2 * num2 * (double) answElem.kra;
      }
      return Math.Sqrt(d);
    }

    public bool IsBestThan(Answer1 oldBest)
    {
      if (this.elemCount == 0)
        return false;
      if (oldBest.Res1 != null)
      {
        for (int index = 0; index < this.msiz; ++index)
        {
          if (this.Res1[index] != oldBest.Res1[index])
            return false;
        }
      }
      bool flag = this.shCount < oldBest.shCount;
      if (this.shCount == oldBest.shCount)
      {
        flag = this.ShankerOst > oldBest.ShankerOst;
        if (this.ShankerOst == oldBest.ShankerOst)
        {
          flag = this.ShankerKra > oldBest.ShankerKra;
          if (this.answ[this.answ.Length - 1].kra == oldBest.answ[oldBest.answ.Length - 1].kra)
            flag = this.razgon > oldBest.razgon;
        }
      }
      return flag;
    }

    public void SortByKra()
    {
    }
  }
}
