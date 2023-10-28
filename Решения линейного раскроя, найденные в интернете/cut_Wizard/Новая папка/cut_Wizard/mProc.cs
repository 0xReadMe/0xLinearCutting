// Decompiled with JetBrains decompiler
// Type: OptimalCut.mProc
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;

namespace OptimalCut
{
  internal class mProc
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
    private int LimSh_forTmpPart1;
    private int[,] matr;

    public int pgm { get; set; }

    public mProc(mCFG pparent)
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
      this.workload = this.parentzad.Workload;
      this.LimSh_forTmpPart1 = this.parentzad.LimSh_forTmpOnePart;
    }

    public mProc(mCFG pparent, int[] pkol)
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
      this.workload = this.parentzad.Workload;
      this.LimSh_forTmpPart1 = this.parentzad.LimSh_forTmpOnePart;
    }

    public List<AnswElem> TheEndStep(int[] zad2, int allost, int idealSheet) => new ssCFG2(this.parent).Get_storyR(zad2, allost, idealSheet);

    public List<AnswElem> PrevEndStep()
    {
      this.zad1 = new byPart1ai(this.parent).Get1_Zad1(this.kol, this.LimSh_forTmpPart1);
      this.Get_idealSh_aost_forZad1(this.zad1, ref this.idealSh1, ref this.aost1);
      List<AnswElem> answElemList = mProc.DeleteOneForNeed(this.TheEndStep(this.zad1, this.aost1, this.idealSh1));
      int[] res1FromList = this.Get_Res1_fromList(answElemList);
      AnswElem.Get_ShInList(answElemList);
      this.zad2 = vaMatrix.GetVector_Sub_Vector_Vector(this.kol, res1FromList, this.msiz);
      this.Get_idealSh_aost_forZad1(this.zad2, ref this.idealSh2, ref this.aost2);
      foreach (AnswElem answElem in this.TheEndStep(this.zad2, this.aost2, this.idealSh2))
        answElemList.Add(answElem);
      mCFG.ListSortByOst(answElemList);
      this.Get_Res1_fromList(answElemList);
      AnswElem.Get_ShInList(answElemList);
      return answElemList;
    }

    public void Get_idealSh_aost_forZad1(int[] tmpzad, ref int idealS, ref int allO)
    {
      int pgm = this.parentzad.Get_pgm(tmpzad);
      idealS = Convert.ToInt32(Math.Ceiling((double) pgm / (double) this.W1));
      allO = idealS * this.W1 - pgm;
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

    public static List<AnswElem> DeleteOneForNeed(List<AnswElem> old)
    {
      if (old[old.Count - 1].kra == 1)
        old.RemoveAt(old.Count - 1);
      else
        --old[old.Count - 1].kra;
      return old;
    }

    public List<AnswElem> Get_sumParts()
    {
      if (this.parentzad.KoefPart >= 0.95)
        return this.TheEndStep(this.zad2, this.aost0, this.idealSh);
      return this.parentzad.KoefPart > 0.55 ? this.PrevEndStep() : this.complex_Basis_solution();
    }

    public List<AnswElem> complex_Basis_solution()
    {
      List<AnswElem> answElemList1 = (List<AnswElem>) null;
      matrBas basisZad = this.parentzad.BasisZad;
      if (basisZad != null)
      {
        this.matr = basisZad.matrEff;
        answElemList1 = this.Get_Pore(basisZad.Get_numsIdxPAC_inMatr(), basisZad.KRA);
        int[] res1FromList = this.Get_Res1_fromList(answElemList1);
        for (int shInList = AnswElem.Get_ShInList(answElemList1); shInList < this.idealSh - this.parentzad.LimSh_forTmpOnePart; shInList = AnswElem.Get_ShInList(answElemList1))
        {
          byPart1ai byPart1ai = new byPart1ai(this.parent);
          this.zad2 = vaMatrix.GetVector_Sub_Vector_Vector(this.kol, res1FromList, this.msiz);
          this.zad1 = byPart1ai.Get2_Zad1(this.zad2, ref this.idealSh1, ref this.aost1);
          List<AnswElem> collect = mProc.DeleteOneForNeed(this.TheEndStep(this.zad1, this.aost1, this.idealSh1));
          basisZad.get_VertexBasis_minSh(collect);
          answElemList1 = this.Get_Pore(basisZad.Get_numsIdxPAC_inMatr(), basisZad.KRA);
          res1FromList = this.Get_Res1_fromList(answElemList1);
        }
        this.zad2 = vaMatrix.GetVector_Sub_Vector_Vector(this.kol, res1FromList, this.msiz);
        this.Get_idealSh_aost_forZad1(this.zad2, ref this.idealSh2, ref this.aost2);
        List<AnswElem> answElemList2 = this.TheEndStep(this.zad2, this.aost2, this.idealSh2);
        if (answElemList2 != null)
        {
          foreach (AnswElem answElem in answElemList2)
            answElemList1.Add(answElem);
          mCFG.ListSortByOst(answElemList1);
          this.Get_Res1_fromList(answElemList1);
          AnswElem.Get_ShInList(answElemList1);
        }
      }
      return answElemList1;
    }

    public List<AnswElem> Get_Pore(int[] bmPACidx, double[] pkra)
    {
      List<AnswElem> pore = new List<AnswElem>();
      for (int index = 0; index <= this.msiz; ++index)
      {
        int num = (int) pkra[index];
        if (bmPACidx[index] > -1)
        {
          if (num > 2 && num < 4)
            pore.Add(new AnswElem(bmPACidx[index], num - 1, this.parent));
          else if (num > 3 && num < 11)
            pore.Add(new AnswElem(bmPACidx[index], num - 2, this.parent));
          else if (num > 10)
            pore.Add(new AnswElem(bmPACidx[index], num - 3, this.parent));
        }
      }
      return pore;
    }
  }
}
