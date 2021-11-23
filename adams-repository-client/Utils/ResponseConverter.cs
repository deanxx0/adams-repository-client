using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace adams_repository_client.Utils
{
    class ResponseConverter<T>
    {
        HttpContent _httpContent;

        public ResponseConverter(HttpContent httpContent)
        {
            _httpContent = httpContent;
        }

        internal T Convert()
        {
            var contentStream = _httpContent.ReadAsStreamAsync().Result;

            using var streamReader = new StreamReader(contentStream);
            using var jsonReader = new JsonTextReader(streamReader);

            JsonSerializer serializer = new JsonSerializer();

            try
            {
                return serializer.Deserialize<T>(jsonReader);
            }
            catch (JsonReaderException e)
            {
                throw e;
            }
        }
    }
}
