using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Collections;

namespace StockMarketExpService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStockExpService" in both code and config file together.
    [ServiceContract]
    public interface IStockExpService
    {
        [OperationContract]
        float[] GetValuesfromDB(Int32 highdays, String date,String sName);

        [OperationContract]
        List<StockName> GetComboValuesfromDB();

        [OperationContract]
        KeyValuePair<float, float> CalCulateAverage(Int32 lowerDay, Int32 highdays, float[] dbvalues);

        [OperationContract]
        int GetResult(float niftyvalue, float avg1, float avg2);

        [OperationContract]
        void importdatafromexcel(string filepath, string nameof, int status);

        [OperationContract]
        void releaseObject(object obj);

        [OperationContract]
        void createTable(string nameof);

        [OperationContract]
        void insertintotable(string date,float ClosingValue,string nameof);

        [OperationContract]
        void addStockName(string nameof);
    
    }
    public class StockName
    {
        public int ID { get; set; }
        public String SName { get; set; }

    }
 
}
