using Dkg.Client.Model;
using Dkg.Client.Model.Response;
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

    public Task<NodeInfo> GetInfoAsync()
        => BaseUrl.AppendPathSegment("info").GetJsonAsync<NodeInfo>();

    public async Task<HandlerId> ProofsAsync(string data)
    {
        var result = await BaseUrl.AppendPathSegment("proofs:get")
            .PostStringAsync(data);

        return await result.GetJsonAsync<HandlerId>();
    }

    public async Task<ProofsResult> GetProofResultAsync(HandlerId handlerId)
    {
        var result = await BaseUrl.AppendPathSegment("proofs:get/result")
            .AppendPathSegment(handlerId.Id)
            .GetJsonAsync<ProofsResult>();

        return result;
    }

    public async Task<HandlerId> QueryAsync(string type, string query)
    {
        var result = await BaseUrl.AppendPathSegment("query")
            .SetQueryParam("type", type)
            .PostMultipartAsync(mp => mp.AddString("query", query))
            .ReceiveJson<HandlerId>();

        return result;
    }

    public async Task<QueryResult> GetQueryResultAsync(HandlerId handlerId)
    {
        var result = await BaseUrl.AppendPathSegment("query/result")
            .AppendPathSegment(handlerId.Id)
            .GetJsonAsync<QueryResult>();

        return result;
    }
}
