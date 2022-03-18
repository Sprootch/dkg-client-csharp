using Dkg.Client;

var client = new DkgClient("49.12.32.83", 8900);

var info = await client.GetInfoAsync();

Console.ReadKey();
