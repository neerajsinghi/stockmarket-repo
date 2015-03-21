using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Collections;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using StockMarketTester.StockMarketExp;

namespace StockMarketTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fillCombo();
        }
        void fillCombo()
        {
            
            StockExpServiceClient sClient4 = new StockExpServiceClient();
            var ListType = sClient4.GetComboValuesfromDB();
            foreach (var ele in ListType)
            {
                cbChoices.Items.Add(ele.SName);
            }

        }
        private void cBRange_CheckedChanged(object sender, EventArgs e)
        {
            if (cBRange.Checked)
            {
                dPickDate2.Visible = true;
            }
            else
            {
                dPickDate2.Visible = false;
            }
        }
        private void Compare_Click(object sender, EventArgs e)
        {

            StockExpServiceClient sClient = new StockExpServiceClient();
            DateTime date1 = stockLastDate.Value;
            DateTime date2 = dPickDate2.Value;
            string date = stockLastDate.Value.ToString("yyyy-M-dd");
            int i= 1;
            TimeSpan difference = date2.Subtract(date1);
            int TDays = Convert.ToInt32(difference.TotalDays);
            if(cBRange.Checked)
            for (; TDays > 0; TDays--)
            {

                
                if (!minAverageTextBox.Text.Equals("") && !maxAverageTextBox.Text.Equals("") && !cbChoices.Text.Equals("Select"))
                {
                    Int32 lowerDays = Convert.ToInt32(minAverageTextBox.Text.Trim());
                    Int32 higherDays = Convert.ToInt32(maxAverageTextBox.Text.Trim());
                    string sname = cbChoices.SelectedItem.ToString();
                    string separator = " ";
                    if (lowerDays > 0 && higherDays > lowerDays)
                    {
                        float[] C_val = sClient.GetValuesfromDB(higherDays, date, sname);
                        if (C_val[0] != 0)
                        {
                            var pair = sClient.CalCulateAverage(lowerDays, higherDays, C_val);
                            float average1 = pair.Key;
                            float average2 = pair.Value;
                            int status = sClient.GetResult(C_val[0], average1, average2);
                            string[] msg1 = new string[] { "Average of ", lowerDays.ToString(), "is", average1.ToString(), "and", higherDays.ToString(), "is ", average2.ToString(), "\n" };

                            GlobalVariables.message.Add(string.Join(separator, msg1));
                            if (status == 1)
                            {
                                GlobalVariables.Cummulative = GlobalVariables.Cummulative + C_val[0] - C_val[1];
                                GlobalVariables.CummulativeSell = 0;
                                if (GlobalVariables.ListtoXls.Count != 0)
                                {
                                    var lstele = GlobalVariables.ListtoXls[GlobalVariables.ListtoXls.Count - 1];
                                    if (lstele.Result.ToString().Equals("Sell"))
                                    {
                                        GlobalVariables.Count++;
                                        string[] mag = new string[] { "Buy", "Nifty @", "Rs.", C_val[0].ToString(), "with Current Difference =", (C_val[0] - C_val[1]).ToString(), "\n and Cummulitive Difference =", GlobalVariables.Cummulative.ToString(), "\n" };
                                        GlobalVariables.message.Add(string.Join(separator, mag));
                                        GlobalVariables.ListtoXls.Add(new StockList { Date = date, Closing = C_val[0], Average1 = average1, Average2 = average2, Result = "Buy", Differ = C_val[0] - C_val[1], CDiffer = GlobalVariables.Cummulative, TCount = GlobalVariables.Count, TCDiffer = GlobalVariables.CummulativeSell });
                                        GlobalVariables.CummulativeSell = 0;

                                    }

                                    else
                                    {
                                        string[] mag = new string[] { "Buy", "Nifty @", "Rs.", C_val[0].ToString(), "with Current Difference =", (C_val[0] - C_val[1]).ToString(), "\n and Cummulitive Difference =", GlobalVariables.Cummulative.ToString(), "\n" };
                                        GlobalVariables.message.Add(string.Join(separator, mag));
                                        GlobalVariables.ListtoXls.Add(new StockList { Date = date, Closing = C_val[0], Average1 = average1, Average2 = average2, Result = "Buy", Differ = C_val[0] - C_val[1], CDiffer = GlobalVariables.Cummulative, TCount = GlobalVariables.Count, TCDiffer = 0 });
                                    }
                                }
                                else
                                {
                                    string[] mag = new string[] { "Buy", "Nifty @", "Rs.", C_val[0].ToString(), "with Current Difference =", (C_val[0] - C_val[1]).ToString(), "\n and Cummulitive Difference =", GlobalVariables.Cummulative.ToString(), "\n" };
                                    GlobalVariables.message.Add(string.Join(separator, mag));
                                    GlobalVariables.ListtoXls.Add(new StockList { Date = date, Closing = C_val[0], Average1 = average1, Average2 = average2, Result = "Buy", Differ = C_val[0] - C_val[1], CDiffer = GlobalVariables.Cummulative, TCount = GlobalVariables.Count, TCDiffer = 0 });

                                }
                            }
                            else
                            {
                                GlobalVariables.CummulativeSell += C_val[1] - C_val[0];
                                if (GlobalVariables.ListtoXls.Count != 0)
                                {
                                    var lstele = GlobalVariables.ListtoXls[GlobalVariables.ListtoXls.Count - 1];
                                    if (lstele.Result.ToString().Equals("Buy"))
                                    {
                                        GlobalVariables.Count++;
                                        string[] mag = new string[] { "Sell", "Nifty @", "Rs.", C_val[0].ToString(), "with Current Difference =", (C_val[0] - C_val[1]).ToString(), "\n and Cummulitive Difference =", GlobalVariables.CummulativeSell.ToString(), "\n" };
                                        GlobalVariables.message.Add(string.Join(separator, mag));
                                        GlobalVariables.ListtoXls.Add(new StockList { Date = date, Closing = C_val[0], Average1 = average1, Average2 = average2, Result = "Sell", Differ = C_val[0] - C_val[1], CDiffer = GlobalVariables.CummulativeSell, TCount = GlobalVariables.Count, TCDiffer = GlobalVariables.Cummulative });
                                        GlobalVariables.Cummulative = 0;
                                    }

                                    else
                                    {
                                        string[] mag = new string[] { "Sell", "Nifty @", "Rs.", C_val[0].ToString(), "with Current Difference =", (C_val[0] - C_val[1]).ToString(), "\n and Cummulitive Difference =", GlobalVariables.CummulativeSell.ToString(), "\n" };
                                        GlobalVariables.message.Add(string.Join(separator, mag));
                                        GlobalVariables.ListtoXls.Add(new StockList { Date = date, Closing = C_val[0], Average1 = average1, Average2 = average2, Result = "Sell", Differ = C_val[0] - C_val[1], CDiffer = GlobalVariables.CummulativeSell, TCount = GlobalVariables.Count, TCDiffer = 0 });
                                    }
                                }
                                else
                                {
                                    string[] mag = new string[] { "Buy", "Nifty @", "Rs.", C_val[0].ToString(), "with Current Difference =", (C_val[0] - C_val[1]).ToString(), "\n and Cummulitive Difference =", GlobalVariables.Cummulative.ToString(), "\n" };
                                    GlobalVariables.message.Add(string.Join(separator, mag));
                                    GlobalVariables.ListtoXls.Add(new StockList { Date = date, Closing = C_val[0], Average1 = average1, Average2 = average2, Result = "Buy", Differ = C_val[0] - C_val[1], CDiffer = GlobalVariables.Cummulative, TCount = GlobalVariables.Count, TCDiffer = 0 });

                                }
                                
                            }

                            foreach (var element in GlobalVariables.message)
                            {
                                rTBResults.AppendText(element.ToString());
                            }
                            GlobalVariables.message.Clear();
                        }
                    }
                }
                if (minAverageTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Please Enter Minimum Days");
                    break;
                }
                if (maxAverageTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Please Enter Maximum Days");
                    break;
                }
                if (cbChoices.Text.Equals("Select"))
                {
                    MessageBox.Show("Please Select a Stock");
                    break;
                }
                date1 = date1.AddDays(i);
                date = date1.ToString("yyyy-M-dd");
            }
            else
            {
                if (!minAverageTextBox.Text.Equals("") && !maxAverageTextBox.Text.Equals("") && !cbChoices.Text.Equals("Select"))
                {
                    Int32 lowerDays = Convert.ToInt32(minAverageTextBox.Text.Trim());
                    Int32 higherDays = Convert.ToInt32(maxAverageTextBox.Text.Trim());
                    string sname = cbChoices.SelectedItem.ToString();
                    string separator = " ";
                    if (lowerDays > 0 && higherDays > lowerDays)
                    {
                        float[] C_val = sClient.GetValuesfromDB(higherDays, date, sname);
                        var pair = sClient.CalCulateAverage(lowerDays, higherDays, C_val);
                        float average1 = pair.Key;
                        float average2 = pair.Value;
                        int status = sClient.GetResult(C_val[0], average1, average2);
                        string[] msg1 = new string[] { "Average of ", lowerDays.ToString(), "is", average1.ToString(), "and", higherDays.ToString(), "is ", average2.ToString(), "\n" };

                        string firsthalf = string.Join(separator, msg1);
                        GlobalVariables.message.Add(firsthalf);

                        if (status == 1)
                        {
                            GlobalVariables.Cummulative = GlobalVariables.Cummulative + C_val[0] - C_val[1];
                            var lstele = GlobalVariables.ListtoXls[GlobalVariables.ListtoXls.Count-1];
                            if(lstele.Result.ToString().Equals("Sell"))
                               GlobalVariables.Count++ ;
                            string[] mag = new string[] { "Buy", "Nifty @", "Rs.", C_val[0].ToString(), "with Current Difference =", (C_val[0] - C_val[1]).ToString(), "\n and Cummulitive Difference =", GlobalVariables.Cummulative.ToString(), "\n" };
                            string Secondhalf1 = string.Join(separator, mag);
                            GlobalVariables.message.Add(Secondhalf1);
                            GlobalVariables.ListtoXls.Add(new StockList { Date = date, Closing = C_val[0], Average1 = average1, Average2 = average2, Result = "Buy", Differ = C_val[0] - C_val[1], CDiffer = GlobalVariables.Cummulative });
                            GlobalVariables.CummulativeSell = 0;
                        }
                        else
                        {
                            GlobalVariables.Cummulative = 0;
                            GlobalVariables.CummulativeSell += C_val[0] - C_val[1];
                            var lstele = GlobalVariables.ListtoXls[GlobalVariables.ListtoXls.Count-1];
                            if(lstele.Result.ToString().Equals("Buy"))
                               GlobalVariables.Count++ ;
                            string[] mag = new string[] { "Sell", "Nifty @", "Rs.", C_val[0].ToString(), "with Difference=", (C_val[1] - C_val[0]).ToString(), "\n" };
                            GlobalVariables.message.Add(string.Join(separator, mag));
                            GlobalVariables.ListtoXls.Add(new StockList { Date = date, Closing = C_val[0], Average1 = average1, Average2 = average2, Result = "Sell", Differ = C_val[1] - C_val[0], CDiffer = GlobalVariables.CummulativeSell, TCount = GlobalVariables.Count });
                        }

                        foreach (var element in GlobalVariables.message)
                        {
                            rTBResults.AppendText(element.ToString());
                        }
                        GlobalVariables.message.Clear();
                    }
                }
                if (cbChoices.Text.Equals("Select"))
                {
                    MessageBox.Show("Please Select a Stock");

                }
                if (minAverageTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Please Enter Minimum Days");
                   
                }
                if (maxAverageTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Please Enter Maximum Days");
                   
                }
               
        }


        }
        private void rBClear_CheckedChanged(object sender, EventArgs e)
        {
            
            rTBResults.Clear();
            rBClear.Checked = false;
           GlobalVariables.ListtoXls.Clear();
        }

        private void btnSavefile_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file name from the saveFileDialog. 
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                rTBResults.SaveFile(saveFile1.FileName);
            }
        }

        private void btnSaveXls_Click(object sender, EventArgs e)
        {

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }


            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "Date";
            xlWorkSheet.Cells[1, 2] = "Closing Value";
            xlWorkSheet.Cells[1, 3] = "Average1" ;
            xlWorkSheet.Cells[1, 4] = "Average2";
            xlWorkSheet.Cells[1, 5] = "Result";
            xlWorkSheet.Cells[1, 6] = "Difference";
            xlWorkSheet.Cells[1, 7] = "Cummulative Difference";
            xlWorkSheet.Cells[1, 8] = "Transaction Count";
            xlWorkSheet.Cells[1, 9] = "Total Cummulative Difference";

            int i = 2;
            foreach(var lis in GlobalVariables.ListtoXls)
            {
                xlWorkSheet.Cells[i, 1] = lis.Date;
                xlWorkSheet.Cells[i, 2] = lis.Closing;
                xlWorkSheet.Cells[i, 3] = lis.Average1;
                xlWorkSheet.Cells[i, 4] = lis.Average2;
                xlWorkSheet.Cells[i, 5] = lis.Result;
                xlWorkSheet.Cells[i, 6] = lis.Differ;
                xlWorkSheet.Cells[i, 7] = lis.CDiffer;
                xlWorkSheet.Cells[i, 8] = lis.TCount;
                xlWorkSheet.Cells[i, 9] = lis.TCDiffer;
                i++;

            }
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveFile1.DefaultExt = "*.xls";
            saveFile1.Filter = "Excel Workbook|*.xls";

            // Determine whether the user selected a file name from the saveFileDialog. 
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                xlWorkBook.SaveAs(saveFile1.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
       }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        

      

       
  }
    
}
