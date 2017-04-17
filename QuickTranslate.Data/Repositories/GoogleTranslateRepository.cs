using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using QuickTranslate.Data.Contracts.RepositoryInterfaces;
using QuickTranslate.Entities;

namespace QuickTranslate.Data.Repositories
{
    public class GoogleTranslateRepository : IGoogleTranslateRepository
    {
        public Translation Translate(string text, string to, string from = null)
        {
            using (var client  = new HttpClient())
            {
                client.BaseAddress = new Uri("https://translate.googleapis.com");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                client.DefaultRequestHeaders.Add("Accept-Charset", "UTF-8");

                from = string.IsNullOrWhiteSpace(from) ? "auto" : from;

                var response = client.GetAsync($"translate_a/single?client=gtx&sl={from}&tl={to}&dt=t&q={text}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var translation = ConvertResultToDomainEntity(result, text, to);
                    return translation;
                }

                return null;
            }
        }

        private Translation ConvertResultToDomainEntity(string result, string text, string to)
        {
            var j = JObject.Parse("{\"j\":" + result + "}");
            var from = (string)j["j"][2];
            string translatedText = string.Empty;

            for (var i = 0; i < j["j"][0].Count(); i++)
            {
                var sentence = j["j"][0][i][0];
                translatedText += sentence + " ";
            }
            translatedText = translatedText.TrimEnd(' ');

            var translation = new Translation
            {
                From = from,
                To = to,
                OriginalText = text,
                TranslatedText = translatedText
            };

            return translation;
        }
    }
}
