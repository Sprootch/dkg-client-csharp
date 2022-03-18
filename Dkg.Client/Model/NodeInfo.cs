using Newtonsoft.Json;

namespace Dkg_client.Model;

public class NodeInfo
{
    public string Version { get; set; }
    [JsonProperty("auto_update")]
    public bool AutoUpdate { get; set; }
    public bool Telemetry { get; set; }
}
