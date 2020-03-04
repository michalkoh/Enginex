using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Enginex.Infrastructure.Captcha
{
    internal class CaptchaResponse
    {
        public bool Success { get; set; }

        [JsonPropertyName("error-codes")]
        public IEnumerable<string>? ErrorCodes { get; set; }

        [JsonPropertyName("challenge_ts")]
        public DateTime ChallengeTime { get; set; }

        public string? HostName { get; set; }

        public double Score { get; set; }

        public string? Action { get; set; }
    }
}
