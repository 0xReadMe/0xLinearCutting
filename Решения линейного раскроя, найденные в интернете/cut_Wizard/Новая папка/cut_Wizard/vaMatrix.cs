// Decompiled with JetBrains decompiler
// Type: OptimalCut.vaMatrix
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;

namespace OptimalCut
{
  internal class vaMatrix
  {
    private const double zeroLim = 1E-05;

    public static bool IsNoEqualsImmediately(int[] vec1, int[] vec2, int n)
    {
      for (int index = n - 1; index > -1; --index)
      {
        if (vec1[index] != vec2[index])
          return true;
      }
      return false;
    }

    public static string Show_Matrix(int[][] matr, int n, int k)
    {
      string str = "";
      for (int index1 = 0; index1 < n; ++index1)
      {
        for (int index2 = 0; index2 < k; ++index2)
          str = str + matr[index1][index2].ToString() + "  ";
        str += (string) (object) '\n';
      }
      return str;
    }

    public static string Show_Matrix(int[,] matr, int n, int k)
    {
      string str = "";
      if (matr != null)
      {
        for (int index1 = 0; index1 < n; ++index1)
        {
          for (int index2 = 0; index2 < k; ++index2)
            str = str + matr[index1, index2].ToString() + (object) '\t';
          str += (string) (object) '\n';
        }
      }
      return str;
    }

    public static string Show_Vector(int[] vect, int n)
    {
      string str = "";
      if (vect != null)
      {
        for (int index = 0; index < n; ++index)
          str = str + vect[index].ToString() + (object) '\t';
        str += (string) (object) '\n';
      }
      return str;
    }

    public static string Show_Vector(double[] vect, int n)
    {
      string str = "";
      if (vect != null)
      {
        for (int index = 0; index < n; ++index)
          str = str + Math.Round(vect[index], 1).ToString() + (object) '\t';
        str += (string) (object) '\n';
      }
      return str;
    }

    public static int[] GetVector_Sub_Vector_Vector(int[] vec1, int[] vec2, int n)
    {
      int[] vectorSubVectorVector = new int[n];
      for (int index = 0; index < n; ++index)
        vectorSubVectorVector[index] = vec1[index] - vec2[index];
      return vectorSubVectorVector;
    }

    public static int[] GetVector_Sum_Vector_Vector(int[] vec1, int[] vec2, int n)
    {
      int[] vectorSumVectorVector = new int[n];
      for (int index = 0; index < n; ++index)
        vectorSumVectorVector[index] = vec1[index] + vec2[index];
      return vectorSumVectorVector;
    }

    public static int Get_Scaler_Vector_Vector(int[] vec1, int[] vec2, int n)
    {
      int scalerVectorVector = 0;
      for (int index = 0; index < n; ++index)
        scalerVectorVector += vec1[index] * vec2[index];
      return scalerVectorVector;
    }

    public static int[] Get_Lyamda_Vector(double lyam, double[] vec, int n)
    {
      int[] lyamdaVector = new int[n];
      for (int index = 0; index < n; ++index)
        lyamdaVector[index] = Convert.ToInt32(vec[index] * lyam);
      return lyamdaVector;
    }

    public static int[] Get_Lyamda_Vector(double lyam, int[] vec, int n)
    {
      int[] lyamdaVector = new int[n];
      for (int index = 0; index < n; ++index)
        lyamdaVector[index] = Convert.ToInt32((double) vec[index] * lyam);
      return lyamdaVector;
    }

    public static int[] GetVector_Mult_Matriza_Vector(int[][] matr, int n, int k, int[] vec)
    {
      int[] multMatrizaVector = new int[n];
      for (int index1 = 0; index1 < n; ++index1)
      {
        multMatrizaVector[index1] = 0;
        for (int index2 = 0; index2 < k; ++index2)
          multMatrizaVector[index1] += matr[index1][index2] * vec[index2];
      }
      return multMatrizaVector;
    }

    public static double[] GetVector_Mult_doubleMatriza_Vector(
      double[,] matr,
      int n,
      int k,
      int[] vec)
    {
      double[] doubleMatrizaVector = new double[n];
      for (int index1 = 0; index1 < n; ++index1)
      {
        doubleMatrizaVector[index1] = 0.0;
        for (int index2 = 0; index2 < k; ++index2)
          doubleMatrizaVector[index1] += matr[index1, index2] * (double) vec[index2];
      }
      return doubleMatrizaVector;
    }

    public static int GetKRAt(int[] kolzad, int[] cut, int n)
    {
      int krAt = int.MaxValue;
      for (int index = 0; index < n; ++index)
      {
        if (cut[index] > 0)
        {
          int int32 = Convert.ToInt32(Math.Floor((double) kolzad[index] / (double) cut[index]));
          if (krAt > int32)
            krAt = int32;
          if (krAt < 1)
            return 0;
        }
      }
      return krAt;
    }

