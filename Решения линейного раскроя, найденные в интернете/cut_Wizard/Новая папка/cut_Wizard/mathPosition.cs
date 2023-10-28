// Decompiled with JetBrains decompiler
// Type: OptimalCut.mathPosition
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

namespace OptimalCut
{
  public class mathPosition
  {
    private const char q = '"';
    private const char d = ':';
    private const char co = ',';
    private const string lf = "{";
    private const string rf = "}";
    private const string lb = "[";
    private const string rb = "]";
    public static int minWth = 300;
    public int wth = mathPosition.minWth;
    public int kol;
    public int volum;
    public string comm1 = "";
    public bool No_enabled;

    public mathPosition(int pW, int pK, string pComm1 = "")
    {
      this.wth = pW;
      this.kol = pK;
      this.volum = this.wth * this.kol;
      this.comm1 = pComm1;
      if (!(this.comm1 != ""))
        return;
      this.comm1 = this.commJsonCorrect(this.comm1);
    }

    public mathPosition(mathPosition p)
    {
      this.wth = p.wth;
      this.kol = p.kol;
      this.volum = p.volum;
      this.comm1 = p.comm1;
      if (!(this.comm1 != ""))
        return;
      this.comm1 = this.commJsonCorrect(this.comm1);
    }

    public string commJsonCorrect(string comm1)
    {
      comm1 = comm1.Replace('{', ' ');
      comm1 = comm1.Replace('}', ' ');
      comm1 = comm1.Replace('[', ' ');
      comm1 = comm1.Replace(']', ' ');
      comm1 = comm1.Replace(',', ' ');
      comm1 = comm1.Replace(':', ' ');
      return comm1;
    }

    public string PositionToJson_user() => "{" + (object) '"' + "wth" + (object) '"' + (object) ':' + this.wth.ToString() + (object) ',' + (object) '"' + "kol" + (object) '"' + (object) ':' + this.kol.ToString() + (object) ',' + (object) '"' + "comm" + (object) '"' + (object) ':' + (object) '"' + this.comm1 + (object) '"' + "}";

    public string PositionToJson_math() => "{" + (object) '"' + "wth" + (object) '"' + (object) ':' + this.wth.ToString() + (object) ',' + (object) '"' + "kol" + (object) '"' + (object) ':' + this.kol.ToString() + "}";

    public int CompareTo(mathPosition compareEl)
    {
      int num = -1;
      if (compareEl != null && this.wth < compareEl.wth)
        num = 1;
      return num;
    }
  }
}
