using System;
using System.IO;
using System.Web;

namespace HelperSharp.Mvc
{
    /// <summary>
    /// Byte extensions
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Send the byte array content over HTTP current response.
        /// </summary>
        /// <param name="data">The content to be send.</param>
        /// <param name="fileName">The suggested file name to the HTTP client.</param>
        /// <param name="contentType">The content's mime-type.</param>
        public static void SendOverHttp(this byte[] data, string fileName, string contentType)
        {
            ExceptionHelper.ThrowIfNullOrEmpty("contentType", contentType);

            if (String.IsNullOrWhiteSpace(fileName))
            {
                fileName = Guid.NewGuid().ToString();
            }

            fileName = Path.GetFileName(fileName);

            var response = HttpContext.Current.Response;
            response.ContentType = contentType;
            response.AddHeader("content-disposition", "attachment;  filename=" + fileName);
            response.SetCookie(new HttpCookie("fileDownload", "true") { Path = "/" });
            response.BinaryWrite(data);
        }
    }
}
