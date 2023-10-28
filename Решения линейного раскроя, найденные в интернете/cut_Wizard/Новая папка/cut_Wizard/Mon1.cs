// Decompiled with JetBrains decompiler
// Type: OptimalCut.Mon1
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System;
using System.Collections.Generic;

namespace OptimalCut
{
  internal class Mon1
  {
    public const int pasw = 456123;
    private const int sme = 10;
    public static Random R = new Random();
    public static string strMonF = "95295";
    public static string strKStr = "";
    public static int pasw1 = 0;
    public static int expnum = 0;
    public static string sert = "";
    public static string sert678 = "";
    public static long dat1 = 0;
    private int idxF;
    private int idxKStr = 10;
    private int idxMonF = 20;
    private bool act1;

    public static void strKStr_plusTimes()
    {
      string str = Mon1.dat1.ToString().Substring(0, 4);
      Mon1.strKStr = (Convert.ToInt32(Mon1.strKStr) + Convert.ToInt32(str)).ToString();
    }

    public static string Get_JsonMathData(List<mathPosition> mathData)
    {
      string str = "{\"mathData\":[";
      foreach (mathPosition mathPosition in mathData)
        str = str + mathPosition.PositionToJson_math() + ",";
      return str.Substring(0, str.Length - 1) + "]}";
    }

    public static string Get_JsonUserData(List<mathPosition> UserData)
    {
      string str = "{\"UserData\":[";
      foreach (mathPosition mathPosition in UserData)
        str = str + mathPosition.PositionToJson_user() + ",";
      return str.Substring(0, str.Length - 1) + "]}";
    }

    public static string Get_ClosedJsonAnswer(AnswElem[] answ)
    {
      string str = "{\"jsonansw\":[";
      foreach (AnswElem answElem in answ)
        str = str + answElem.ElemToJson() + ",";
      return Mon1.Get_Cezar(str.Substring(0, str.Length - 1) + "]}");
    }

    private static string Get_Cezar(string jsonansw)
    {
      jsonansw = jsonansw.Replace("kra", "*");
      jsonansw = jsonansw.Replace("vec", "#");
      Cezar cezar = new Cezar();
      int int32 = Convert.ToInt32((int) Convert.ToChar(Mon1.strKStr[0]) - 48);
      return cezar.Codeс(jsonansw, int32);
    }

    public bool Value => this.act1;

    public Mon1() => this.act1 = this.act();

    public Mon1(int p1, int p2, int p3)
    {
      this.idxF = p1;
      this.idxKStr = p2;
      this.idxMonF = p3;
      this.act1 = this.act();
    }

    private bool act()
    {
      int v1 = 0;
      int v2 = 0;
      this.init(ref v1, ref v2);
      int num = v2 - v1;
      if (num > -11 && num < 0)
        return false;
      return num > -1 && num < 11 || Mon1.R.Next(-9, 9) > 0;
    }

    private void init(ref int v1, ref int v2)
    {
      v1 = Convert.ToInt32(Mon1.strKStr.Substring(this.idxF, 1));
      if (this.idxKStr != -1)
      {
        char ch = Convert.ToChar(Mon1.sert.Substring(v1 * 10, 1));
        v1 = Convert.ToInt32(ch);
      }
      v2 = Convert.ToInt32(Mon1.strMonF.Substring(this.idxF, 1));
      if (this.idxMonF == -1)
        return;
      char ch1 = Convert.ToChar(Mon1.sert.Substring(v2 * 10, 1));
      v2 = Convert.ToInt32(ch1);
    }

    public bool act2(int val) => Mon1.R.Next(0, 10) > 10 - val;
  }
}
