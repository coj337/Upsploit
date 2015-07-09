using System.Text;
using System.Threading.Tasks;

/*
* Test #1
* Description: This test simply uploads a normal PHP file without any attempts to hide it.
*/
namespace FileUploadTool.Tests {
    class Test01 : Test{
        internal override async Task runTest(UploadRequest.UploadRequest request){
            const string data = "<?php\n"
                              + "  echo phpinfo();\n"
                              + "?>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("application/x-httpd-php"); //Generally the default content-type used for php
            request.setFileName("Test_1.php");

            await request.send(); //Send the request and halt the thread until it completes
            printResult(request, "Test 1");
        }
    }
}