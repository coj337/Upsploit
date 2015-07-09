using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileUploadTool.UploadRequest {
    class UploadRequest{
        //private string requestBody;
        private readonly string boundary;
        private readonly string url;
        private readonly Dictionary<string, string> extraHeaders; 
        private readonly List<RequestPart> parts;
        public string response { get; private set; }
        public string reasonPhrase { get; private set; }

        //Constructor splits the request into individual parts.
        internal UploadRequest(string request) {
            boundary = getBoundary(request);
            extraHeaders = getExtraHeaders(request);
            parts = getParts(request);
            url = getUrl(request);
        }

        //TODO: Implement HTTPS support?
        private static string getUrl(string request){
            string host = Regex.Match(request, "(?<=Host: ).*?(?=(\n|\r|\r\n))").Value;
            string path = Regex.Match(request, "/.* ", RegexOptions.Multiline).Value.Trim();

            if(host != "" && path != "")
                return "http://"+ host + path;
            throw new InvalidRequestException("Path or host not found!");
        }

        //Sends the request with all the headers and content
        public async Task send(){
            HttpClientHandler handler = new HttpClientHandler {UseCookies = false}; //Needed to set cookies in bulk without them being ignored
            HttpClient client = new HttpClient(handler);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            MultipartFormDataContent content = new MultipartFormDataContent(boundary);
            
            //Add the HTTP headers
            foreach (KeyValuePair<string, string> header in extraHeaders) {
                request.Headers.Add(header.Key, header.Value); //TODO: Make cookies happen
            }

            //Add the multipart content to an object
            foreach (RequestPart part in parts){
                content.Add(createFileContent(new MemoryStream(part.data), part));
            }
            request.Content = content; //Add the multipart data object to the HttpClient
            

            //Get and handle the response
            HttpResponseMessage httpResponse = await client.SendAsync(request);

            reasonPhrase = httpResponse.ReasonPhrase;

            if (httpResponse.Content.Headers.ContentEncoding.ToString() == "gzip"){
                Stream responseStream = await httpResponse.Content.ReadAsStreamAsync();
                response = new StreamReader(new GZipStream(responseStream, CompressionMode.Decompress), Encoding.UTF8).ReadToEnd(); //Decompress and translate the response to a string
            }
            else{
                response = await httpResponse.Content.ReadAsStringAsync();
            }
        }

        //Sets the files data to the new bytes
        //Current implementation sets all files
        public void setFileData(byte[] bytes){
            foreach (RequestPart part in parts.Where(part => part.fileName != null)){
                part.data = bytes;
            }
        }

        //Sets the files data to the new bytes
        //Current implementation sets all files
        public void setFileData(string data) {
            foreach (RequestPart part in parts.Where(part => part.fileName != null)) {
                part.data = Encoding.ASCII.GetBytes(data);
            }
        }

        //Sets the files content-type to the string passed in
        //Current implementation sets all files
        public void setFileContentType(string type){
            foreach (RequestPart part in parts.Where(part => part.fileName != null)) {
                part.contentType = type;
            }
        }

        //Sets the files "filename" to the string passed in
        //Current implementation sets all files
        public void setFileName(byte[] fileName) {
            foreach (RequestPart part in parts.Where(part => part.fileName != null)) {
                part.fileName = fileName;
            }
        }

        //Sets the files "filename" to the string passed in
        //Current implementation sets all files
        public void setFileName(string fileName) {
            foreach (RequestPart part in parts.Where(part => part.fileName != null)) {
                part.fileName = Encoding.ASCII.GetBytes(fileName);
            }
        }

        private static StreamContent createFileContent(Stream stream, RequestPart part) {
            StreamContent fileContent = new StreamContent(stream);

            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue(part.contentDisposition){
                Name = "\"" + part.name + "\""
            };
            if (part.fileName != null){
                fileContent.Headers.ContentDisposition.FileName = "\"" + Encoding.Default.GetString(part.fileName) + "\"";
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(part.contentType);
            }

            return fileContent;
        }

        private static string getBoundary(string request) {
            Match match = Regex.Match(request, "boundary=[a-zA-Z0-9-]+(?=(\r|\n|\r\n))", RegexOptions.Multiline);

            if(match.Index != 0)
                return request.Substring(match.Index+9, match.Length-9); //Return the string used for delimiting multipart data
            throw new InvalidRequestException("No multipart boundary found!");
        }

        private static Dictionary<string,string> getExtraHeaders(string request){
            string substr = Regex.Match(request, @"User-Agent:.*?(?:\r\n|\r(?!\n)|(?<!\r)\n){2,}", RegexOptions.Singleline).Value; //Assuming User-Agent is the first header, returns a substring that only includes headers
            substr = Regex.Replace(substr, "Content-Type.*?(?:\r\n|\r(?!\n)|(?<!\r)\n)", ""); //Removes the content-type line (implicitly added)
            substr = Regex.Replace(substr, "Content-Length.*?(?:\r\n|\r(?!\n)|(?<!\r)\n)", ""); //Removes the content-length line (optional header - new length not known)

            if(substr != "")
                return substr.Split(new[]{"\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries).ToDictionary(line => Regex.Match(line, "(.*?)(?=: )").Value, line => line.Substring(line.IndexOf(": ") + 2));
            throw new InvalidRequestException("No extra headers found!");
        }

        private List<RequestPart> getParts(string request){
            int start = request.IndexOf("--" + boundary);
            int length = request.IndexOf("--" + boundary + "--") - start;

            if(start == -1 || length == start*-1-1)
                throw new InvalidRequestException("No multipart data found!"); //Throw exception if the start or end boundary doesn't exist

            string allParts = request.Substring(start, length); //Cut the request down to just the multipart entries
            string[] splitParts = allParts.Split(
                new string[]{"--" + boundary}, //Delimiter for multipart entries
                StringSplitOptions.RemoveEmptyEntries);

            return splitParts.Select(part => new RequestPart(part)).ToList();
        }
    }
}
