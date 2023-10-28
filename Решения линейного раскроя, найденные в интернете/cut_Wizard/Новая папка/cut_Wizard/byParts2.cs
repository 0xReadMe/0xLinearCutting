// Decompiled with JetBrains decompiler
// Type: OptimalCut.byParts2
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;

namespace OptimalCut
{
  internal class byParts2
  {
    public const int partLim = 8000;
    private mCFG parent;
    private Zadanie1 parentzad;
    private int msiz;
    private int W1;
    private int[] kol;
    private int[] zad1;
    private int idealSh1;
    private int aost1;
    private int[] zad2;
    private int idealSh2;
    private int aost2;
    private int idealSh;
    private int aost0;
    private double workload;

    public int pgm { get; set; }

    private double Get_workload(int[] pkol, int idealSheet, int allost)
    {
      double num = 0.0;
      for (int index = 0; index < this.msiz; ++index)
        num += (double) pkol[index] / (double) this.parentzad.wth[index];
      return num * (double) (this.parent.parentPAC.Count * idealSheet * idealSheet * allost / this.W1);
    }

    public byParts2(mCFG pparent)
    {
      this.parent = pparent;
      this.parentzad = this.parent.parentzad;
      this.msiz = this.parentzad.msiz;
      this.W1 = this.parentzad.W1;
      this.kol = this.parentzad.kol;
      this.idealSh = Convert.ToInt32(Math.Ceiling((double) this.parentzad.pgm / (double) this.W1));
      this.aost0 = this.idealSh * this.W1 - this.parentzad.pgm;
      this.zad1 = new int[this.msiz];
      this.zad2 = new int[this.msiz];
      this.kol.CopyTo((Array) this.zad2, 0);
      this.workload = this.Get_workload(this.kol, this.idealSh, this.aost0);
    }

    public byParts2(mCFG pparent, int[] pkol)
    {
      this.parent = pparent;
      this.parentzad = this.parent.parentzad;
      this.msiz = this.parentzad.msiz;
      this.W1 = this.parentzad.W1;
      this.kol = pkol;
      this.pgm = this.parentzad.Get_pgm(this.kol);
      this.idealSh = Convert.ToInt32(Math.Ceiling((double) this.pgm / (double) this.W1));
      this.aost0 = this.idealSh * this.W1 - this.pgm;
      this.zad1 = new int[this.msiz];
      this.zad2 = new int[this.msiz];
      this.kol.CopyTo((Array) this.zad2, 0);
      this.workload = this.Get_workload(this.kol, this.idealSh, this.aost0);
    }

    public int[] Get_Res1_fromList(List<AnswElem> coll)
    {
      int count = coll.Count;
      if (count == 0)
        return (int[]) null;
      int[] res1FromList = new int[this.msiz];
      for (int index1 = count - 1; index1 > -1; --index1)
      {
        for (int index2 = 0; index2 < this.msiz; ++index2)
          res1FromList[index2] += coll[index1].vect.vect[index2] * coll[index1].kra;
      }
      return res1FromList;
    }

    public List<AnswElem> DeleteOneForNeed(List<AnswElem> old)
    {
      if (old[old.Count - 1].kra == 1)
        old.RemoveAt(old.Count - 1);
      else
        --old[old.Count - 1].kra;
      return old;
    }

    public List<AnswElem> Get_sumParts()
    {
      List<AnswElem> sumParts;
      if (this.workload > 16000.0)
      {
        double num = 3.2;
        for (int index = 0; index < this.msiz; ++index)
          this.zad1[index] = (int) Math.Ceiling((double) this.kol[index] / num);
        this.Get_idealSh_aost_forZad1(this.zad1, ref this.idealSh1, ref this.aost1);
        sumParts = this.Get_workload(this.zad1, this.idealSh1, this.aost1) <= 8000.0 ? this.PrevEndStep(this.kol, this.zad1) : this.CreateNewByParts(this.kol, this.zad1);
      }
      else if (this.workload > 8000.0)
      {
        double num = 2.0;
        for (int index = 0; index < this.msiz; ++index)
          this.zad1[index] = (int) Math.Ceiling((double) this.kol[index] / num);
        this.Get_idealSh_aost_forZad1(this.zad1, ref this.idealSh1, ref this.aost1);
        sumParts = this.Get_workload(this.zad1, this.idealSh1, this.aost1) <= 8000.0 ? this.PrevEndStep(this.kol, this.zad1) : this.CreateNewByParts(this.kol, this.zad1);
      }
      else
        sumParts = this.TheEndStep(this.zad2, this.aost0, this.idealSh);
      return sumParts;
    }

    public void Get_idealSh_aost_forZad1(int[] tmpzad, ref int idealS, ref int allO)
    {
      int pgm = this.parentzad.Get_pgm(tmpzad);
      idealS = Convert.ToInt32(Math.Ceiling((double) pgm / (double) this.W1));
      allO = idealS * this.W1 - pgm;
    }

    public List<AnswElem> TheEndStep(int[] zad2, int allost, int idealSheet) => new ssCFG2(this.parent).Get_storyR(zad2, allost, idealSheet);

    public List<AnswElem> PrevEndStep(int[] fullkol, int[] zad1)
    {
      ssCFG2 ssCfG2 = new ssCFG2(this.parent);
      List<AnswElem> coll = this.DeleteOneForNeed(ssCfG2.Get_storyR(zad1, this.aost1, this.idealSh1));
      int[] res1FromList = this.Get_Res1_fromList(coll);
      this.zad2 = vaMatrix.GetVector_Sub_Vector_Vector(fullkol, res1FromList, this.msiz);
      this.Get_idealSh_aost_forZad1(this.zad2, ref this.idealSh2, ref this.aost2);
      List<AnswElem> answElemList = this.Get_workload(this.zad2, this.idealSh2, this.aost2) <= 8000.0 ? ssCfG2.Get_storyR(this.zad2, this.aost2, this.idealSh2) : new byParts2(this.parent, this.zad2).Get_sumParts();
      List<AnswElem> collecti = coll;
      foreach (AnswElem answElem in answElemList)
        collecti.Add(answElem);
      mCFG.ListSortByOst(collecti);
      return collecti;
    }

    public List<AnswElem> CreateNewByParts(int[] fullkol, int[] zad1)
    {
      List<AnswElem> coll = this.DeleteOneForNeed(new byParts2(this.parent, zad1).Get_sumParts());
      int[] res1FromList = this.Get_Res1_fromList(coll);
      this.zad2 = vaMatrix.GetVector_Sub_Vector_Vector(fullkol, res1FromList, this.msiz);
      List<AnswElem> sumParts = new byParts2(this.parent, this.zad2).Get_sumParts();
      List<AnswElem> collecti = coll;
      foreach (AnswElem answElem in sumParts)
        collecti.Add(answElem);
      mCFG.ListSortByOst(collecti);
      return collecti;
    }
  }
}
