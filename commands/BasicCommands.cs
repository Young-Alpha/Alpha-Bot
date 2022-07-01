using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace ConsoleApp1.commands
{
    public class BasicCommands : BaseCommandModule
    {
        [Command("Ping")]
        [Description("the basic beginner command to send a reply")]
        public async Task Ping(CommandContext ctx)
        {
            ctx.Channel.SendMessageAsync("imagine if i made this a nuker lol").ConfigureAwait(false);
        }
        [Command("Beam")]
        public async Task beam(CommandContext ctx, DiscordMember User, string Nickname)
        {
            DiscordMember discordMember = User;
            var OldNick = discordMember.Nickname;
            await ctx.TriggerTypingAsync();
            tryz
            {
                await discordMember.ModifyAsync(x => x.Nickname = Nickname);
                var newNick = discordMember.Nickname;
                await ctx.Channel.SendMessageAsync($"{ctx.Member.Username} beaming succesful").ConfigureAwait(false);
                newNick = "";


            }
            catch (Exception e)
            {
                await ctx.Channel.SendMessageAsync("AN ERROR OCCOURED or my code just sucks" ).ConfigureAwait(false);
            }
            
        }

    }
}