    public static int GetKRAt(int[] kolzad, int[] cut, int n, int allost, int ost)
    {
      int val1 = int.MaxValue;
      int val2 = int.MaxValue;
      for (int index = 0; index < n; ++index)
      {
        if (cut[index] > 0)
        {
          int int32 = Convert.ToInt32(Math.Floor((double) kolzad[index] / (double) cut[index]));
          if (val1 > int32)
            val1 = int32;
          if (val1 < 1)
            return 0;
        }
      }
      if (ost > 0)
        val2 = (int) Math.Floor((double) allost / (double) ost);
      return Math.Min(val1, val2);
    }

    public static int[,] Get_TransponirivMatriza(int[,] matrix, int n, int k)
    {
      int[,] transponirivMatriza = new int[k, n];
      for (int index1 = 0; index1 < k; ++index1)
      {
        for (int index2 = 0; index2 < n; ++index2)
          transponirivMatriza[index1, index2] = matrix[index2, index1];
      }
      return transponirivMatriza;
    }

    public static List<int[]> Get_TransponirivMatriza(int[][] matrix, int n, int k)
    {
      List<int[]> transponirivMatriza = new List<int[]>();
      for (int index1 = 0; index1 < k; ++index1)
      {
        int[] numArray = new int[n];
        for (int index2 = 0; index2 < n; ++index2)
          numArray[index2] = matrix[index2][index1];
        transponirivMatriza.Add(numArray);
      }
      return transponirivMatriza;
    }

    public static int Get_det_Bareis(int[,] pmatrix, int n)
    {
      int[,] copyToMatrix = vaMatrix.Get_CopyToMatrix(pmatrix, n, n);
      for (int index1 = 0; index1 < n - 1; ++index1)
      {
        int num1 = copyToMatrix[index1, index1];
        int num2;
        if (index1 == 0)
        {
          num2 = 1;
        }
        else
        {
          num2 = copyToMatrix[index1 - 1, index1 - 1];
          if (num2 == 0)
            return vaMatrix.Get_OM(pmatrix, n);
        }
        for (int index2 = index1 + 1; index2 < n; ++index2)
        {
          int num3 = copyToMatrix[index2, index1];
          for (int index3 = index1; index3 < n; ++index3)
            copyToMatrix[index2, index3] = (num1 * copyToMatrix[index2, index3] - num3 * copyToMatrix[index1, index3]) / num2;
        }
      }
      return copyToMatrix[n - 1, n - 1];
    }

    public static int Get_OM(int[,] matrix, int n)
    {
      if (n <= 1)
        return matrix[0, 0];
      int om = 0;
      for (int i = 0; i < n; ++i)
      {
        if (matrix[i, 0] != 0)
          om += matrix[i, 0] * vaMatrix.Get_ADM(matrix, n, i, 0);
      }
      return om;
    }

    public static int[,] Get_CopyToMatrix(int[,] pmatrix, int n, int k)
    {
      if (n == 0 || k == 0)
        return (int[,]) null;
      int[,] copyToMatrix = new int[n, k];
      for (int index1 = 0; index1 < n; ++index1)
      {
        for (int index2 = 0; index2 < k; ++index2)
          copyToMatrix[index1, index2] = pmatrix[index1, index2];
      }
      return copyToMatrix;
    }

    public static double[,] Get_double_CopyToMatrix(int[,] pmatrix, int n, int k)
    {
      if (n == 0 || k == 0)
        return (double[,]) null;
      double[,] doubleCopyToMatrix = new double[n, k];
      for (int index1 = 0; index1 < n; ++index1)
      {
        for (int index2 = 0; index2 < k; ++index2)
          doubleCopyToMatrix[index1, index2] = (double) pmatrix[index1, index2];
      }
      return doubleCopyToMatrix;
    }

    public static int Get_ADM(int[,] pmatrix, int n, int i, int j)
    {
      if (n == 0)
        return 0;
      int[,] matrix = new int[n - 1, n - 1];
      for (int index1 = 0; index1 < i; ++index1)
      {
        for (int index2 = 0; index2 < j; ++index2)
          matrix[index1, index2] = pmatrix[index1, index2];
        for (int index3 = j + 1; index3 < n; ++index3)
          matrix[index1, index3 - 1] = pmatrix[index1, index3];
      }
      for (int index4 = i + 1; index4 < n; ++index4)
      {
        for (int index5 = 0; index5 < j; ++index5)
          matrix[index4 - 1, index5] = pmatrix[index4, index5];
        for (int index6 = j + 1; index6 < n; ++index6)
          matrix[index4 - 1, index6 - 1] = pmatrix[index4, index6];
      }
      int adm = vaMatrix.Get_OM(matrix, n - 1);
      if ((i + j) % 2 == 1)
        adm = -adm;
      return adm;
    }

    public static double[,] Get_ObrtM(int[,] pmatrix, int n, double d = 0.0)
    {
      if (d == 0.0)
        d = (double) vaMatrix.Get_OM(pmatrix, n);
      if (Math.Abs(d) < 1E-05)
        return (double[,]) null;
      double[,] obrtM = new double[n, n];
      for (int j = 0; j < n; ++j)
      {
        for (int i = 0; i < n; ++i)
          obrtM[j, i] = (double) vaMatrix.Get_ADM(pmatrix, n, i, j) / d;
      }
      return obrtM;
    }
  }
}
