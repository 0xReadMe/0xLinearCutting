// Decompiled with JetBrains decompiler
// Type: OptimalCut.tPositi
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;

namespace OptimalCut
{
  internal class tPositi
  {
    private int mnum;
    private double mwth;
    private double ostVertex;
    private bool is_Golden;
    private bool is_lessVertex;
    private double kwth;
    private double prbmval;
    public int kolVetrex;
    public int idx_DDend;
    public List<int> arr_SLD;
    public List<int> SetDr;

    public int num => this.mnum;

    public double wth => this.mwth;

    public bool Is_Golden => this.is_Golden;

    public bool Is_LessVertex => this.is_lessVertex;

    public double Get_PrbmVal => this.prbmval;

    public tPositi(int pN, int pW)
    {
      this.mnum = pN;
      this.mwth = (double) pW;
      this.idx_DDend = -2;
    }

    public void Set_prbmVal(int pW1, int koli, double cm0)
    {
      this.kolVetrex = (int) Math.Floor((double) pW1 / this.mwth);
      this.ostVertex = (double) pW1 % this.mwth;
      this.is_Golden = this.ostVertex <= cm0;
      this.kwth = this.ostVertex / (double) this.kolVetrex;
      this.prbmval = (double) koli * this.kwth;
      this.is_lessVertex = (double) koli < (double) pW1 / this.mwth;
    }
  }
}
