using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace WerewolfBot
{
    public class GameEngine : ModuleBase<SocketCommandContext>
    {
        private newLobby lobby;
        //HELLO THIS IS AWESOME
        //IKR




            //Hello this is a test

            //Yes
        public GameEngine()
        {

        }



        [Command("newTest")]
        public async Task test()
        {
            await Context.Channel.SendMessageAsync("Yes this was extenedd");
        }


    }
}
