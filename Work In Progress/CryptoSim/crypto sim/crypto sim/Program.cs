// HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
using crypto_sim;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using MySql.Data.MySqlClient;
using System.Drawing;

HttpClient client = new HttpClient();

//retrieves current crypto coin info using the coincap api and stores it in a CryptoCoin object
//includes info like current price in usd, price change percent in last 24 hours, supply, and a timestamp
CryptoCoin getCoin(string coinName)
{
    CryptoCoin coin = new CryptoCoin();
    try
    {
        string getUrl = "http://api.coincap.io/v2/assets/";
        getUrl += coinName;
        var task = Task.Run(() => client.GetAsync("http://api.coincap.io/v2/assets/bitcoin"));
        //making task synchronous for simplicity
        task.Wait();
        HttpResponseMessage response = task.Result;
        response.EnsureSuccessStatusCode();
        var task2 = Task.Run(async () => await response.Content.ReadAsStringAsync());
        string responseBody = task2.Result;
        coin = JsonConvert.DeserializeObject<CryptoCoin>(responseBody);
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Exception Caught!");
        Console.WriteLine($"Message: {e.Message}");
        Console.WriteLine("");
    Environment.Exit(0);
    }
    return coin;
}

//this needs to be done differently so the password isn't sitting here in the code
//Try setting terminal params for user and pass
string mySqlInfo = "server=localhost;userid=root;password=<insert password>;database=coins";
using var sqlConnect = new MySqlConnection(mySqlInfo);
sqlConnect.Open();
//used to verify connection
//Console.WriteLine($"MySQL version : {sqlConnect.ServerVersion}");

CryptoCoin btc = getCoin("bitcoin");
string btcPrice1 = btc.data.priceUsd;
Console.WriteLine($"got coin data from api: {btc.data.priceUsd}");

using var cmd = new MySqlCommand();
cmd.Connection = sqlConnect;
cmd.CommandText = $"INSERT INTO bitcoin(price) VALUES({btcPrice1})";
cmd.ExecuteNonQuery();
Console.WriteLine($"coin data added to database: {btc.data.priceUsd}");

int sleepTime = 25000;
Console.WriteLine($"sleeping for {sleepTime} milliseconds");
Thread.Sleep(sleepTime);

btc = getCoin("bitcoin");
string btcPrice2 = btc.data.priceUsd;
Console.WriteLine($"got coin data from api: {btc.data.priceUsd}");

cmd.CommandText = $"INSERT INTO bitcoin(price) VALUES({btcPrice2})";
cmd.ExecuteNonQuery();
Console.WriteLine($"coin data added to database: {btc.data.priceUsd}");