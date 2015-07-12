using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upsploit.Tests{
    public abstract class Test : IComparable<Test>{
        public readonly List<string> testName = new List<string>();
        public readonly List<string> reasonPhrase = new List<string>();
        public readonly List<string> statusCode = new List<string>();
        public readonly List<string> misc = new List<string>();
        public abstract string description { get; set; }
        public abstract string validation { get; set; }

        public int CompareTo(Test otherTest) {
            return string.Compare(GetType().Name, otherTest.GetType().Name, StringComparison.Ordinal);
        }

        internal abstract Task runTest(UploadRequest.UploadRequest request);

        protected void printResult(UploadRequest.UploadRequest request, string newTestName){
            testName.Add(newTestName);
            reasonPhrase.Add(request.reasonPhrase);
            statusCode.Add(request.statusCode.ToString());

            Console.WriteLine(newTestName + " Status: " + request.statusCode + " " +  request.reasonPhrase);
            if (request.reasonPhrase == "OK"){
                string[] errorMessages = { "error", "invalid", "not uploaded", "fail" }; //All values must be lower case to be detected
                if (errorMessages.Any(word => request.response.ToLower().Contains(word))) { //Check for error related words
                    misc.Add("Warning: The request was successful but an error message was detected!");
                }
            }
        }
    }
}
