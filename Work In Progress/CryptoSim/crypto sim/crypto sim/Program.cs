//this program adds bitcoin data to a database to be used for data tracking and analatics
//A backup of said database is provided on my protfolio website: blablabla.blablabla.com
//Create the database from the backup before running this program

using crypto_sim;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using MySql.Data.MySqlClient;
using System.Drawing;
using MySqlX.XDevAPI;

//user parameters:
int msBetweenApiCalls = 6000;
string coinName = "tether";

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
        var task = Task.Run(() => client.GetAsync("http://api.coincap.io/v2/assets/" + coinName));
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
//look into Integrated Security=SSPI;
string mySqlInfo = "server=localhost;userid=david;password=password;database=coins";
using var sqlConnect = new MySqlConnection(mySqlInfo);
sqlConnect.Open();
//uncomment the follwing line to verify connection
//Console.WriteLine($"MySQL version : {sqlConnect.ServerVersion}");

//loops infinitely, storing new bitcoin data in the database at set intervals
while (true)
{
    //getting coin data
    CryptoCoin btc = getCoin(coinName);
    Console.WriteLine($"got coin data from api:\n{btc.ToString()}");

    //creating table for new coin if needed
    /*
    if (coinName != "bitcoin")
    {
        using var createTable = new MySqlCommand();
        createTable.Connection = sqlConnect;
        createTable.CommandText = $"create table if not exists {coinName} like bitcoin;";
        createTable.ExecuteNonQuery();
    }
    */

    //preparing coin data
    string price = btc.data.priceUsd;
    string rank = btc.data.rank;
    string symbol = btc.data.symbol;
    string name = btc.data.name;
    string supply = btc.data.supply;
    string maxSupply = btc.data.maxSupply;
    string marketCap = btc.data.marketCapUsd;
    string volume = btc.data.volumeUsd24Hr;
    string changePercent = btc.data.changePercent24Hr;
    string vwap = btc.data.vwap24Hr;
    if (maxSupply == null)
        maxSupply = "-1";

    //inserting coin data
    using var insertCoin = new MySqlCommand();
    insertCoin.Connection = sqlConnect;
    string command = $"INSERT INTO allCoins" +
        $" (price, date, _rank, symbol, name, supply, maxSupply, marketCap, volumeUsd24Hr, percentPriceChange24Hr, vwap24Hr)" +
        $" VALUES({price}, now(), {rank}, \"{symbol}\", \"{name}\", {supply}, {maxSupply}, {marketCap}, {volume}, {changePercent}, {vwap});";
    //below comment is for debugging queries
    //Console.WriteLine("\n" + command);
    insertCoin.CommandText = command;
    insertCoin.ExecuteNonQuery();
    Console.WriteLine($"\n{coinName} data added to database!");

    //sleeping before repeating process
    int sleepTime = msBetweenApiCalls;
    Console.WriteLine($"sleeping for {sleepTime} milliseconds");
    Thread.Sleep(sleepTime);
}