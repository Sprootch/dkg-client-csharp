using Newtonsoft.Json;

namespace Dkg.Client.Model.Response;

public class HandlerId
{
    [JsonProperty("handler_id")]
    public string Id { get; set; }

    public static implicit operator HandlerId(string id) => new HandlerId { Id = id };
}
