using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AIService
{
    public class MyMemoryApiResponse
    {
        public ResponseData responseData { get; set; }
    }

    public class ResponseData
    {
        public string translatedText { get; set; }
    }
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
            try
            {
                // Ensure textToTranslate is URL-encoded to handle special characters
                textToTranslate = System.Net.WebUtility.UrlEncode(textToTranslate);

                // Build the API request URL for translation
                string apiUrl = $"{MyMemoryApiUrl}?q={textToTranslate}&langpair={sourceLanguage}|{targetLanguage}";

                // Send a GET request to the API
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var jsonData = JsonSerializer.Deserialize<MyMemoryApiResponse>(responseBody);

                        if (jsonData != null && jsonData.responseData != null)
                        {
                            string translation = jsonData.responseData.translatedText;
                            return translation;
                        }
                        else
                        {
                            return "Translation not available.";
                        }
                    }
                    catch (JsonException)
                    {
                        return "Failed to parse the translation response.";
                    }
                }
                else
                {
                    // Handle non-successful HTTP status codes (e.g., 404, 500)
                    // You can return appropriate error messages or handle specific cases here
                    return "Translation request failed with HTTP status code: " + response.StatusCode;
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request-related exceptions
                // Log the exception details for troubleshooting
                // Example: Console.WriteLine("HTTP request failed: " + ex.Message);
                return "Translation request failed: " + ex.Message;
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network issues, timeouts)
                // Log the exception details for troubleshooting
                // Example: Console.WriteLine("An error occurred: " + ex.Message);
                return "An error occurred: " + ex.Message;
            }
        }
    }
}
