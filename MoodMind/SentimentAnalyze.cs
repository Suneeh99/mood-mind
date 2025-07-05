using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoodMind
{
    internal class SentimentAnalyze
    {
        private const string ApiKey = "YOUR_API";
        private const string Endpoint = "https://api-inference.huggingface.co/models/j-hartmann/emotion-english-distilroberta-base";

        public static async Task<string> DetectEmotions(string text)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

                var content = new StringContent(JsonConvert.SerializeObject(new { inputs = text }), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<JArray>(jsonResponse);

                    // Access the first element of the response
                    var emotions = result[0]; 
                    // Define the emotions we're interested in
                    var desiredEmotions = new[] { "joy", "sadness", "neutral", "surprise", "anger" };

                    // Filter and select the top 5 emotions with their scores
                    var filteredEmotions = emotions
                        .Where(e => desiredEmotions.Contains(e["label"].ToString().ToLower()))
                        .Select(e => new
                        {
                            Emotion = e["label"].ToString(),
                            Score = Math.Round(Convert.ToDouble(e["score"]), 2) // Round to 2 decimal places
                        })
                        .OrderByDescending(e => e.Score) // Sort by score in descending order
                        .Take(5) // Select top 5 emotions
                        .ToList();

                    // Format the result into a string
                    var resultString = string.Join("\n", filteredEmotions.Select(e => $"{e.Emotion}: {e.Score * 100}%"));

                    return resultString;
                }
                else
                {
                    throw new Exception("Error from API: " + response.StatusCode);
                }
            }
        }
    }

}
