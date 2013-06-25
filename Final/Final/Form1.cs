using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Collections.ObjectModel;
using Microsoft.PowerShell;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections;

namespace Final
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter dinkat;
        public Form1()
        {
            InitializeComponent();
            dinkat = new ListViewColumnSorter();
            listView1.ListViewItemSorter = dinkat;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            frmDescription.Text = textBox3.Text;
        }
        public void test()
        {

            PowerShell ps = PowerShell.Create();
            using (Runspace rs = RunspaceFactory.CreateRunspace())
            {
                rs.Open();
                ps.Runspace = rs;
                Pipeline pip = rs.CreatePipeline();
                pip.Commands.AddScript("get-service");
                //pip.Commands.Add("Format-List");
                Collection<PSObject> obj = pip.Invoke();
                rs.Close();
                string dinmor = "";
                foreach (PSObject ting in obj)
                {
                    var fff = ting.BaseObject;
                    
                     ListViewItem dinhest = new ListViewItem();
                     dinhest.SubItems.Add(ting.Properties["Status"].Value.ToString());
                    dinhest.SubItems.Add(ting.Properties["Name"].Value.ToString());
                    
                    dinhest.SubItems.Add(ting.Properties["DisplayName"].Value.ToString());
                    
                    listView1.Items.Add(dinhest);
                    //listView1.Items.Add(
                    //textBox7.AppendText(ting.Properties["DisplayName"].Value.ToString() + "\r\n");
                    
                }
                //MessageBox.Show(dinmor);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(frmFirstname.Text + " " + frmLastname.Text);
            test();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == dinkat.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (dinkat.Order == SortOrder.Ascending)
                {
                    dinkat.Order = SortOrder.Descending;
                }
                else
                {
                    dinkat.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                dinkat.SortColumn = e.Column;
                dinkat.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();

        }

        private void f(object sender, EventArgs e)
        {

        }
    }
}
