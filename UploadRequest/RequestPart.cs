using System.Text;
using System.Text.RegularExpressions;

namespace Upsploit.UploadRequest {
    class RequestPart{
        internal string contentDisposition { get; }
        internal string contentType { get; set; }
        internal byte[] data { get; set; }
        internal string name { get; }
        internal byte[] fileName { get; set; }
        
        public RequestPart(string part){
            contentDisposition = getContentDisposition(part);
            name = getName(part);
            fileName = getFileName(part);
            if (fileName == null) { //If there's no file name, it's not a file, if it's a file, don't set the data. A files data is set by the test
                data = getData(part); 
            }
            else{
                contentType = getContentType(part); //Only files have a content type
                data = new byte[0]; //No data for a file, it should be set by each test
            }
        }

        //Return the contents of the content disposition (e.g. form-data)
        private static string getContentDisposition(string part){
            Match match = Regex.Match(part, "(?<=Content-Disposition: )[^;]+(?=(\n|\r|\r\n|;))");

            if (match.Success)
                return match.Value;
            throw new InvalidRequestException("Part missing a Content-Disposition header!");
        }

        //Return the name of a part
        private static string getName(string part){
            Match match = Regex.Match(part, "(?<=name=\")(\\\\?.)*?(?=\")");

            if (match.Success)
                return match.Value;
            throw new InvalidRequestException("Part missing a name header!");
        }

        //Return the filename of a part (optional parameter)
        private static byte[] getFileName(string part){
            Match match = Regex.Match(part, "(?<=filename=\")(\\\\?.)*?(?=\")");

            return match.Success ? Encoding.ASCII.GetBytes(match.Value) : null;
        }

        //Returns the content type of a part (e.g. image/jpeg) (optional parameter)
        private static string getContentType(string part){
            Match match = Regex.Match(part, "(?<=Content-Type: ).*?(?=(\n|\r|\r\n))");

            if(match.Success)
                return match.Value;
            throw new InvalidRequestException("Filename found without a matching content-type!");
        }

        //Returns the data for the part, this isn't called for the data in files (which is set by each test)
        private static byte[] getData(string part){
            return Encoding.ASCII.GetBytes(Regex.Match(part, "(?<=(\n|\r|\r\n){2,}).*?(?=$)").Value.TrimEnd('\r', '\n'));
        }
    }
}
