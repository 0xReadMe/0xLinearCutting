// Decompiled with JetBrains decompiler
// Type: OptimalCut.ssCFG2
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OptimalCut
{
  internal class ssCFG2
  {
    private mCFG parent;
    private Zadanie1 parentzad;
    private List<theCut> parentPAC;
    private int msiz;
    private int W1;
    private int allost;
    private int minusSh;
    private int[] kol;
    private int[] zad2;

    public static bool OneIsBestThanTwo(List<AnswElem> one, List<AnswElem> two)
    {
      bool flag = one[one.Count - 1].vect.ost > two[two.Count - 1].vect.ost;
      if (one[one.Count - 1].vect.ost == two[two.Count - 1].vect.ost)
      {
        flag = one[one.Count - 1].kra > two[two.Count - 1].kra;
        if (one[one.Count - 1].kra == two[two.Count - 1].kra)
        {
          int num = Math.Min(one.Count, two.Count);
          for (int index = 0; index < num; ++index)
          {
            flag = one[index].vect.ost < two[index].vect.ost;
            if (one[index].vect.ost == two[index].vect.ost)
            {
              flag = one[index].kra > two[index].kra;
              if (one[index].kra != two[index].kra)
                return flag;
            }
            else
              break;
          }
        }
      }
      return flag;
    }

    public ssCFG2(mCFG pparent)
    {
      this.parent = pparent;
      this.parentzad = pparent.parentzad;
      this.parentPAC = pparent.parentPAC;
      this.msiz = this.parentzad.msiz;
      this.W1 = this.parentzad.W1;
    }

    private List<AnswElem> Get_find_Answ(AnswElem first, List<AnswElem> dop)
    {
      List<AnswElem> findAnsw = new List<AnswElem>();
      findAnsw.Add(first);
      foreach (AnswElem answElem in dop)
        findAnsw.Add(answElem);
      return findAnsw;
    }

    private bool CheckLimitVertex(int[] fltr)
    {
      bool flag = false;
      for (int index1 = 0; index1 < this.parent.prbm.Length; ++index1)
      {
        int index2 = this.parent.prbm[index1];
        if ((this.minusSh + 1) * this.parent.parentRow[index2].kolVetrex < fltr[index2])
        {
          flag = true;
          break;
        }
      }
      return flag;
    }

    private AnswElem GetFirst(double cm, int Naidx)
    {
      this.kol.CopyTo((Array) this.zad2, 0);
      return this.GetNextLimited(Naidx, cm, this.zad2);
    }

    private AnswElem GetNextLimited(int Naidx, double cm, int[] fltr)
    {
      for (int index = Naidx; index < this.parentPAC.Count && (double) this.parentPAC[index].ost <= cm + 1.0 && (this.parent.prbm.Length <= 0 || !this.CheckLimitVertex(fltr)); ++index)
      {
        int krAt = vaMatrix.GetKRAt(fltr, this.parentPAC[index].vect, this.msiz);
        if (krAt > 0)
          return new AnswElem(index, krAt, this.parent);
      }
      return (AnswElem) null;
    }

    private List<AnswElem> Get_Razgon1Result_xsh(AnswElem first, int xsh)
    {
      if (first == null)
        return (List<AnswElem>) null;
      if (first.kra < xsh - 1)
        return (List<AnswElem>) null;
      List<AnswElem> razgon1ResultXsh = new List<AnswElem>();
      if (first.kra == xsh)
        razgon1ResultXsh.Add(first);
      else if (first.kra == xsh - 1)
      {
        razgon1ResultXsh.Add(first);
        this.zad2 = vaMatrix.GetVector_Sub_Vector_Vector(this.zad2, vaMatrix.Get_Lyamda_Vector((double) first.kra, first.vect.vect, this.msiz), this.msiz);
        if (((IEnumerable<int>) this.zad2).Sum() > 0)
        {
          theCut pcut = this.parentzad.Do_shanker(this.zad2);
          razgon1ResultXsh.Add(new AnswElem(pcut, 1));
        }
      }
      return razgon1ResultXsh;
    }

    public double Get_cm(int aost, int ostShank, int minusSh) => ostShank <= 0 ? (double) this.allost / (double) (minusSh + 1) : (double) (this.allost - ostShank) / (double) minusSh;

    public List<AnswElem> Get_story2(int[] pkol, int aost, int Naidx = 0, int ostShank = 0)
    {
      if (this.parentzad.Get_pgm(pkol) + aost != 2 * this.W1)
        return (List<AnswElem>) null;
      this.kol = pkol;
      this.zad2 = new int[this.kol.Length];
      this.allost = aost;
      this.minusSh = 1;
      AnswElem first = this.GetFirst(this.Get_cm(this.allost, ostShank, this.minusSh), Naidx);
      if (first == null)
        return (List<AnswElem>) null;
      List<AnswElem> story2 = new List<AnswElem>();
      story2.Add(first);
      if (first.kra == 1)
      {
        this.zad2 = vaMatrix.GetVector_Sub_Vector_Vector(this.zad2, first.vect.vect, this.msiz);
        if (((IEnumerable<int>) this.zad2).Sum() > 0)
        {
          theCut pcut = this.parentzad.Do_shanker(this.zad2);
          story2.Add(new AnswElem(pcut, 1));
        }
      }
      return story2;
    }

    public List<AnswElem> Get_story3(int[] pkol, int aost, int Naidx = 0, int ostShank = 0)
    {
      if (this.parentzad.Get_pgm(pkol) + aost != 3 * this.W1)
        return (List<AnswElem>) null;
      this.kol = pkol;
      this.zad2 = new int[this.kol.Length];
      this.allost = aost;
      List<AnswElem> story3 = (List<AnswElem>) null;
      this.minusSh = 2;
      double cm = this.Get_cm(this.allost, ostShank, this.minusSh);
      AnswElem first = this.GetFirst(cm, Naidx);
      if (first == null)
        return (List<AnswElem>) null;
      if (first.kra > 1)
        return this.Get_Razgon1Result_xsh(first, 3);
      ssCFG2 ssCfG2 = new ssCFG2(this.parent);
      while ((double) first.vect.ost < cm + 1.0)
      {
        this.zad2 = vaMatrix.GetVector_Sub_Vector_Vector(this.kol, first.vect.vect, this.msiz);
        int aost1 = this.allost - first.vect.ost;
        List<AnswElem> story2 = ssCfG2.Get_story2(this.zad2, aost1, first.idxPAC + 1, ostShank);
        if (story2 != null)
        {
          List<AnswElem> findAnsw = this.Get_find_Answ(first, story2);
          if (story3 == null || story3[story3.Count - 1].vect.ost < findAnsw[findAnsw.Count - 1].vect.ost)
          {
            story3 = findAnsw;
            ostShank = story3[story3.Count - 1].vect.ost;
            cm = (double) (this.allost - ostShank) / (double) this.minusSh;
          }
        }
        first = this.GetFirst(cm, first.vect.idxPAC + 1);
        if (first != null)
        {
          if (first.kra > 1 && (story3 == null || story3[story3.Count - 1].vect.ost < first.vect.ost))
            return this.Get_Razgon1Result_xsh(first, 3);
        }
        else
          break;
      }
      return story3;
    }

    private void WorkR_FirstTheKra(
      ssCFG2 tmp2,
      int delta,
      AnswElem pfirst,
      ref List<AnswElem> locBest,
      ref int ostShank,
      ref double cm)
    {
      AnswElem first = pfirst;
      if (delta != 0)
      {
        first = new AnswElem(pfirst);
        first.kra += delta;
      }
      int[] vectorSubVectorVector = vaMatrix.GetVector_Sub_Vector_Vector(this.kol, vaMatrix.Get_Lyamda_Vector((double) first.kra, first.vect.vect, this.msiz), this.msiz);
      int aost = this.allost - first.vect.ost * first.kra;
      List<AnswElem> dop;
      switch (this.minusSh - first.kra)
      {
        case 0:
          dop = new List<AnswElem>();
          dop.Add(new AnswElem(new theCut(vectorSubVectorVector), 1));
          break;
        case 1:
          dop = tmp2.Get_story2(vectorSubVectorVector, aost, first.idxPAC + 1, ostShank);
          break;
        case 2:
          dop = tmp2.Get_story3(vectorSubVectorVector, aost, first.idxPAC + 1, ostShank);
          break;
        default:
          dop = tmp2.Get_storyR_null(vectorSubVectorVector, aost, this.minusSh - first.kra + 1, first.idxPAC + 1, ostShank);
          break;
      }
      if (dop == null)
        return;
      List<AnswElem> findAnsw = this.Get_find_Answ(first, dop);
      bool flag1 = locBest == null;
      if (ostShank > findAnsw[findAnsw.Count - 1].vect.ost)
        return;
      bool flag2 = !flag1 && ssCFG2.OneIsBestThanTwo(findAnsw, locBest);
      if (!flag1 && !flag2)
        return;
      locBest = findAnsw;
      ostShank = locBest[locBest.Count - 1].vect.ost;
      cm = (double) (this.allost - ostShank) / (double) this.minusSh;
    }

    public List<AnswElem> Get_storyR(int[] pkol, int aost = -1, int pSh = 0, int Naidx = 0, int ostShank = 0)
    {
      int aost1 = aost;
      int pSh1 = pSh;
      List<AnswElem> storyRNull;
      for (storyRNull = this.Get_storyR_null(pkol, aost, pSh, Naidx, ostShank); storyRNull == null && Naidx == 0; storyRNull = this.Get_storyR_null(this.kol, aost1, pSh1, Naidx, ostShank))
      {
        aost1 += this.W1;
        ++pSh1;
      }
      return storyRNull;
    }

    public List<AnswElem> Get_storyR_null(int[] pkol, int aost = -1, int pSh = 0, int Naidx = 0, int ostShank = 0)
    {
      int pgm = this.parentzad.Get_pgm(pkol);
      List<AnswElem> locBest = (List<AnswElem>) null;
      int xsh = pSh <= 0 ? this.parentzad.idealSheets : pSh;
      if (aost == -1)
        aost = xsh * this.W1 - pgm;
      this.kol = pkol;
      this.zad2 = new int[this.kol.Length];
      this.allost = aost;
      this.minusSh = xsh - 1;
      double cm = this.Get_cm(this.allost, ostShank, this.minusSh);
      AnswElem first = this.GetFirst(cm, Naidx);
      if (first == null)
        return (List<AnswElem>) null;
      if (first.kra > xsh - 2)
        return this.Get_Razgon1Result_xsh(first, xsh);
      ssCFG2 tmp2 = new ssCFG2(this.parent);
      while ((double) first.vect.ost < cm + 1.0)
      {
        int delta;
        for (delta = 0; first.kra + delta > 1; --delta)
        {
          this.WorkR_FirstTheKra(tmp2, delta, first, ref locBest, ref ostShank, ref cm);
          if ((double) first.vect.ost >= cm || this.parentzad.finish)
            break;
        }
        if ((double) first.vect.ost < cm)
          this.WorkR_FirstTheKra(tmp2, delta, first, ref locBest, ref ostShank, ref cm);
        first = this.GetFirst(cm, first.vect.idxPAC + 1);
        if (first != null)
        {
          if (first.kra > xsh - 2 && (locBest == null || locBest[locBest.Count - 1].vect.ost < first.vect.ost))
            return this.Get_Razgon1Result_xsh(first, xsh);
          Application.DoEvents();
          if (this.parentzad.finish)
            return locBest;
        }
        else
          break;
      }
      return locBest;
    }

    private void Drivers_FirstTheKra(
      ssCFG2 tmp2,
      int delta,
      AnswElem pfirst,
      ref List<AnswElem> locBest,
      ref int ostShank,
      ref double cm)
    {
      AnswElem first = pfirst;
      if (delta != 0)
      {
        first = new AnswElem(pfirst);
        first.kra += delta;
      }
      int[] vectorSubVectorVector = vaMatrix.GetVector_Sub_Vector_Vector(this.kol, vaMatrix.Get_Lyamda_Vector((double) first.kra, first.vect.vect, this.msiz), this.msiz);
      int aost = this.allost - first.vect.ost * first.kra;
      List<AnswElem> dop;
      switch (this.minusSh - first.kra)
      {
        case 0:
          dop = new List<AnswElem>();
          dop.Add(new AnswElem(new theCut(vectorSubVectorVector), 1));
          break;
        case 1:
          dop = tmp2.Get_story2(vectorSubVectorVector, aost, first.idxPAC + 1, ostShank);
          break;
        case 2:
          dop = tmp2.Get_story3(vectorSubVectorVector, aost, first.idxPAC + 1, ostShank);
          break;
        default:
          dop = tmp2.Get_drivers_null(vectorSubVectorVector, aost, this.minusSh - first.kra + 1, first.idxPAC + 1, ostShank);
          break;
      }
      if (dop == null)
        return;
      List<AnswElem> findAnsw = this.Get_find_Answ(first, dop);
      locBest = findAnsw;
      ostShank = locBest[locBest.Count - 1].vect.ost;
      cm = (double) (this.allost - ostShank) / (double) this.minusSh;
    }

    public List<AnswElem> Get_drivers(int[] pkol, int aost = -1, int pSh = 0, int Naidx = 0, int ostShank = 0)
    {
      List<AnswElem> driversNull = this.Get_drivers_null(pkol, aost, pSh, Naidx, ostShank);
      while (driversNull == null && Naidx == 0)
        driversNull = this.Get_drivers_null(this.kol, aost + this.W1, pSh + 1, Naidx, ostShank);
      return driversNull;
    }

    public List<AnswElem> Get_drivers_null(
      int[] pkol,
      int aost = -1,
      int pSh = 0,
      int Naidx = 0,
      int ostShank = 0)
    {
      int pgm = this.parentzad.Get_pgm(pkol);
      List<AnswElem> locBest = (List<AnswElem>) null;
      int xsh = pSh <= 0 ? this.parentzad.idealSheets : pSh;
      if (aost == -1)
        aost = xsh * this.W1 - pgm;
      this.kol = pkol;
      this.zad2 = new int[this.kol.Length];
      this.allost = aost;
      this.minusSh = xsh - 1;
      double cm = this.Get_cm(this.allost, ostShank, this.minusSh);
      AnswElem first = this.GetFirst(cm, Naidx);
      if (first == null)
        return (List<AnswElem>) null;
      if (first.kra > xsh - 2)
        return this.Get_Razgon1Result_xsh(first, xsh);
      ssCFG2 tmp2 = new ssCFG2(this.parent);
      while ((double) first.vect.ost < cm + 1.0)
      {
        int delta;
        for (delta = 0; first.kra + delta > 1; --delta)
        {
          this.Drivers_FirstTheKra(tmp2, delta, first, ref locBest, ref ostShank, ref cm);
          if (locBest != null || (double) first.vect.ost >= cm || this.parentzad.finish)
            break;
        }
        if ((double) first.vect.ost < cm)
          this.Drivers_FirstTheKra(tmp2, delta, first, ref locBest, ref ostShank, ref cm);
        if (locBest == null)
        {
          first = this.GetFirst(cm, first.vect.idxPAC + 1);
          if (first != null)
          {
            if (first.kra > xsh - 2 && locBest == null)
              return this.Get_Razgon1Result_xsh(first, xsh);
            Application.DoEvents();
            if (this.parentzad.finish)
              return locBest;
          }
          else
            break;
        }
        else
          break;
      }
      return locBest;
    }
  }
}
