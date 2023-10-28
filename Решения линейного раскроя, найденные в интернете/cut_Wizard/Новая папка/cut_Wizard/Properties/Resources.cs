// Decompiled with JetBrains decompiler
// Type: OptimalCut.Properties.Resources
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace OptimalCut.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (OptimalCut.Properties.Resources.resourceMan == null)
          OptimalCut.Properties.Resources.resourceMan = new ResourceManager("OptimalCut.Properties.Resources", typeof (OptimalCut.Properties.Resources).Assembly);
        return OptimalCut.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => OptimalCut.Properties.Resources.resourceCulture;
      set => OptimalCut.Properties.Resources.resourceCulture = value;
    }
  }
}
