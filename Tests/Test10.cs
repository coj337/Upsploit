using System.Text;
using System.Threading.Tasks;

/*
* Test #10
* Description: This test inserts a colon after the malicious extension and before the allowed one. This will create an alternate data stream for the php file (i.e. an empty php file will be created)
* It should be possible to create a php file with data in it.
*/
namespace FileUploadTool.Tests {
    class Test10 : Test {
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
