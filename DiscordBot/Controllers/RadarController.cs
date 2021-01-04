using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordBot.Helpers;
using DiscordBot.lib;
using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DiscordBot.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RadarController : ControllerBase
    {
        private DiscordClient client;
        public RadarController(DiscordClient client)
        {
            this.client = client;
        }

        [Route("online")]
        public IEnumerable<string> GetOnlineUsers(string servername)
        {
            servername = "gatewood";    // Temporarily hard code until we can figure out how to parse this data from somewhere.
            var serverId = ClientHelper.GetGuildIdFromServerName(servername);

            DiscordGuild guild;
            client.Guilds.TryGetValue(serverId, out guild);


            var memberList = guild.VoiceStates.Where(vs => vs.Channel != guild.AfkChannel && vs.Channel != null).Select(vs => vs.User.Username);

            return memberList;
        }


    }
}