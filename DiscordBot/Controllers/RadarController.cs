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

        [Route("online/{serverId}")]
        public IEnumerable<string> GetOnlineUsers(ulong serverId)
        {
            serverId = ServerIds.Gatewood;

            DiscordGuild guild;
            client.Guilds.TryGetValue(serverId, out guild);


            var memberList = guild.VoiceStates.Where(vs => vs.Channel != guild.AfkChannel && vs.Channel != null).Select(vs => vs.User);
            var usernameList = memberList.Select(u => u.Username);
            return usernameList;
        }
    }
}