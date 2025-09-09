
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Enums;

namespace ZenBlog.Persistence.Concrete
{
    public class HugginFaceService(IConfiguration _configuration) : IHugginFaceService
    {
        private readonly string ApiKey = _configuration.GetSection("HuggingFaceAPIKey").Value;

        public async Task<byte> AnalizeComment(string text)
        {
            const string modelURL = "https://api-inference.huggingface.co/models/cardiffnlp/twitter-roberta-base-sentiment";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
            var json = JsonSerializer.Serialize(new
            {
                inputs = text,
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(modelURL, content);
            var result = await response.Content.ReadAsStringAsync();

            var doc = JsonDocument.Parse(result);
            var items = doc.RootElement[0];

            var topLabel = items.EnumerateArray().OrderByDescending(e => e.GetProperty("score").GetDouble()).First();

            var label = topLabel.GetProperty("label").GetString();

            var score = topLabel.GetProperty("score").GetDouble();

            byte labelText = label switch
            {
                "LABEL_0" => (byte)CommentAnalysisTypes.Negative,
                "LABEL_1" => (byte)CommentAnalysisTypes.Neutral,
                "LABEL_2" => (byte)CommentAnalysisTypes.Positive,
                _ => (byte)CommentAnalysisTypes.Unknown
            };
            return labelText;
        }

        public async Task<string> GetTranslatedText(string text)
        {
            const string Model = "Helsinki-NLP/opus-mt-tr-en";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
            var requestBody = new
            {
                inputs = text
            };
            string jsonContent = JsonSerializer.Serialize(requestBody);
            using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            string url = $"https://api-inference.huggingface.co/models/{Model}";
            HttpResponseMessage response = await client.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                string err = await response.Content.ReadAsStringAsync();
                throw new Exception($"API çağrısı başarısız: {response.StatusCode}, {err}");
            }
            string resultJson = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(resultJson);
            var root = doc.RootElement;
            if (root.ValueKind == JsonValueKind.Array && root.GetArrayLength() > 0)
            {
                var first = root[0];
                if (first.TryGetProperty("translation_text", out JsonElement translationElem))
                {
                    return translationElem.GetString();
                }
            }
            return "-1";

        }
    }
}
