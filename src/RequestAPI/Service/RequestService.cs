using Newtonsoft.Json;
using Shared;
using System.Net;
using System.Reflection;

namespace RequestAPI.Service
{
    public class RequestService
    {
        private readonly string baseRequestUrl = "https://localhost:7002/api/";

        public async Task<PasswordResponse> RequestPassword(PasswordRequest passwordRequest)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            string requestUrl = baseRequestUrl + "Response/GetResponse";

            List<string> urlQuery = new List<string>();

            //foreach (PropertyInfo property in passwordRequest.GetType().GetProperties().Where(p => p.PropertyType == typeof(bool)))
            foreach (PropertyInfo property in passwordRequest.GetType().GetProperties())
            {
                //httpRequest.Headers.TryAddWithoutValidation(property.Name, $"{property.GetValue(passwordRequest)}");
                urlQuery.Add($"{property.Name}={property.GetValue(passwordRequest)}");
            }
            httpRequest.RequestUri = new Uri(requestUrl + "?" + string.Join("&", urlQuery));

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            httpResponse = await httpClient.SendAsync(httpRequest);

            HttpStatusCode statusCode = httpResponse.StatusCode;

            if (statusCode != HttpStatusCode.OK)
                throw new Exception("An error occured.");

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            PasswordResponse passwordResponse = JsonConvert.DeserializeObject<PasswordResponse>(responseContent);

            if (passwordResponse == null)
                throw new Exception("An error occured.");


            return new PasswordResponse()
            {
                Password = passwordResponse.Password,
                Length = passwordResponse.Length,
                Uppercase = passwordResponse.Uppercase,
                Lowercase = passwordResponse.Lowercase,
                Numbers = passwordResponse.Numbers,
                SpecialCharacters = passwordResponse.SpecialCharacters
            };
        }
    }
}
