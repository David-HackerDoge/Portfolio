using SqlInjectionBlackLister;

SqlInjectChecker injectionChecker = new SqlInjectChecker();

string ip = "10.0.0.2";
string request = "POST /cgi-bin/process.cgi HTTP/1.1\r\nUser-Agent: Mozilla/4.0 (compatible; MSIE5.01; Windows NT) union select password from admin \r\nHost: www.tutorialspoint.com\r\nContent-Type: text/xml; charset=utf-8\r\nContent-Length: length\r\nAccept-Language: en-us\r\nAccept-Encoding: gzip, deflate\r\nConnection: Keep-Alive\r\n\r\n<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<string xmlns=\"http://clearforest.com/\">string</string>";
string fileName = "blacklist.txt";

bool result = injectionChecker.isInjection(ip, request, fileName);
if (result == true)
{
    Console.WriteLine("Found injection! Added ip to blacklist!");
    Console.WriteLine("Check logs.txt for more info");
}
else if (result == false)
{
    Console.WriteLine("All Clear!");
}






