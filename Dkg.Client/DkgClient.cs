using Dkg_client.Model;
using Flurl;
using Flurl.Http;

namespace Dkg.Client;

public class DkgClient
{
    public string Url { get; }
    public string BaseUrl { get; }
    public int Port { get; }

    public DkgClient(string url, int port, bool useSsl = false)
    {
        Url = url;
        Port = port;
        BaseUrl = $"http://{url}:{port}";
    }

    public DkgClient() : this("localhost", 8900, false)
    {
    }

    public async Task<NodeInfo> GetInfoAsync()
    {
        var result = await BaseUrl.AppendPathSegment("info").GetJsonAsync<NodeInfo>();

        return result;
    }

}
