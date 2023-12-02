using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS
{
   public static class ExtentionMethod
    {
      static int startIndex=0;
      static double baseLenProgressBar = 100;
       public static string AccessNullToShowValue(this string val)
       {
           return (val == "-1.#IND" ? "----" : val);
       }//GetNumberVal
       public static string ToNullInSystem(this string val)
       {
           if (val == "----" | val == "---" | val == "--" | val == "-" | val == "0" | string.IsNullOrWhiteSpace(val))
           {
               return "-1.#IND";
           }
           else
           {
           return    val;
           }
       }
       public static int EqualPanelLenghValue(this double ValPrameter, double baseLenPrameter)
       {
           if (baseLenPrameter==0)
           {
               return 0; 
           }
           else
           {
               return (int)((ValPrameter * baseLenProgressBar) / baseLenPrameter);
           }
       }
       public static int GetNumberVal(this string val)
       {
          
           try
           {
               return Convert.ToInt32(val.Substring(0, 2));
           }
           catch (Exception ex )
           {
              // new Exception ("error Convert GetNumberVal");
               return -1;
           }
       }

       public static int ToInteger(this string val)
       {
           if (val == "----" ) return 0;
           try
           {
               return (int)Convert.ToDouble(val);
           }
           catch (Exception)
           {

               return -1;
           }
       }
       public static double ToDouble(this string val)
       {
           if (val == "----") return 0;
           try
           {
               return Convert.ToDouble(val);
           }
           catch (Exception)
           {

               return -1;
           }
       }
       //public static string GetAfterTwoChar(this string val,string startParam)
       //{
       //    try
       //    {
       //        startIndex = (val.IndexOf("#" + startParam) + startParam.Length + 1);
       //        string remain = val.Substring(startIndex, val.Length - startIndex);
       //        string remain1 = remain.Substring(0, remain.IndexOf("#"));
       //        return remain1;

       //        //var startTag = "#" + startParam ;
       //        //int startIndex = val.IndexOf(startTag) + startTag.Length;
       //        //int endIndex = val.IndexOf("</" + tag + ">", startIndex);
       //        //return s.Substring(startIndex, endIndex - startIndex);
       //    }
       //    catch (Exception ex)
       //    {
       //        return "-1";
       //      //  throw ex;
       //    }

       //      //Substring(2, val.Length-2);
       //}


       public static string Between(this string src, string findfrom, string findto)
       {
           try
           {
               int start = src.IndexOf(findfrom);
               int to = src.IndexOf(findto, start + findfrom.Length);
               if (start < 0 || to < 0) return "-1";
               string s = src.Substring(
                              start + findfrom.Length,
                              to - start - findfrom.Length);
               return s;
           }
           catch (Exception)
           {
               
               throw;
           }

       }
    }
}
