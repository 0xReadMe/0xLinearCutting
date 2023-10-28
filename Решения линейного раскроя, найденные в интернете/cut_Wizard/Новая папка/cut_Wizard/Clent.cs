// Decompiled with JetBrains decompiler
// Type: OptimalCut.Clent
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

namespace OptimalCut
{
  internal class Clent
  {
    private string le;

    public Clent(string m) => this.le = m;

    public string Repl(string m, int key)
    {
      int num = this.le.IndexOf(m);
      if (num == -1)
        return "";
      int startIndex = (num + key) % this.le.Length;
      if (startIndex < 0)
        startIndex += this.le.Length;
      return this.le.Substring(startIndex, 1);
    }
  }
}
