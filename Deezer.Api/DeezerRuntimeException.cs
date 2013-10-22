using System;

namespace Deezer.Api
{
    public class DeezerRuntimeException : Exception
    {
        private string HttpReasonPhrase;

        public DeezerRuntimeException(string httpReasonPhrase)
        {
            this.HttpReasonPhrase = httpReasonPhrase;
        }

    }
}
