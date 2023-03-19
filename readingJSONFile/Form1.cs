using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using readingJSONFile.Properties;
using System.Globalization;

namespace readingJSONFile

{
   
    public partial class Form1 : Form
    {


        private OpenFileDialog ofd;// to get open a file
        private string FileData;
            
        


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader FileText = new StreamReader(ofd.FileName);
                StreamReader FileText2 = new StreamReader(ofd.FileName);
                string line;
                string totalFile = "";
                string totalSecond = "";
                string totalText = "";
                string tot = "";
                int y = 0;
                while ((line = FileText.ReadLine()) != null)
                {
                    totalFile += pattern_search.findPatternPrimary(line);
                    totalSecond += pattern_search.findSecondaryPattern(line);
                }
               

                string[] tempFileArr = totalFile.Split(new char[] {':', '\"'});
                string[] fileArr = tempFileArr.Distinct().ToArray() ;

                string[] temp = totalSecond.Split(fileArr, fileArr.Length, StringSplitOptions.RemoveEmptyEntries);
                foreach (var x in temp)
                {
                    tot += x;
                }
                string[] fileArrSec = tot.Split(new char[] {':', ',', '\"', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[][] totalArr = new string[fileArr.Length][];
                
                   
                    

                    
                
                int rowIndex = 0; int columnIndex = 0;
                for (rowIndex = 0; rowIndex < totalArr.Length; rowIndex++)
                {
                    totalArr[rowIndex] = new string[fileArrSec.Length];
                }


                
                //string[][] totalArr = pattern_search.getMatchingLine(fileArr, fileArrSec);


                for ( int n = 0; n < totalArr.Length; n++)
                {
                    for (int k = 0;k < totalArr[n].Length; k++)
                    {
                        
                        totalText += totalArr[n][k] ;
                        
                    }
                }

                

                textBox1.Text = fileArrSec[1] ;

                string[] fileArray = fileArr.Distinct().ToArray();

                updateTableColumns(fileArray, totalArr);
                int stop = 0;
                //while ((line = FileText2.ReadLine()) != null)

                //for (int i = 0; i < fileArr.Length; i++)
                string[] str = new string[fileArr.Length + 1] ;
                        for (int j = 0; j < fileArrSec.Length; j++)
                        {
                            str[stop] = fileArrSec[j];
                            if (stop == fileArr.Length)
                            {
                                updateTableRows(str);
                                stop = 0;
                            }
                            stop++;
                        }
                    
                



            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void dataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataTable_ColumnAdded(object sender, DataColumnChangeEventArgs e)
        {
           

        }

        private void dataTable_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
           // dataTable.Columns[e.Column.Index].FillWeight = e.Column.FillWeight;
        }


        private void updateTableRows(string[] rowData)
        {
            dataTable.RowHeadersVisible = false;
            dataTable.Rows.Add(rowData);
           
        }

        private void updateTableColumns(string[] data, string[][] dataRows)
        {
            
            int i = data.Length ;
            
            dataTable.Columns.Clear();
            dataTable.BackgroundColor= Color.White;
            dataTable.ColumnCount = i;
            dataTable.RowHeadersVisible = false;
            string[] row = new string[dataRows.Length] ;
            

            for (int j = 0; j < i; j++)
            {
                dataTable.Columns[j].Name = data[j];
                dataTable.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                
            }
            dataTable.Columns.RemoveAt(0);

        }

    }
}
