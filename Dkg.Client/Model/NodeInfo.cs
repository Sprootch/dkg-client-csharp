using Newtonsoft.Json;

namespace Dkg.Client.Model;

public class NodeInfo
{
    public string Version { get; set; }
    [JsonProperty("auto_update")]
    public bool AutoUpdate { get; set; }
    public bool Telemetry { get; set; }
}
