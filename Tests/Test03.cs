using System.Text;
using System.Threading.Tasks;

/*
* Test #3
* Description: This test tries to upload different kinds of files that can be used maliciously.
*/
namespace FileUploadTool.Tests {
    class Test03 : Test {
        internal override async Task runTest(UploadRequest.UploadRequest request){
            //Set the data to HTML (all formats support HTML)
            const string data = "<script>alert(document.cookie)</script>";
            string[] badExtensions = {".html", ".shtml", ".jsp", ".asp", ".phtml", ".php3", ".php4", ".php5" };
            request.setFileContentType("image/jpeg"); //Default all files to image/jpeg

            request.setFileData(Encoding.ASCII.GetBytes(data));

            foreach (string t in badExtensions){
                request.setFileName("Test_3" + t);
                await request.send();
                printResult(request, "Test 3 (" + t + ")");
            }
        }
    }
}