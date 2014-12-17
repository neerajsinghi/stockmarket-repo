using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Collections;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace StockMarketExpService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StockExpService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StockExpService.svc or StockExpService.svc.cs at the Solution Explorer and start debugging.
    public class StockExpService : IStockExpService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="highdays"></param>
        /// <param name="date"></param>
        /// <param name="sName"></param>
        /// <returns></returns>
        public float[] GetValuesfromDB(Int32 highdays, String date,String sName)
        {
            float[] C_val = new float[highdays + 1];
            int i = 0;
            string connetionString = null;
            SqlConnection connection;
            connetionString = "Data Source=BOX\\NEER;Initial Catalog=stockHelper;Integrated Security=True";
            connection = new SqlConnection(connetionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("getdata", connection);
                cmd.Parameters.Add("@Highdays", SqlDbType.Int).Value = highdays;
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = date.Replace("\"", "'");
                cmd.Parameters.Add("@Sname", SqlDbType.NVarChar).Value = sName;
                cmd.Parameters.Add("@SnameID", SqlDbType.NVarChar).Value = sName + "ID"; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        C_val[i] = (float)Convert.ToDouble(reader["ClosingValue"]);
                        Console.WriteLine(C_val[i]);
                        i++;
                    }
                }
                cmd.ExecuteNonQuery();
            }
            return C_val;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<StockName> GetComboValuesfromDB()
        {
            List<StockName> C_val = new List<StockName>();
            string connetionString = null;
            SqlConnection connection;
            connetionString = "Data Source=BOX\\NEER;Initial Catalog=stockHelper;Integrated Security=True";
            connection = new SqlConnection(connetionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("getname", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        C_val.Add(new StockName{ ID = Convert.ToInt32(reader["TypeID"]), SName = reader["StockName"].ToString() });
                    }
                }
                cmd.ExecuteNonQuery();
            }
            return C_val;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowerDay"></param>
        /// <param name="highdays"></param>
        /// <param name="dbvalues"></param>
        /// <returns></returns>
        public KeyValuePair<float, float> CalCulateAverage(Int32 lowerDay, Int32 highdays, float[] dbvalues)
        {
            float average1 = 0;
            float average2 = 0;
            int i = 0;
            {
                for (; i < lowerDay; i++)
                {
                    average1 += dbvalues[i];
                }
                average2 += average1;
                for (; i < highdays; i++)
                {
                    average2 += dbvalues[i];
                }

            }
            average1 = average1 / lowerDay;
            average2 = average2 / highdays;
            return new KeyValuePair<float, float>(average1, average2);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="niftyvalue"></param>
        /// <param name="avg1"></param>
        /// <param name="avg2"></param>
        /// <returns></returns>
        public int GetResult(float niftyvalue, float avg1, float avg2)
        {
            if (niftyvalue > avg1)
            {
                return 1;

            }
            else if (niftyvalue < avg1 && niftyvalue < avg2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="nameof"></param>
        public void importdatafromexcel(string filepath,string nameof,int status)
          {
              if (status == 0)
              {
                  createTable(nameof);
                  addStockName(nameof);
              }
            Excel.Application xlApp ;
            Excel.Workbook xlWorkBook ;
            Excel.Worksheet xlWorkSheet ;
            Excel.Range range;
            object misValue = System.Reflection.Missing.Value;
            int rCnt = 0;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            int lastRow = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            for (rCnt = 2; rCnt <= lastRow; rCnt++)
            {
                System.Array MyValues = (System.Array)xlWorkSheet.get_Range("A" +
       rCnt.ToString(), "B" + rCnt.ToString()).Cells.Value;
                float Value2 = (float)Convert.ToDouble(MyValues.GetValue(1,2));
                string Value1 = MyValues.GetValue(1, 1).ToString();
                insertintotable(Value1, Value2, nameof);
            }
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Exception Occured while releasing object " + ex.ToString());

            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameof"></param>
        public void createTable(string nameof)
        {
            string connetionString = null;
            SqlConnection connection;
            connetionString = "Data Source=BOX\\NEER;Initial Catalog=stockHelper;Integrated Security=True";
            connection = new SqlConnection(connetionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("createTable", connection);
                cmd.Parameters.Add("@Sname", SqlDbType.NVarChar).Value = nameof;
                cmd.Parameters.Add("@SnameID", SqlDbType.NVarChar).Value = nameof + "ID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="ClosingValue"></param>
        /// <param name="nameof"></param>
        public void insertintotable(string date, float ClosingValue, string nameof)
        {
            string connetionString = null;
            SqlConnection connection;
            connetionString = "Data Source=BOX\\NEER;Initial Catalog=stockHelper;Integrated Security=True";
            connection = new SqlConnection(connetionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("insertTable", connection);
                cmd.Parameters.Add("@Stname", SqlDbType.VarChar).Value = nameof;
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = date;
                cmd.Parameters.Add("@Closingval", SqlDbType.Float).Value = ClosingValue;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameof"></param>
        public void addStockName(string nameof)
        {
            string connetionString = null;
            SqlConnection connection;
            connetionString = "Data Source=BOX\\NEER;Initial Catalog=stockHelper;Integrated Security=True";
            connection = new SqlConnection(connetionString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("insertintoSType", connection);
                cmd.Parameters.Add("@StoName", SqlDbType.NVarChar).Value = nameof;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
    
}
