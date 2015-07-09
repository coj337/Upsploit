using System.Text;
using System.Threading.Tasks;

/*
* Test #2
* Description: This test looks for MIME-Type validation by uploading a php file with the content type changed.
***The changed content-type only effects the upload, the browser/server will still see it as a php file.
*/
namespace FileUploadTool.Tests {
    class Test02 : Test {
        //TODO: Make it validate with more content-types
        internal override async Task runTest(UploadRequest.UploadRequest request) {
            const string data = "<?php\n"
                                   + "  echo phpinfo();\n"
                                   + "?>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg");
            request.setFileName("Test_2.php");

            await request.send();

            printResult(request, "Test 2");
        }

        
    }
}