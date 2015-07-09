using System;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadTool.Tests{
    abstract class Test : IComparable<Test>{
        public int CompareTo(Test otherTest) {
            return string.Compare(GetType().Name, otherTest.GetType().Name, StringComparison.Ordinal);
        }

        //Runs the test
        internal abstract Task runTest(UploadRequest.UploadRequest request);

        protected static void printResult(UploadRequest.UploadRequest request, string testName) {
            Console.WriteLine(testName + " Status: " + request.reasonPhrase);
            if (request.reasonPhrase == "OK") {
                string[] errorMessages = { "error", "invalid", "not uploaded", "fail" };
                if (errorMessages.Any(word => request.response.ToLower().Contains(word))) {
                    Console.WriteLine("Warning: The request was successful but an error message was detected!");
                }
            }
            Console.WriteLine();
        }
    }
}
