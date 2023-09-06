using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AIService
{
    public class TranslationService
    {
        private readonly HttpClient _httpClient;
        private const string MyMemoryApiUrl = "https://api.mymemory.translated.net/get";

        public TranslationService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> TranslateAsync(string textToTranslate, string sourceLanguage, string targetLanguage)
        {
            var requestContent = new StringContent($"q={textToTranslate}&langpair={sourceLanguage}|{targetLanguage}", Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _httpClient.PostAsync(MyMemoryApiUrl, requestContent);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                // Parse the JSON response and extract the translated text
                // Return the translation
            }
            else
            {
                // Handle error response
            }

            return null; // Handle errors and return appropriate values
        }
    }
}
