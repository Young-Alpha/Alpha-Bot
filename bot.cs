using System.IO;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension commands { get; private set; }
        public async Task RunAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configjson = JsonConvert.DeserializeObject<configjson>(json);

            var config = new DiscordConfiguration
            {
                Token = configjson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,

            };

            Client = new DiscordClient(config);

            var commandsconfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configjson.Prefix },
                EnableDms = true,
                EnableMentionPrefix = true, 
                CaseSensitive = false,
                IgnoreExtraArguments = true,
                
            };

            commands = Client.UseCommandsNext(commandsconfig);

            commands.RegisterCommands<BasicCommands>();
             

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }
        private Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
