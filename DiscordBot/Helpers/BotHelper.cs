using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Helpers
{
    public class BotHelper
    {
        private DiscordClient client;
        public BotHelper(DiscordClient client)
        {
            this.client = client;
        }
        public async Task RunBotAsync()
        {
            this.client.Ready += Client_Ready;
            this.client.GuildAvailable += Client_GuildAvailable;
            this.client.ClientErrored += Client_ClientErrored;
            this.client.MessageCreated += Client_MessageCreated;

            await this.client.ConnectAsync();
        }

        private Task Client_ClientErrored(DSharpPlus.EventArgs.ClientErrorEventArgs e)
        {
            client.DebugLogger.LogMessage(LogLevel.Error, "Exception Occurred", e.Exception.Message, DateTime.Now);
            return Task.CompletedTask;
        }

        private Task Client_GuildAvailable(DSharpPlus.EventArgs.GuildCreateEventArgs e)
        {
            client.DebugLogger.LogMessage(LogLevel.Info, null, $"Guild available: {e.Guild.Name}", DateTime.Now);
            return Task.CompletedTask;
        }

        private Task Client_Ready(DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            client.DebugLogger.LogMessage(LogLevel.Info, null, "Client is ready to process Events.", DateTime.Now);
            return Task.CompletedTask;
        }

        private async Task Client_MessageCreated(DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            if (string.Equals(e.Message.Content, "hello", StringComparison.OrdinalIgnoreCase))
            {
                await e.Message.RespondAsync(e.Message.Author.Username);
            }
        }
    }
}
