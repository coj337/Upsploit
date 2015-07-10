using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Upsploit.Tests;
using Upsploit.UploadRequest;

namespace Upsploit{
    public partial class MainForm : Form{
        List<Test> tests = new List<Test>();

        public MainForm(){
            InitializeComponent();
        }

        private void ManualForm_Load(object sender, EventArgs e){
            tests = getTests();            

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

        private async void runTestsButton_Click(object sender, EventArgs e) {
            //Get the post request
            UploadRequest.UploadRequest request = getRequest(); //Gets an address from the user and parses it

            if (request != null) {
                int i = 0;
                //The controls collection is returned in whatever order the code creates them (backwards, usually) - This is sorted so the boxes are correlated with the right tests.
                IOrderedEnumerable<Control> orderedCheckBoxes = from n in Controls.Cast<Control>()
                                                                where n is CheckBox
                                                                orderby n.Name
                                                                select n;
                //Run the tests
                foreach (CheckBox c in orderedCheckBoxes.Cast<CheckBox>()){
                    if (c.Checked) {
                        await tests[i].runTest(request);
                    }
                    i++;
                }
            }
        }

        //Return an object containing an instance of each class derived from the abstract class T
        private static List<Test> getTests(){
            List<Test> objects = Assembly.GetAssembly(
                typeof (Test)).GetTypes().Where(myType => myType.IsClass && 
                !myType.IsAbstract && myType.IsSubclassOf(typeof (Test))).Select(type => (Test) Activator.CreateInstance(type)).ToList();

            objects.Sort(); //Objects are sorted so they get stored in the right order
            return objects;
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
    }
}
