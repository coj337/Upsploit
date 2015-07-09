using System;

namespace FileUploadTool.UploadRequest {
    class InvalidRequestException : Exception{
        public InvalidRequestException() { }

        public InvalidRequestException(string message) : base(message) {}
    }
}
