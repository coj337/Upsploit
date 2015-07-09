using System.Text;
using System.Threading.Tasks;

/*
* Test #6
* Description: This test tries different combinations of double-extensions.
* Different double extension tests will work based on certain server configs.
*/
namespace FileUploadTool.Tests {
    class Test06 : Test {
        internal override async Task runTest(UploadRequest.UploadRequest request) {
            const string data = "<?php\n"
                            + "  echo phpinfo();\n"
                            + "?>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg");

            //Test for validation of just the final extension (Apache will use the real extension for the MIME type)
            request.setFileName("Test_6.php.123");
            await request.send();
            printResult(request, "Test 6 (first extension)");

            //Test for validation of just the first extension (Apache will use the last extension for the MIME type if they're all real)
            request.setFileName("Test_6.jpg.php");
            await request.send();
            printResult(request, "Test 6 (last extension)");

            //Test for "AddHandler" directive for php files (This will make Apache recognize the file as PHP no matter where the extension is)
            request.setFileName("Test_6.php.jpg");
            await request.send();
            printResult(request, "Test 6 (AddHandler test)");
        }
    }
}
