using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace EveTransactions.Services
{
    public static class HttpServices
    {
        public static HttpWebResponse MakeHttpRequest(string baseurl, string httpMethod, WebHeaderCollection headers, string bodyFormData = "", string contentType = "application/xml; charset=utf-8")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseurl);
            if (headers.Count > 0)
            {
                request.Headers = headers;
            }

            if (httpMethod.Equals("POST"))
            {
                request.Method = "POST";

                StringBuilder reqbody = new StringBuilder();
                reqbody.Append(bodyFormData);
                byte[] data = Encoding.UTF8.GetBytes(reqbody.ToString());
                request.ContentType = contentType;
                request.ContentLength = data.Length;
                using (Stream newStream = request.GetRequestStream())
                {
                    newStream.Write(data, 0, data.Length);
                }
            }
            try
            {
                return (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public static string GetXmlStringFromStream(Stream stream)
        {
            // Adjust settings so XML will be formatted (indented) properly
            XmlWriterSettings writerSettings = new XmlWriterSettings
            {
                Indent = true,
                ConformanceLevel = ConformanceLevel.Fragment
            };

            // Write the XML response to a string builder
            StringBuilder strBuilder = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(strBuilder, writerSettings))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(stream);
                doc.WriteTo(writer);
            }

            return strBuilder.ToString();
        }

    }
}
