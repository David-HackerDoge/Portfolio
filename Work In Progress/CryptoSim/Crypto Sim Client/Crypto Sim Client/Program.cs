using Crypto_Sim_Client;
using MySql.Data.MySqlClient;

///this application is still in progress and is not yet working


//returns whether keycode was a printable character or not
bool isKeyPrintable(byte keyCode)
{
    return keyCode >= 0x20 && keyCode <= 0x7E;
}


string mySqlInfo = "server=localhost;userid=root;password=";
Console.WriteLine("Please provide mysql password");
string pass = "";
int stars = 0;
while (true)
{
    var key = System.Console.ReadKey(true);
    if (key.Key == ConsoleKey.Enter)
    {
        Console.WriteLine();
        break;
    }
    else if (key.Key == ConsoleKey.Backspace && stars > 0)
    {
        stars--;
        pass = pass.Remove(pass.Length - 1);
    }
    else if (isKeyPrintable((byte)key.KeyChar))
    {
        stars++;
        pass += key.KeyChar;
    }
    Console.Write("\r");
    for (int i = 0; i < stars + 1; i++)
    {
        Console.Write(" ");
    }
    Console.Write("\r");
    for (int i = 0; i < stars; i++)
    {
        Console.Write("*");
    }
}
mySqlInfo += pass + "; database = coins";
using var sqlConnect = new MySqlConnection(mySqlInfo);
sqlConnect.Open();
//used to verify connection
//Console.WriteLine($"MySQL version : {sqlConnect.ServerVersion}");

//this code reads the bitcoin prices back from most recent to least recent.
var cmd2 = new MySqlCommand("select * from bitcoin order by id desc", sqlConnect);
using MySqlDataReader reader = cmd2.ExecuteReader();

List<double> prices = new List<double>();
while(reader.Read())
{
    prices.Add(reader.GetDouble(1));
}

for(int i = 0; i < prices.Count; i++)
{
    Console.WriteLine(prices[i]);
}

Wallet wallet1 = new Wallet();