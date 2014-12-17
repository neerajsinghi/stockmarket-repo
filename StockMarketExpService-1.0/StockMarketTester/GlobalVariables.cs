using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using StockMarketTester.ServiceReference2;

namespace StockMarketTester
{
    class GlobalVariables
    {
        public static ArrayList message = new ArrayList();
        public static List<StockList> ListtoXls = new List<StockList>();
        public static float Cummulative = 0;
        public static float CummulativeSell = 0;
        public static Int32 Count=0;
        
    }
    public class StockList
    {
        public string Date { get; set; }
        public float Closing { get; set; }
        public float Average1 { get; set; }
        public float Average2 { get; set; }
        public string Result { get; set; }
        public float Differ { get; set; }
        public float CDiffer { get; set; }
        public int TCount { get; set; }
        public float TCDiffer { get; set; }

    }
    public class StockName
    {
        public int ID { get; set; }
        public String SName { get; set; }

    }
}
