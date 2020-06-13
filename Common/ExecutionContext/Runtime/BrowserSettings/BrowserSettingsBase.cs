using Common.ExecutionContext.Runtime.BrowserSettings.Contracts;
using Newtonsoft.Json;

namespace Common.ExecutionContext.Runtime.BrowserSettings
{
    public class BrowserSettingsBase : IBrowserProperties
    {
        [JsonProperty("browserName")]
        public string BrowserName { get; set; }

        string IBrowserProperties.Name => BrowserName;

        BrowserSettingsBase IBrowserProperties.BrowserSettings => this;
    }
}
