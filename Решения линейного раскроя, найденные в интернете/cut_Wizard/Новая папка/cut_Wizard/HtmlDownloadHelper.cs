// Decompiled with JetBrains decompiler
// Type: OptimalCut.HtmlDownloadHelper
// Assembly: cut_Wizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00D3D541-1701-4C0A-A296-7857E1C33FB9
// Assembly location: C:\Users\8-bit\Desktop\cut_Wizard\cut_Wizard.exe

using System.IO;
using System.Net;
using System.Text;

namespace OptimalCut
{
  internal class HtmlDownloadHelper
  {
    public static string DownloadHtml(string uri, string reqString) => HtmlDownloadHelper.DownloadHtml(uri, Encoding.UTF8, reqString);

    public static string DownloadHtml(string uri, Encoding encoding, string reqString)
    {
      string str = "";
      byte[] bytes = encoding.GetBytes(reqString);
      HttpWebRequest httpWebRequest = WebRequest.Create(uri) as HttpWebRequest;
      httpWebRequest.Proxy = (IWebProxy) null;
      CookieContainer cookieContainer = new CookieContainer();
      httpWebRequest.CookieContainer = cookieContainer;
      httpWebRequest.KeepAlive = true;
      httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36";
      httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
      httpWebRequest.Headers.Set("Accept-Language", "ru-ru,ru;q=0.8,en-us;q=0.5,en;q=0.3");
      httpWebRequest.Headers.Set("Accept-Charset", "utf-8;q=0.7,*;q=0.7");
      httpWebRequest.ContentType = "application/x-www-form-urlencoded";
      httpWebRequest.Method = "POST";
      try
      {
        using (Stream requestStream = httpWebRequest.GetRequestStream())
          requestStream.Write(bytes, 0, bytes.Length);
        using (HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse())
          str = new StreamReader(response.GetResponseStream(), encoding).ReadToEnd();
      }
      catch
      {
      }
      return str;
    }

    public static string DownloadHtml2(string uri, string reqString) => HtmlDownloadHelper.DownloadHtml2(uri, Encoding.UTF8, reqString);

    public static string DownloadHtml2(string uri, Encoding encoding, string reqString)
    {
      string str = "";
      uri = uri + "?" + reqString;
      HttpWebRequest httpWebRequest = WebRequest.Create(uri) as HttpWebRequest;
      httpWebRequest.Proxy = (IWebProxy) null;
      CookieContainer cookieContainer = new CookieContainer();
      httpWebRequest.CookieContainer = cookieContainer;
      httpWebRequest.KeepAlive = true;
      httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36";
      httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
      httpWebRequest.Headers.Set("Accept-Language", "ru-ru,ru;q=0.8,en-us;q=0.5,en;q=0.3");
      httpWebRequest.Headers.Set("Accept-Charset", "utf-8;q=0.7,*;q=0.3");
      httpWebRequest.Method = "GET";
      try
      {
        using (HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse())
          str = new StreamReader(response.GetResponseStream(), encoding).ReadToEnd();
      }
      catch
      {
      }
      return str;
    }
  }
}
