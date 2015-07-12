using System;
using System.Linq;
using System.Windows.Forms;
using Upsploit.Tests;
using Upsploit.UploadRequest;

namespace Upsploit{
    public partial class MainForm : Form{
        public MainForm(){
            InitializeComponent();
        }

        private void ManualForm_Load(object sender, EventArgs e){ 
            Console.SetOut(new TextBoxConsole(txtConsole));
        }

        private void selectAllButton_Click(object sender, EventArgs e){
            foreach (CheckBox c in Controls.OfType<CheckBox>()){
                c.Checked = true;
            }
        }

        private void selectNoneButton_Click(object sender, EventArgs e){
            foreach (CheckBox c in Controls.OfType<CheckBox>()){
                c.Checked = false;
            }
        }

        private async void runTestsButton_Click(object sender, EventArgs e){
            //Get the post request
            UploadRequest.UploadRequest request = getRequest(); //Gets an address from the user and parses it

            //Disable all the controls so the selection can't change (breaking things)
            enableControls(false);

            if (request != null){
                //Run the selected tests (backwards so they're in the right order)
                for (int i = Controls.Count-1; i > 0; i--){
                    CheckBox box = Controls[i] as CheckBox;
                    if (box != null && box.Checked){
                        await ((Test) box.Tag).runTest(request);
                    }
                }
                showResults();
            }
            enableControls(true);
        }

        private static UploadRequest.UploadRequest getRequest() {
            RequestForm form = new RequestForm();

            try {
                if (form.ShowDialog() == DialogResult.OK) {
                    return new UploadRequest.UploadRequest(form.textBox1.Text);
                }
            }
            catch (InvalidRequestException ex) {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        private void showResults() {
            ResultsForm form = new ResultsForm();

            //Add selected tests to the results panel
            foreach (Control c in from Control c in Controls where c is CheckBox && ((CheckBox)c).Checked select c) {
                form.addTest((Test)c.Tag);
            }
            form.Show();
        }

        //Toggle all checkboxes and select buttons to "state"
        private void enableControls(bool state){
            foreach (CheckBox c in Controls.OfType<CheckBox>()){
                c.Enabled = state;
            }

            selectAllButton.Enabled = state;
            selectNoneButton.Enabled = state;
            runTestsButton.Enabled = state;
        }
    }
}
