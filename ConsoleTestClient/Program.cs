using Dkg.Client;

var client = new DkgClient("49.12.32.83", 8900);

var info = await client.GetInfoAsync();
Console.WriteLine(info.Version);

string s = @"[  ""_:t1253 <http://schema.org/name> ""Richard Feynman"" ."" ]";

//var proofId = await client.ProofsAsync(s);

//var proofResult = await client.GetProofResultAsync(proofId.Id);

var query = @"PREFIX schema: <http://schema.org/> CONSTRUCT { ?s schema:name ""Richard Feynman"" } WHERE { GRAPH ?g { ?s schema:name ""Richard Feynman"".  } }";

var hId = await client.QueryAsync("construct", query);

var res = await client.GetQueryResultAsync(hId);

Console.ReadKey();
