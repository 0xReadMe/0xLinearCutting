// Decompiled with JetBrains decompiler
// Type: OptimalCut.Cezar
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System.Collections.Generic;

namespace OptimalCut
{
  internal class Cezar : List<Clent>
  {
    public Cezar()
    {
      this.Add(new Clent("efabcdghijklmnouvwxpqrstyz"));
      this.Add(new Clent("9801234576"));
      this.Add(new Clent("[:{$#,(*)}@\"]"));
    }

    public string Codeс(string m, int key)
    {
      string str1 = "";
      string str2 = "";
      for (int startIndex = 0; startIndex < m.Length; ++startIndex)
      {
        foreach (Clent clent in (List<Clent>) this)
        {
          str2 = clent.Repl(m.Substring(startIndex, 1), key);
          if (str2 != "")
          {
            str1 += str2;
            break;
          }
        }
        if (str2 == "")
          str1 += m.Substring(startIndex, 1);
      }
      return str1;
    }
  }
}
