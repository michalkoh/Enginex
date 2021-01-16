using Enginex.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Enginex.Infrastructure.Captcha
{
    public class GoogleCaptcha : ICaptcha
    {
        private readonly IOptions<GoogleCaptchaSettings> captchaSettings;

        public GoogleCaptcha(IOptions<GoogleCaptchaSettings> captchaSettings)
        {
            this.captchaSettings = captchaSettings;
        }

        public async Task<bool> IsValid(string? response, string? remoteIpAddress)
        {
            if (string.IsNullOrEmpty(response))
            {
                return false;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        { "secret", this.captchaSettings.Value.Secret },
                        { "response", response },
                        { "remoteip", remoteIpAddress ?? string.Empty }
                    };

                    var content = new FormUrlEncodedContent(values);
                    var verify = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
                    var captchaResponseJson = await verify.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var captchaResult = JsonSerializer.Deserialize<CaptchaResponse>(captchaResponseJson, options);
                    return captchaResult != null && captchaResult.Success && captchaResult.Action == "contact_us" && captchaResult.Score > 0.7;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
