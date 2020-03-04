namespace Enginex.Infrastructure.Captcha
{
    public class GoogleCaptchaSettings
    {
        public GoogleCaptchaSettings()
        {
            Secret = string.Empty;
        }

        public string Secret { get; set; }
    }
}
