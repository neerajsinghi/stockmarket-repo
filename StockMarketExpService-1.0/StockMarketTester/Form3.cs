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
using StockMarketTester.StockMarketExp;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace StockMarketTester
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            fillCombo();
        }
        void fillCombo()
        {
            StockExpServiceClient sClient2 = new StockExpServiceClient();
            var ListType = sClient2.GetComboValuesfromDB();
            foreach (var ele in ListType)
            {
                cbOld.Items.Add(ele.SName);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(cbNew.Checked)
                {
                     tbAddNew.Visible=true;
                     cbOld.Visible = false;
                }
            else
                {
                    tbAddNew.Visible= false;
                    cbOld.Visible = true;
                }
        }

        private void tbAddNew_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            int status = 0;
            if (cbNew.Checked && !tbAddNew.Text.Equals(""))
            {
                String dbname = tbAddNew.Text.ToString();
                if (!cbOld.Items.Contains(dbname.ToUpper()))
                {
                    status = 0;
                    StockExpServiceClient sClient2 = new StockExpServiceClient();
                    OpenFileDialog openfd = new OpenFileDialog();
                    openfd.Filter = "Excel Workbook|*.xls;*.xlsx";
                    DialogResult dr = openfd.ShowDialog();
                    String filepath = openfd.FileName;
                    if (!filepath.Equals("") && (filepath.EndsWith(".xls") || filepath.EndsWith(".xlsx")))
                    {
                        sClient2.importdatafromexcel(filepath, dbname, status);
                        this.Hide();
                        Form2 f2 = new Form2();
                        f2.ShowDialog();
                    }
                    else
                        MessageBox.Show("Please Select a Excel file");
                }
                else
                {
                    MessageBox.Show("Name already Exist");
                    tbAddNew.Clear();
                }
            }
            else if (cbNew.Checked && tbAddNew.Text.Equals(""))
                MessageBox.Show("Please Enter the name of The Share");
            else if (!cbNew.Checked && cbOld.Text.Equals("Select The Stock"))
                MessageBox.Show("Please Select a Stock");
            else
            {
                status = 1;
                String dbname2 = cbOld.SelectedItem.ToString();
                StockExpServiceClient sClient2 = new StockExpServiceClient();
                OpenFileDialog openfd = new OpenFileDialog();
                openfd.Filter = "Excel Workbook|*.xls;*.xlsx";
                DialogResult dr = openfd.ShowDialog();
                String filepath = openfd.FileName;
                if (!filepath.Equals("") && (filepath.EndsWith(".xls") || filepath.EndsWith(".xlsx")))
                {
                    sClient2.importdatafromexcel(filepath, dbname2, status);
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                }
                else
                    MessageBox.Show("Please Select a Excel file");
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
