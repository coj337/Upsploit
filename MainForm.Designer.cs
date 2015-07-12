using System.ComponentModel;
using System.Windows.Forms;
using Upsploit.Tests;

namespace Upsploit
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Upsploit.Tests.Test12 test121 = new Upsploit.Tests.Test12();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Upsploit.Tests.Test11 test111 = new Upsploit.Tests.Test11();
            Upsploit.Tests.Test10 test101 = new Upsploit.Tests.Test10();
            Upsploit.Tests.Test09 test091 = new Upsploit.Tests.Test09();
            Upsploit.Tests.Test08 test081 = new Upsploit.Tests.Test08();
            Upsploit.Tests.Test07 test071 = new Upsploit.Tests.Test07();
            Upsploit.Tests.Test06 test061 = new Upsploit.Tests.Test06();
            Upsploit.Tests.Test05 test051 = new Upsploit.Tests.Test05();
            Upsploit.Tests.Test04 test041 = new Upsploit.Tests.Test04();
            Upsploit.Tests.Test03 test031 = new Upsploit.Tests.Test03();
            Upsploit.Tests.Test02 test021 = new Upsploit.Tests.Test02();
            Upsploit.Tests.Test01 test011 = new Upsploit.Tests.Test01();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.selectNoneButton = new System.Windows.Forms.Button();
            this.runTestsButton = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox09 = new System.Windows.Forms.CheckBox();
            this.checkBox08 = new System.Windows.Forms.CheckBox();
            this.checkBox07 = new System.Windows.Forms.CheckBox();
            this.checkBox06 = new System.Windows.Forms.CheckBox();
            this.checkBox05 = new System.Windows.Forms.CheckBox();
            this.checkBox04 = new System.Windows.Forms.CheckBox();
            this.checkBox03 = new System.Windows.Forms.CheckBox();
            this.checkBox02 = new System.Windows.Forms.CheckBox();
            this.checkBox01 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.selectAllButton.Location = new System.Drawing.Point(11, 149);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(230, 23);
            this.selectAllButton.TabIndex = 24;
            this.selectAllButton.Text = "Select All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // selectNoneButton
            // 
            this.selectNoneButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.selectNoneButton.Location = new System.Drawing.Point(247, 149);
            this.selectNoneButton.Name = "selectNoneButton";
            this.selectNoneButton.Size = new System.Drawing.Size(225, 23);
            this.selectNoneButton.TabIndex = 25;
            this.selectNoneButton.Text = "Select None";
            this.selectNoneButton.UseVisualStyleBackColor = true;
            this.selectNoneButton.Click += new System.EventHandler(this.selectNoneButton_Click);
            // 
            // runTestsButton
            // 
            this.runTestsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.runTestsButton.Location = new System.Drawing.Point(12, 178);
            this.runTestsButton.Name = "runTestsButton";
            this.runTestsButton.Size = new System.Drawing.Size(460, 23);
            this.runTestsButton.TabIndex = 26;
            this.runTestsButton.Text = "Run Tests";
            this.runTestsButton.UseVisualStyleBackColor = true;
            this.runTestsButton.Click += new System.EventHandler(this.runTestsButton_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConsole.Location = new System.Drawing.Point(12, 207);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(460, 197);
            this.txtConsole.TabIndex = 27;
            // 
            // checkBox12
            // 
            this.checkBox12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(247, 125);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(214, 17);
            this.checkBox12.TabIndex = 23;
            test121.description = resources.GetString("test121.description");
            test121.validation = "Look for UniqueLongName.jpg on the web application. If only Unique~1.jpg exists, " +
    "the test was a success and the web application is vulnerable.\r\n\r\nIf UniqueLongNa" +
    "me.jpg exists, the test failed";
            this.checkBox12.Tag = test121;
            this.checkBox12.Text = "Test 12: Windows Shortname Overwrite";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(11, 125);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(175, 17);
            this.checkBox11.TabIndex = 22;
            test111.description = resources.GetString("test111.description");
            test111.validation = resources.GetString("test111.validation");
            this.checkBox11.Tag = test111;
            this.checkBox11.Text = "Test 11: Microsoft IIS <= 6 Test";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(247, 102);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(196, 17);
            this.checkBox10.TabIndex = 21;
            test101.description = resources.GetString("test101.description");
            test101.validation = resources.GetString("test101.validation");
            this.checkBox10.Tag = test101;
            this.checkBox10.Text = "Test 10: Alternate Data Stream Test";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox09
            // 
            this.checkBox09.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox09.AutoSize = true;
            this.checkBox09.Location = new System.Drawing.Point(11, 102);
            this.checkBox09.Name = "checkBox09";
            this.checkBox09.Size = new System.Drawing.Size(128, 17);
            this.checkBox09.TabIndex = 20;
            test091.description = resources.GetString("test091.description");
            test091.validation = resources.GetString("test091.validation");
            this.checkBox09.Tag = test091;
            this.checkBox09.Text = "Test 9: Null Byte Test";
            this.checkBox09.UseVisualStyleBackColor = true;
            // 
            // checkBox08
            // 
            this.checkBox08.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox08.AutoSize = true;
            this.checkBox08.Location = new System.Drawing.Point(247, 79);
            this.checkBox08.Name = "checkBox08";
            this.checkBox08.Size = new System.Drawing.Size(170, 17);
            this.checkBox08.TabIndex = 19;
            test081.description = resources.GetString("test081.description");
            test081.validation = resources.GetString("test081.validation");
            this.checkBox08.Tag = test081;
            this.checkBox08.Text = "Test 8: Custom .htaccess Test";
            this.checkBox08.UseVisualStyleBackColor = true;
            // 
            // checkBox07
            // 
            this.checkBox07.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox07.AutoSize = true;
            this.checkBox07.Location = new System.Drawing.Point(11, 79);
            this.checkBox07.Name = "checkBox07";
            this.checkBox07.Size = new System.Drawing.Size(162, 17);
            this.checkBox07.TabIndex = 18;
            test071.description = resources.GetString("test071.description");
            test071.validation = resources.GetString("test071.validation");
            this.checkBox07.Tag = test071;
            this.checkBox07.Text = "Test 7: Image Comment Test";
            this.checkBox07.UseVisualStyleBackColor = true;
            // 
            // checkBox06
            // 
            this.checkBox06.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox06.AutoSize = true;
            this.checkBox06.Location = new System.Drawing.Point(247, 56);
            this.checkBox06.Name = "checkBox06";
            this.checkBox06.Size = new System.Drawing.Size(174, 17);
            this.checkBox06.TabIndex = 17;
            test061.description = resources.GetString("test061.description");
            test061.validation = resources.GetString("test061.validation");
            this.checkBox06.Tag = test061;
            this.checkBox06.Text = "Test 6: Double Extensions Test";
            this.checkBox06.UseVisualStyleBackColor = true;
            // 
            // checkBox05
            // 
            this.checkBox05.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox05.AutoSize = true;
            this.checkBox05.Location = new System.Drawing.Point(11, 56);
            this.checkBox05.Name = "checkBox05";
            this.checkBox05.Size = new System.Drawing.Size(186, 17);
            this.checkBox05.TabIndex = 16;
            test051.description = resources.GetString("test051.description");
            test051.validation = resources.GetString("test051.validation");
            this.checkBox05.Tag = test051;
            this.checkBox05.Text = "Test 5: Trailing Dots/Spaces Test";
            this.checkBox05.UseVisualStyleBackColor = true;
            // 
            // checkBox04
            // 
            this.checkBox04.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox04.AutoSize = true;
            this.checkBox04.Location = new System.Drawing.Point(247, 33);
            this.checkBox04.Name = "checkBox04";
            this.checkBox04.Size = new System.Drawing.Size(212, 17);
            this.checkBox04.TabIndex = 15;
            test041.description = resources.GetString("test041.description");
            test041.validation = resources.GetString("test041.validation");
            this.checkBox04.Tag = test041;
            this.checkBox04.Text = "Test 4: Case Insensitive Extension Test";
            this.checkBox04.UseVisualStyleBackColor = true;
            // 
            // checkBox03
            // 
            this.checkBox03.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox03.AutoSize = true;
            this.checkBox03.Location = new System.Drawing.Point(11, 33);
            this.checkBox03.Name = "checkBox03";
            this.checkBox03.Size = new System.Drawing.Size(187, 17);
            this.checkBox03.TabIndex = 14;
            test031.description = resources.GetString("test031.description");
            test031.validation = resources.GetString("test031.validation");
            this.checkBox03.Tag = test031;
            this.checkBox03.Text = "Test 3: Dangerous Extension Test";
            this.checkBox03.UseVisualStyleBackColor = true;
            // 
            // checkBox02
            // 
            this.checkBox02.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox02.AutoSize = true;
            this.checkBox02.Location = new System.Drawing.Point(247, 10);
            this.checkBox02.Name = "checkBox02";
            this.checkBox02.Size = new System.Drawing.Size(190, 17);
            this.checkBox02.TabIndex = 13;
            test021.description = resources.GetString("test021.description");
            test021.validation = resources.GetString("test021.validation");
            this.checkBox02.Tag = test021;
            this.checkBox02.Text = "Test 2: MIME Type Validation Test";
            this.checkBox02.UseVisualStyleBackColor = true;
            // 
            // checkBox01
            // 
            this.checkBox01.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox01.AutoSize = true;
            this.checkBox01.Location = new System.Drawing.Point(12, 10);
            this.checkBox01.Name = "checkBox01";
            this.checkBox01.Size = new System.Drawing.Size(112, 17);
            this.checkBox01.TabIndex = 12;
            test011.description = "This test uploads a file (Test_1.php) with the MIME type \"application/x-httpd-php" +
    "\", it makes no attempt to hide the file whatsoever.\r\n\r\nThe test will only work o" +
    "n websites with no validation.";
            test011.validation = resources.GetString("test011.validation");
            this.checkBox01.Tag = test011;
            this.checkBox01.Text = "Test 1: Basic Test";
            this.checkBox01.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 416);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.runTestsButton);
            this.Controls.Add(this.selectNoneButton);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.checkBox12);
            this.Controls.Add(this.checkBox11);
            this.Controls.Add(this.checkBox10);
            this.Controls.Add(this.checkBox09);
            this.Controls.Add(this.checkBox08);
            this.Controls.Add(this.checkBox07);
            this.Controls.Add(this.checkBox06);
            this.Controls.Add(this.checkBox05);
            this.Controls.Add(this.checkBox04);
            this.Controls.Add(this.checkBox03);
            this.Controls.Add(this.checkBox02);
            this.Controls.Add(this.checkBox01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Upsploit";
            this.Load += new System.EventHandler(this.ManualForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox checkBox01;
        private CheckBox checkBox02;
        private CheckBox checkBox03;
        private CheckBox checkBox04;
        private CheckBox checkBox05;
        private CheckBox checkBox06;
        private CheckBox checkBox07;
        private CheckBox checkBox08;
        private CheckBox checkBox09;
        private CheckBox checkBox10;
        private CheckBox checkBox11;
        private CheckBox checkBox12;
        private Button selectAllButton;
        private Button selectNoneButton;
        private Button runTestsButton;
        private TextBox txtConsole;

    }
}