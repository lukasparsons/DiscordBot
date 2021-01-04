using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Helpers
{
    public static class ClientHelper
    {
        public static ulong GetGuildIdFromServerName(string servername)
        {
            switch(servername.ToLower())
            {
                case "gatewood":
                    return ServerIds.Gatewood;
                default:
                    throw new KeyNotFoundException($"The given servername {servername} does not match any servers on record.");
            }

        }
    }
}
