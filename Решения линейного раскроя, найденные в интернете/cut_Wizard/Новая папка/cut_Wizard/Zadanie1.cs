// Decompiled with JetBrains decompiler
// Type: OptimalCut.Zadanie1
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OptimalCut
{
  internal class Zadanie1
  {
    public const int sekundaLim = 15;
    public bool finish;
    private Answer1 best;
    private int aost;
    private int ultimate_pgm;
    private theWorkload workload;
    private Zadanie0 zad0;
    private Vcomparison compari;
    public bool primitive;
    private pacsen pase;
    private mCFG mdCfg;
    private matrBas basis;

    public Answer1 Best => this.best;

    public int theSh => this.best.shCount;

    public int allost => this.aost;

    public int ultimatePgm => this.ultimate_pgm;

    public Zadanie0 Zad0 => this.zad0;

    public int W1 => this.zad0.W1;

    public int msiz => this.zad0.msiz;

    public int[] wth => this.zad0.wth;

    public int[] kol => this.zad0.kol;

    public mathPosition[] zad => this.zad0.zad;

    public bool IsBig => this.zad0.IsBig;

    public int pgm => this.zad0.pgm;

    public double[] Cm0 => this.zad0.Cm0;

    public bool Is_Golden(int ppos) => this.zad0.Is_Golden(ppos);

    public bool Is_arrivedIdeal => this.zad0.Is_arrivedIdeal;

    public double Workload => this.workload.Workload;

    public int LimSh_forTmpOnePart => this.workload.LimSh_forTmpOnePart;

    public double KoefPart => this.workload.KoefPart;

    public Vcomparison zad0_compari => this.zad0.zad_compari;

    public Vcomparison zad_compari => this.compari == null ? this.zad0_compari : this.compari;

    public int idealSheets => this.zad0.idealSheets;

    public int GreedlySh => this.zad0.GreedlySh;

    public int[] VectLim => this.zad0.VectLim;

    public mCFG mdCfg_links => this.mdCfg;

    public matrBas BasisZad => this.basis;

    public Zadanie1(int pW, string pwth, string pkol)
    {
      if (pwth == "" || pkol == "")
      {
        this.best = (Answer1) null;
      }
      else
      {
        this.zad0 = new Zadanie0(pW, pwth, pkol);
        if (this.zad0 == null || this.zad0.msiz <= 0)
          return;
        this.GoBest(this.zad0.GreedyAnswer);
        this.ultimate_pgm = this.zad0.ultimatePgm;
        if (this.ultimate_pgm < this.W1 - this.wth[this.msiz - 1])
          this.ultimate_pgm = this.W1 - this.wth[this.msiz - 1];
        if (this.pgm <= this.W1 || this.msiz < 2)
        {
          this.primitive = true;
        }
        else
        {
          this.compari = new Vcomparison(this.kol, this.aost);
          this.Create_pase();
          this.mdCfg = new mCFG(this, this.pase.parentPAC, this.pase.parentRow, this.pase.prbm);
          this.workload = new theWorkload(this.mdCfg);
          if (this.workload.KoefPart >= 0.55)
            return;
          this.basis = new matrBas(this.mdCfg);
        }
      }
    }

    public Zadanie1(int pW, int[] pwth, int[] pkol)
    {
      if (pwth == null || pkol == null || pwth.Length == 0 || pwth.Length != pkol.Length)
      {
        this.best = (Answer1) null;
      }
      else
      {
        this.zad0 = new Zadanie0(pW, pwth, pkol);
        if (this.zad0 == null)
          return;
        this.GoBest(this.zad0.GreedyAnswer);
        this.ultimate_pgm = this.zad0.ultimatePgm;
        if (this.ultimate_pgm < this.W1 - this.wth[this.msiz - 1])
          this.ultimate_pgm = this.W1 - this.wth[this.msiz - 1];
        if (this.pgm <= this.W1 || this.msiz < 2)
        {
          this.primitive = true;
        }
        else
        {
          this.compari = new Vcomparison(this.kol, this.aost);
          this.Create_pase();
          this.mdCfg = new mCFG(this, this.pase.parentPAC, this.pase.parentRow, this.pase.prbm);
          this.workload = new theWorkload(this.mdCfg);
          if (this.workload.KoefPart >= 0.55)
            return;
          this.basis = new matrBas(this.mdCfg);
        }
      }
    }

    public Zadanie1(int pW, mathPosition[] pzad)
    {
      if (pzad.Length == 0)
      {
        this.best = (Answer1) null;
      }
      else
      {
        this.zad0 = new Zadanie0(pW, pzad);
        if (this.zad0 == null)
          return;
        this.GoBest(this.zad0.GreedyAnswer);
        this.ultimate_pgm = this.zad0.ultimatePgm;
        if (this.ultimate_pgm < this.W1 - this.wth[this.msiz - 1])
          this.ultimate_pgm = this.W1 - this.wth[this.msiz - 1];
        if (this.pgm <= this.W1 || this.msiz < 2)
        {
          this.primitive = true;
        }
        else
        {
          this.compari = new Vcomparison(this.kol, this.aost);
          this.Create_pase();
          this.mdCfg = new mCFG(this, this.pase.parentPAC, this.pase.parentRow, this.pase.prbm);
          this.workload = new theWorkload(this.mdCfg);
          if (this.workload.KoefPart >= 0.55)
            return;
          this.basis = new matrBas(this.mdCfg);
        }
      }
    }

    private void Create_pase()
    {
      theCut.zadanie0 = this.zad0;
      this.pase = new pacsen(this);
      this.pase.set_SLD_positi();
      this.pase.Set_Prbm();
    }

    public mCFG Create_mCFG_2(List<theCut> ppPAC)
    {
      List<tPositi> ppRow = (List<tPositi>) null;
      return new mCFG(this, ppPAC, ppRow, this.mdCfg.prbm);
    }

    public void GoBest(Answer1 newBest)
    {
      if (newBest == null || this.best != null && !newBest.IsBestThan(this.best))
        return;
      this.best = newBest;
      this.aost = this.theSh * this.W1 - this.pgm;
    }

    public theCut Do_shanker(int[] z2vect) => new theCut(z2vect);

    public theCut Do_shanker(int[] z2vect, ref int sumkol)
    {
      theCut theCut = this.Do_shanker(z2vect);
      sumkol += ((IEnumerable<int>) z2vect).Sum();
      return theCut;
    }

    public int Get_pgm(int[] zad2) => this.zad0.Get_pgm(zad2);

    public bool Need_compress()
    {
      if (this.theSh != this.idealSheets)
        return true;
      int num = (int) MessageBox.Show("В BEST достигнут  theSh=" + this.idealSheets.ToString());
      return false;
    }

    public bool Exist_prbm()
    {
      if (this.pase.prbm != null && this.pase.prbm.Length != 0)
        return true;
      int num = (int) MessageBox.Show("Проблемы отсутствуют !  prbm = null");
      return false;
    }
  }
}
