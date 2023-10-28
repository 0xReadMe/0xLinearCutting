// Decompiled with JetBrains decompiler
// Type: OptimalCut.mCFG
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;

namespace OptimalCut
{
  internal class mCFG
  {
    private Zadanie1 pzad;
    private List<theCut> pPAC;
    private List<tPositi> pRow;
    private int[] pprbm;
    private Mon1 mon1;

    public Zadanie1 parentzad => this.pzad;

    public List<theCut> parentPAC => this.pPAC;

    public List<tPositi> parentRow => this.pRow;

    public int[] prbm => this.pprbm;

    public bool Exist_Prbm => this.pprbm != null;

    public bool Need_compress => this.pzad.theSh > this.pzad.idealSheets;

    public mCFG(Zadanie1 ppzad)
    {
      this.pzad = ppzad;
      this.pPAC = ppzad.mdCfg_links.parentPAC;
      this.pRow = ppzad.mdCfg_links.parentRow;
      this.pprbm = ppzad.mdCfg_links.prbm;
    }

    public mCFG(Zadanie1 ppzad, List<theCut> ppPAC, List<tPositi> ppRow, int[] pprb = null)
    {
      this.pzad = ppzad;
      this.pPAC = ppPAC;
      this.pRow = ppRow;
      this.pprbm = pprb;
      int num = 1;
      if (num >= Mon1.strKStr.Length)
        return;
      this.mon1 = new Mon1(num, Convert.ToInt32(Mon1.strKStr.Substring(num, 1)), 0);
    }

    public static void ListSortByOst(List<AnswElem> collecti)
    {
      if (collecti == null || collecti.Count == 0 || collecti.Count <= 1)
        return;
      collecti.Sort((Comparison<AnswElem>) ((x, y) =>
      {
        if (x == null && y == null)
          return 0;
        if (x == null)
          return -1;
        return y == null ? 1 : x.CompareTo(y);
      }));
    }

    public Answer1 GetAnswer(List<AnswElem> pa)
    {
      mCFG.ListSortByOst(pa);
      Answer1 newBest = new Answer1(pa);
      if (this.mon1.Value || this.mon1.act2(5))
        this.parentzad.GoBest(newBest);
      return newBest;
    }

    public bool the_is_prbm(int idx)
    {
      foreach (int num in this.pprbm)
      {
        if (num == idx)
          return true;
      }
      return false;
    }
  }
}
