// Decompiled with JetBrains decompiler
// Type: OptimalCut.AnswElem
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System.Collections.Generic;

namespace OptimalCut
{
  internal class AnswElem
  {
    private const char q = '"';
    private const char d = ':';
    private const char co = ',';
    private const string lf = "{";
    private const string rf = "}";
    private const string lb = "[";
    private const string rb = "]";
    public mCFG parent;
    public theCut mvect;
    public int idxPAC = -1;
    public int kra;

    public theCut vect => this.mvect;

    public static int Get_ShInList(List<AnswElem> otrj)
    {
      int shInList = 0;
      foreach (AnswElem answElem in otrj)
        shInList += answElem.kra;
      return shInList;
    }

    public static int Get_ShKra1InList(List<AnswElem> otrj)
    {
      int shKra1InList = 0;
      foreach (AnswElem answElem in otrj)
      {
        if (answElem.kra == 1)
          ++shKra1InList;
      }
      return shKra1InList;
    }

    public static int Get_ShKra24InList(List<AnswElem> otrj)
    {
      int shKra24InList = 0;
      foreach (AnswElem answElem in otrj)
      {
        if (answElem.kra > 1 && answElem.kra < 5)
          ++shKra24InList;
      }
      return shKra24InList;
    }

    public static int Get_ShKra5moreInList(List<AnswElem> otrj)
    {
      int shKra5moreInList = 0;
      foreach (AnswElem answElem in otrj)
      {
        if (answElem.kra > 5)
          shKra5moreInList += 2;
      }
      return shKra5moreInList;
    }

    public AnswElem(theCut pcut, int pkra)
    {
      this.mvect = pcut;
      this.kra = pkra;
    }

    public AnswElem(int pidx, int pkra, mCFG par)
    {
      this.idxPAC = pidx;
      this.kra = pkra;
      this.parent = par;
      this.mvect = this.parent.parentPAC[this.idxPAC];
    }

    public AnswElem(AnswElem pE)
    {
      this.mvect = pE.vect;
      this.kra = pE.kra;
      this.idxPAC = pE.idxPAC;
    }

    public int CompareTo(AnswElem compareEl)
    {
      int num = 1;
      return compareEl != null ? this.vect.CompareTo(compareEl.vect) : num;
    }

    public string ElemToJson() => "{" + (object) '"' + "vec" + (object) '"' + (object) ':' + this.VectToJson() + (object) ',' + (object) '"' + "kra" + (object) '"' + (object) ':' + this.kra.ToString() + "}";

    public string VectToJson()
    {
      string str = "[";
      foreach (int num in this.mvect.vect)
        str = str + num.ToString() + ",";
      return str + this.mvect.ost.ToString() + "]";
    }
  }
}
