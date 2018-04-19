using  Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using System.Reflection;
using System.Threading.Tasks;

namespace WerewolfBot
{
    public class CommandHandler
    {
        private CommandService _service;
        private DiscordSocketClient _client;
        private char prefix = '$';
        public CommandHandler(DiscordSocketClient client)

        {
            _client = client;
            _service = new CommandService();
            _service.AddModulesAsync(Assembly.GetEntryAssembly());


            _client.MessageReceived += HandleCommandAsync;

        }


        private async Task HandleCommandAsync(SocketMessage s)
        {
            
            var msg = s as SocketUserMessage;

            if(msg == null)
            {
                return;
            }

            var context = new SocketCommandContext(_client, msg);
            int argPos = 0;

            if(msg.HasCharPrefix(prefix, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);
               
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync("Error Processing Command \n" + result.ErrorReason);
                }

            }
        }
    }
}
