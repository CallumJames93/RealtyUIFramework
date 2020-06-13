using Common.ExecutionContext.Runtime.DeviceSettings.Contracts;
using Newtonsoft.Json;

namespace Common.ExecutionContext.Runtime.DeviceSettings
{
    public class DeviceSettingsBase : IDeviceProperties
    {
        [JsonProperty("platformName")]
        public string PlatformName { get; set; }

        string IDeviceProperties.Name => PlatformName;

        DeviceSettingsBase IDeviceProperties.DeviceSettings => this;
    }
}
