using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upsploit.Tests;

namespace Upsploit {
    public partial class ResultsForm : Form {
        public ResultsForm(){
            InitializeComponent();
        }

        public void addTest(Test test){
            for (int i = 0; i < test.testName.Count; i++){
                ListViewItem row = new ListViewItem(test.testName[i]);
                row.Tag = test; //Set the test as the tag object so test details can pulled up again
                row.SubItems.Add(test.statusCode[i] + " " + test.reasonPhrase[i]);
                row.SubItems.Add(test.misc[i]);
                this.listView1.Items.Add(row);
            }

            //Adjust size of columns to fit the content
            this.columnHeader1.Width = -2;
            this.columnHeader2.Width = -2;
            this.columnHeader3.Width = -2;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e){
            if (listView1.SelectedItems.Count > 0){
                textBox2.Text = ((Test) listView1.SelectedItems[0].Tag).description;
                textBox1.Text = ((Test) listView1.SelectedItems[0].Tag).validation;
            }
        }
    }
}