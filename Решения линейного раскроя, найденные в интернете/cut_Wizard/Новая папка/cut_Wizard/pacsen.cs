// Decompiled with JetBrains decompiler
// Type: OptimalCut.pacsen
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimalCut
{
  internal class pacsen
  {
    private Zadanie1 parent;
    public int ultimate_pgm;
    public double[] zad_vaotn;
    public int[] prbm;
    public List<theCut> parentPAC;
    public List<tPositi> parentRow;

    public int pgm_zad => this.parent.pgm;

    public int theSh => this.parent.Best.shCount;

    public pacsen(Zadanie1 pzad)
    {
      this.parent = pzad;
      this.zad_vaotn = new double[this.parent.msiz];
      for (int index = 0; index < this.parent.msiz; ++index)
        this.zad_vaotn[index] = (double) this.parent.kol[index] / (double) this.theSh;
      this.parentPAC = this.ps1_Get_parentPAC();
      this.parentRow = new List<tPositi>();
      for (int pN = 0; pN < this.parent.msiz; ++pN)
      {
        tPositi tPositi = new tPositi(pN, this.parent.wth[pN]);
        tPositi.Set_prbmVal(this.parent.W1, this.parent.kol[pN], this.parent.Cm0[this.parent.msiz]);
        this.parentRow.Add(tPositi);
      }
    }

    public void ListSortByOst(List<theCut> collecti)
    {
      if (collecti.Count <= 1)
        return;
      collecti.Sort((Comparison<theCut>) ((x, y) =>
      {
        if (x == null && y == null)
          return 0;
        if (x == null)
          return -1;
        return y == null ? 1 : x.CompareTo(y);
      }));
    }

    public void ListSortByOstAfterPrbm(List<theCut> collecti)
    {
      if (collecti.Count <= 1)
        return;
      collecti.Sort((Comparison<theCut>) ((x, y) =>
      {
        if (x == null && y == null)
          return 0;
        if (x == null)
          return -1;
        return y == null ? 1 : x.CompareToAfterPrbm(y);
      }));
    }

    public List<theCut> GetCopyListTheCut(List<theCut> collecti)
    {
      List<theCut> copyListTheCut = new List<theCut>();
      foreach (theCut theCut in collecti)
        copyListTheCut.Add(theCut);
      return copyListTheCut;
    }

    public void Set_Vertex(ref List<theCut> collecti, int[] vectlim)
    {
      int num = 0;
      for (int index = 0; index < collecti.Count; ++index)
      {
        if (num < collecti[index].ost)
          num = collecti[index].ost;
      }
      for (int index = 0; index < this.parent.msiz; ++index)
      {
        int[] pkol = new int[this.parent.msiz];
        pkol[index] = vectlim[index];
        theCut theCut = new theCut(pkol);
        if (theCut.ost > num)
          collecti.Add(theCut);
      }
    }

    public int[] Get_Maxiost(int[] vectlim)
    {
      int[] maxiost = new int[this.parent.msiz];
      maxiost[this.parent.msiz - 1] = this.parent.wth[this.parent.msiz - 1] * (vectlim[this.parent.msiz - 1] + 1);
      for (int index = this.parent.msiz - 2; index > -1; --index)
        maxiost[index] = maxiost[index + 1] <= this.parent.W1 ? this.parent.wth[index] * vectlim[index] + maxiost[index + 1] : maxiost[index + 1];
      return maxiost;
    }

    public int Get_minPositi(int[] vect)
    {
      if (((IEnumerable<int>) vect).Sum() <= 0)
        return -1;
      vect[this.parent.msiz - 1] = 0;
      int minPositi = this.parent.msiz - 2;
      for (int index = this.parent.msiz - 2; index > -1; --index)
      {
        if (vect[index] > 0)
        {
          minPositi = index;
          break;
        }
      }
      return minPositi;
    }

    public List<theCut> ps1_Get_parentPAC()
    {
      List<theCut> collecti = new List<theCut>();
      int[] maxiost = this.Get_Maxiost(this.parent.VectLim);
      int[] numArray = new int[this.parent.msiz];
      int index1 = 0;
      numArray[index1] = this.parent.VectLim[index1] + 1;
      while (index1 < this.parent.msiz - 1)
      {
        if (numArray[index1] > 0)
        {
          --numArray[index1];
          if (index1 < this.parent.msiz - 1)
          {
            int num = this.parent.W1 - vaMatrix.Get_Scaler_Vector_Vector(this.parent.wth, numArray, this.parent.msiz);
            if (num > maxiost[index1 + 1])
            {
              index1 = this.Get_minPositi(numArray);
              if (index1 >= 0)
                continue;
              break;
            }
            for (int index2 = index1 + 1; index2 < this.parent.msiz; ++index2)
            {
              numArray[index2] = Math.Min(num / this.parent.wth[index2], this.parent.kol[index2]);
              num = this.parent.W1 - vaMatrix.Get_Scaler_Vector_Vector(this.parent.wth, numArray, this.parent.msiz);
              if (index2 < this.parent.msiz - 1 && num > maxiost[index2 + 1] && this.Get_minPositi(numArray) < 0)
                break;
            }
          }
          theCut theCut = new theCut(numArray);
          if (theCut.pgm >= this.ultimate_pgm)
          {
            theCut.set_otn(this.zad_vaotn);
            collecti.Add(theCut);
          }
          index1 = this.Get_minPositi(numArray);
          if (index1 < 0)
            break;
        }
        else
          ++index1;
      }
      this.Set_Vertex(ref collecti, this.parent.VectLim);
      this.ListSortByOst(collecti);
      for (int index3 = 0; index3 < collecti.Count; ++index3)
        collecti[index3].idxPAC = index3;
      return collecti;
    }

    private int Get_idxCmIdeal(int theSh)
    {
      double num = (double) this.parent.W1 - (double) this.parent.pgm / (double) theSh;
      int idxCmIdeal = 0;
      foreach (theCut theCut in this.parentPAC)
      {
        if ((double) theCut.ost > num)
        {
          idxCmIdeal = theCut.idxPAC;
          break;
        }
      }
      return idxCmIdeal;
    }

    public void Set_Prbm()
    {
      List<double> doubleList = new List<double>();
      List<int> intList = new List<int>();
      for (int index = 0; index < this.parent.msiz; ++index)
      {
        if (!this.parent.Is_Golden(index) && !this.parentRow[index].Is_LessVertex)
        {
          doubleList.Add(this.parentRow[index].Get_PrbmVal);
          intList.Add(index);
        }
      }
      double[] array1 = doubleList.ToArray();
      int[] array2 = intList.ToArray();
      Array.Sort<double, int>(array1, array2);
      Array.Reverse((Array) array2);
      this.prbm = array2;
      foreach (int posi in this.prbm)
        this.set_LD_positi(posi);
    }

    public void set_LD_positi(int posi)
    {
      this.parentRow[posi].SetDr = new List<int>();
      int num1 = this.parentRow[posi].arr_SLD.Count - 1;
      for (int index = 0; index <= num1; ++index)
      {
        int num2 = this.parentRow[posi].arr_SLD[index];
        theCut theCut = this.parentPAC[num2];
        theCut.otn_prbm_all = (double) theCut.vect[posi] / (double) ((IEnumerable<int>) theCut.vect).Sum();
        if (theCut.sen[posi] > 0.0)
          this.SetDr_AddByRang(this.parentRow[posi].SetDr, num2);
      }
    }

    public void SetDr_AddByRang(List<int> pcollecti, int pidx)
    {
      if (pcollecti.Count == 0)
      {
        pcollecti.Add(pidx);
      }
      else
      {
        bool flag = false;
        double otnPrbmAll1 = this.parentPAC[pidx].otn_prbm_all;
        foreach (int index1 in pcollecti)
        {
          double otnPrbmAll2 = this.parentPAC[index1].otn_prbm_all;
          if (otnPrbmAll1 > otnPrbmAll2)
          {
            int index2 = pcollecti.IndexOf(index1);
            pcollecti.Insert(index2, pidx);
            flag = true;
            break;
          }
          if (otnPrbmAll1 == otnPrbmAll2)
          {
            if (this.parentPAC[pidx].Lim0 > this.parentPAC[index1].Lim0)
            {
              int index3 = pcollecti.IndexOf(index1);
              pcollecti.Insert(index3, pidx);
              flag = true;
              break;
            }
            if (this.parentPAC[pidx].Lim0 == this.parentPAC[index1].Lim0 && this.parentPAC[pidx].ost < this.parentPAC[index1].ost)
            {
              int index4 = pcollecti.IndexOf(index1);
              pcollecti.Insert(index4, pidx);
              flag = true;
              break;
            }
          }
        }
        if (flag)
          return;
        pcollecti.Add(pidx);
      }
    }

    public void set_SLD_positi()
    {
      for (int posi = 0; posi < this.parent.msiz; ++posi)
        this.set_SLD_positi(posi);
    }

    public void set_SLD_positi(int posi)
    {
      this.parentRow[posi].arr_SLD = new List<int>();
      for (int index = 0; index < this.parentPAC.Count; ++index)
      {
        theCut theCut = this.parentPAC[index];
        if (theCut.vect[posi] > 0)
          this.parentRow[posi].arr_SLD.Add(index);
        if (theCut.Is_DD(posi))
        {
          this.parentRow[posi].idx_DDend = index;
          break;
        }
      }
    }
  }
}
