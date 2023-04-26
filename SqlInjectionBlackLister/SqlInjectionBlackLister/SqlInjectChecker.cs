using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlInjectionBlackLister
{
    internal class SqlInjectChecker
    {
        void blackListIp(string ip, string filePath)
        {
            //create blacklist file if it doesn't exist
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "");
            }
            string[] badips = File.ReadAllLines(filePath);
            if (badips.Contains(ip))
            {
                File.AppendAllText("logs.txt", $"{ip} was already blacklisted. They shouldn't be able to send requests. The blacklist is likely not working\n");
            }
            else
            {
                File.AppendAllText(filePath, ip + "\n");
                File.AppendAllText("logs.txt", $"{ip} added to blacklist\n");
            }
            
        }

        /// <summary>
        /// Checks for sql injection and adds the ip to the blacklist if it finds any
        /// currently only checks for the keyword select and only checks for all lowercase
        /// TODO: check using regex, check for other sql terms, check for obfuscation
        /// note: blacklist is meant to be given to a firewall to prevent additional requests from bad actors
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="request"></param>
        /// <param name="blackListFilePath"></param>
        /// <returns></returns>
        public bool isInjection(string ip, string request, string blackListFilePath)
        {
            //create log file if it doesn't exist
            if (!File.Exists("logs.txt"))
            {
                File.WriteAllText("logs.txt", "Log created\n");
            }
            File.AppendAllText("logs.txt", $"checking request from {ip} for sql injection\n");
            if (request.Contains("select"))
            {
                File.AppendAllText("logs.txt", $"Sql injection found in request from {ip}!\n");
                blackListIp(ip, blackListFilePath);
                return true;
            }
            File.AppendAllText("logs.txt", $"nothing unusual was detected in request from {ip}\n");
            return false;
        }
    }

}

