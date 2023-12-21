//this program adds bitcoin data to a database to be used for data tracking and analatics
//An example backup of said database is provided on my protfolio website:
//Create the database from the backup before running this program

//UNDER CONSTRUCTION!!

using CryptoDatabasePopulator;
using Newtonsoft.Json;//nugget
using static System.Net.WebRequestMethods;
using MySql.Data.MySqlClient;//nugget
using System.Drawing;
using MySqlX.XDevAPI;//nugget

//user parameters:
int msBetweenApiCalls = 10000;
string[] coinNames = {
    "bitcoin", "ethereum", "tether", "binance-coin", "xrp", "usd-coin", "dogecoin", "cardano", "solana", "tron",
    "polkadot", "polygon", "shiba-inu", "litecoin" , "multi-collateral-dai", "wrapped-bitcoin", "bitcoin-cash",
    "avalanche", "unus-sed-leo", "chainlink", "stellar", "monero", "axie-infinity", "decentraland", "neo", "flow",
    "gala", "mina", "ftx-token", "dash", "singularitynet", "ravencoin"
};

HttpClient client = new HttpClient();
CoinCapApi coinCapApi = new CoinCapApi();

string[] arguments = Environment.GetCommandLineArgs();
if (arguments.Length != 4)
{
    throw new ArgumentException("Invalid number of arguments.\n This script requires server, user, pass, and database args");
}
string server = "server=";
server += arguments[0] + ";";
string user = "userid=";
user += arguments[1] + ";";
string pass = "password=";
pass = arguments[2] + ";";
string database = "database=";
database = arguments[3] + ";";
string sqlInfo = server + user + pass + database;
using var sqlConnect = new MySqlConnection(sqlInfo);
sqlConnect.Open();

//uncomment the follwing line to verify connection
//Console.WriteLine($"MySQL version : {sqlConnect.ServerVersion}");

//loops infinitely, storing new crypto coin data in the database at set intervals
while (true)
{
    //looping through each coin
    for (int i = 0; i < coinNames.Length; i++)
    {
        //getting coin data
        CryptoCoin btc = coinCapApi.getCoin(coinNames[i]);
        Console.WriteLine($"got coin data from api:\n{btc.ToString()}");

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
        Console.WriteLine($"\n{coinNames[i]} data added to database!");
    }
    //sleeping before repeating process
    int sleepTime = msBetweenApiCalls;
    Console.WriteLine($"sleeping for {sleepTime} milliseconds");
    Thread.Sleep(sleepTime);
}