// Decompiled with JetBrains decompiler
// Type: OptimalCut.matrBas
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OptimalCut
{
  internal class matrBas
  {
    private const double zeroLim = 1E-05;
    private mCFG parent;
    private Zadanie1 parentzad;
    private int msiz;
    private int[] kol;
    private int[] zad2;
    private List<int> col_idxPAC;
    private int[,] matr;
    private double[,] mobr;
    private int[] zado;
    private double[] mkra;
    private int worse;
    private int[] midxPAC;
    private int[,] resrv;
    private int oldworse;
    private double krim = -2147483647.0;
    private bool alreedyVertex;

    public int[,] matrEff => this.matr;

    public double[] KRA => this.mkra;

    public matrBas(mCFG pparent)
    {
      this.parent = pparent;
      this.parentzad = pparent.parentzad;
      this.msiz = this.parentzad.msiz;
      this.resrv = new int[this.msiz + 1, this.msiz + 1];
      this.matr = new int[this.msiz + 1, this.msiz + 1];
      this.midxPAC = new int[this.msiz + 1];
      for (int index = 0; index <= this.msiz; ++index)
        this.midxPAC[index] = -1;
      this.kol = this.parentzad.kol;
      this.col_idxPAC = new List<int>();
      byPart1ai byPart1ai = new byPart1ai(this.parent);
      int idealS = 0;
      int allO = 0;
      this.get_VertexBasis_minSh(mProc.DeleteOneForNeed(new ssCFG2(this.parent).Get_storyR(byPart1ai.Get2_Zad1(this.kol, ref idealS, ref allO), allO, idealS)));
    }

    public void set_Vertex_matr()
    {
      if (this.alreedyVertex)
        return;
      for (int index = 0; index < this.msiz; ++index)
      {
        this.matr[index, index] = this.parentzad.VectLim[index];
        this.matr[this.msiz, index] = this.parentzad.W1 - this.parentzad.VectLim[index] * this.parentzad.wth[index];
      }
      this.matr[this.msiz, this.msiz] = this.parentzad.W1;
      this.worse = this.msiz;
      this.alreedyVertex = true;
    }

    public void set_Clear_column(int num)
    {
      for (int index = 0; index < this.msiz; ++index)
        this.matr[index, num] = 0;
      this.matr[this.msiz, num] = this.parentzad.W1;
    }

    public void set_Vect_column(int num, theCut cut)
    {
      for (int index = 0; index < this.msiz; ++index)
        this.matr[index, num] = cut.vect[index];
      this.matr[this.msiz, num] = cut.ost;
    }

    public bool IsAlreadyTheCutCheck(theCut cut)
    {
      bool flag = false;
      for (int index1 = 0; index1 < this.msiz + 1; ++index1)
      {
        if (cut.ost == this.matr[this.msiz, index1])
        {
          flag = true;
          for (int index2 = 0; index2 < this.msiz; ++index2)
          {
            if (cut.vect[index2] != this.matr[index2, index1])
            {
              flag = false;
              break;
            }
          }
          if (flag)
          {
            this.midxPAC[index1] = cut.idxPAC;
            break;
          }
        }
      }
      return flag;
    }

    public void get_VertexBasis_minSh(List<AnswElem> collect)
    {
      if (!this.alreedyVertex)
      {
        this.set_Vertex_matr();
        this.zado = new int[this.msiz + 1];
        this.kol.CopyTo((Array) this.zado, 0);
        this.zado[this.msiz] = this.parentzad.Zad0.allost;
        this.oldworse = this.msiz;
      }
      this.col_idxPAC.Clear();
      foreach (AnswElem answElem in collect)
      {
        if (answElem.idxPAC > -1 && answElem.kra > 1)
          this.col_idxPAC.Add(answElem.idxPAC);
      }
      if (this.Go_vect_mkra())
      {
        this.worse = this.Get_Wrse_shieldedVertex(this.mobr, this.mkra);
        if (this.worse == -1)
          return;
      }
      int count = this.col_idxPAC.Count;
      for (int index = 0; index < count; ++index)
      {
        theCut cut = this.parent.parentPAC[this.col_idxPAC[index]];
        if (!this.IsAlreadyTheCutCheck(cut) && this.oneStepCheck(cut) && this.worse == -1)
          break;
      }
    }

    public bool oneStepCheck(theCut cut)
    {
      this.set_Vect_column(this.worse, cut);
      this.mobr = vaMatrix.Get_ObrtM(this.matr, this.msiz + 1);
      if (this.mobr == null)
        return false;
      this.mkra = vaMatrix.GetVector_Mult_doubleMatriza_Vector(this.mobr, this.msiz + 1, this.msiz + 1, this.zado);
      this.worse = this.Get_Wrse_shieldedVertex(this.mobr, this.mkra);
      if (this.worse > -1)
      {
        this.set_Clear_column(this.worse);
        this.Go_Matrix_msiz(cut.idxPAC);
      }
      else
        this.worse = -1;
      return true;
    }

    public void Go_Matrix_msiz(int currentPAC)
    {
      this.mobr = vaMatrix.Get_ObrtM(this.matr, this.msiz + 1);
      if (this.mobr == null)
        return;
      this.mkra = vaMatrix.GetVector_Mult_doubleMatriza_Vector(this.mobr, this.msiz + 1, this.msiz + 1, this.zado);
      if (this.krim < this.mkra[this.worse])
      {
        this.krim = this.mkra[this.worse];
        this.fromMatr_ToReserv();
        this.midxPAC[this.oldworse] = currentPAC;
        this.oldworse = this.worse;
      }
      else
      {
        this.fromReserv_ToMatr();
        this.worse = this.oldworse;
      }
    }

    public bool Go_vect_mkra()
    {
      this.mobr = vaMatrix.Get_ObrtM(this.matr, this.msiz + 1);
      if (this.mobr == null)
        return false;
      this.mkra = vaMatrix.GetVector_Mult_doubleMatriza_Vector(this.mobr, this.msiz + 1, this.msiz + 1, this.zado);
      return true;
    }

    public int Get_Wrse_shieldedVertex(double[,] mobr, double[] mkra, bool flag = false)
    {
      int wrseShieldedVertex = -1;
      double num1 = -1.0;
      for (int index = 0; index < this.msiz + 1; ++index)
      {
        if (mkra[index] < -1E-05)
        {
          if (mobr[index, this.msiz] >= 0.0)
          {
            if (mobr[index, this.msiz] > 0.0)
            {
              double num2 = Math.Abs(mkra[index]) / mobr[index, this.msiz];
              if (num2 > num1)
              {
                wrseShieldedVertex = index;
                num1 = num2;
              }
            }
            else if (flag)
            {
              wrseShieldedVertex = index;
              break;
            }
          }
        }
      }
      if (!flag && wrseShieldedVertex == -1)
        wrseShieldedVertex = this.Get_Wrse_shieldedVertex(mobr, mkra, true);
      return wrseShieldedVertex;
    }

    public void fromReserv_ToMatr()
    {
      for (int index1 = 0; index1 < this.msiz + 1; ++index1)
      {
        for (int index2 = 0; index2 < this.msiz + 1; ++index2)
          this.matr[index1, index2] = this.resrv[index1, index2];
      }
    }

    public void fromMatr_ToReserv()
    {
      for (int index1 = 0; index1 < this.msiz + 1; ++index1)
      {
        for (int index2 = 0; index2 < this.msiz + 1; ++index2)
          this.resrv[index1, index2] = this.matr[index1, index2];
      }
    }

    public Answer1 GetAnswer()
    {
      int num = (int) MessageBox.Show(vaMatrix.Show_Matrix(this.matr, this.msiz + 1, this.msiz + 1) + "\n\n" + vaMatrix.Show_Vector(this.mkra, this.msiz + 1));
      return (Answer1) null;
    }

    public int[] Get_numsIdxPAC_inMatr()
    {
      int[] numsIdxPacInMatr = new int[this.msiz + 1];
      this.midxPAC.CopyTo((Array) numsIdxPacInMatr, 0);
      return numsIdxPacInMatr;
    }

    private int Get_idxPAC_Vertex_fromMatrix(int num)
    {
      int vertexFromMatrix = -1;
      int[] kolzad = new int[this.msiz];
      for (int index = 0; index < this.msiz; ++index)
        kolzad[index] = this.matr[index, num];
      foreach (theCut theCut in this.parent.parentPAC)
      {
        if (vaMatrix.GetKRAt(kolzad, theCut.vect, this.msiz) > 0)
        {
          vertexFromMatrix = theCut.idxPAC;
          break;
        }
      }
      return vertexFromMatrix;
    }
  }
}
