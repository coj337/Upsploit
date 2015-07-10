using System;

namespace Upsploit.UploadRequest {
    class InvalidRequestException : Exception{
        public InvalidRequestException() { }

        public InvalidRequestException(string message) : base(message) {}
    }
}
