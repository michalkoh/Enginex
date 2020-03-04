using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Enginex.Web.ViewModels
{
    public class CaptchaResponseViewModel
    {
            [JsonPropertyName("success")]
            public bool Success { get; set; }

            [JsonPropertyName("error-codes")]
            public IEnumerable<string>? ErrorCodes { get; set; }

            [JsonPropertyName("challenge_ts")]
            public DateTime ChallengeTime { get; set; }

            [JsonPropertyName("hostname")]
            public string? HostName { get; set; }

            [JsonPropertyName("score")]
            public double Score { get; set; }

            [JsonPropertyName("action")]
            public string? Action { get; set; }
    }
}
