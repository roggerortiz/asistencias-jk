using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace RestApi
{
    public class RestClient
    {
        private String appKey = "/w3BzXWrS5Y4ncgRkjjVMvrEesteR0bzs";
        private String baseUrl = String.Empty;
        private String requestUrl = String.Empty;

        public RestClient(String baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public String RequestUrl
        {
            get { return requestUrl; }
        }

        public String makeRequest(String apiUrl)
        {

            String strResponseValue = String.Empty;

            try
            {
                this.requestUrl = apiUrl.Replace(' ', '-') + appKey;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.baseUrl + this.requestUrl);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("HttpStatusCode (" + response.StatusCode + "): " + response.StatusDescription);
                }

                Stream responseStream = response.GetResponseStream();

                if (responseStream == null)
                {
                    throw new ApplicationException("Response Strem Nullable Value");
                }

                StreamReader reader = new StreamReader(responseStream);

                strResponseValue = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Procesar Url Api: " + this.RequestUrl);
            }

            return strResponseValue;
        }
    }
}
