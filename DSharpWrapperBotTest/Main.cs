using System;
using CloudTheWolf.DSharpPlus.Scaffolding.Logging;
using CloudTheWolf.DSharpPlus.Scaffolding.Shared.Interfaces;
using DSharpPlus;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpWrapperBotTest.Actions;
using DSharpWrapperBotTest.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DSharpWrapperBotTest
{
    public class Main : IPlugin
    {

        public string Name => "DiscordBotPlugin";
        public string Description => "Beschreibung";
        public int Version => 1;
        
        //Declaration of Configs and other components
        public static ILogger<Logger> Logger;
        public static InteractivityExtension Interactivity;
        public static DiscordClient Client;
        private static DiscordConfiguration _discordConfiguration;
        private static IConfiguration _applicationConfig;
        
        //Plugin initializer
        public void InitPlugin(IBot bot,ILogger<Logger> logger,DiscordConfiguration discordConfiguration,IConfigurationRoot applicationConfig)
        {
            // Setup Plugin here
            
            //Runs once at the start, setting up our
            //Logger, Interactivity, Client, Intents and registers our commands
            try
            {
                Logger = logger;
                _discordConfiguration = discordConfiguration;
                logger.LogInformation(this.Name + ": Loaded");
                //SetOptions(applicationConfig,bot);
                Interactivity = bot.Client.GetInteractivity();
                bot.Client.Intents.AddIntent(DiscordIntents.All);
                Client = bot.Client;
                AddCommands(bot, Name);
            }
            catch (Exception e)
            {
                logger.LogError("Failed to load {Name} \\n {EMessage}", Name, e.Message);
            }
        }
        
        //Loading settings into the config
        private static void LoadConfig(IConfiguration applicationConfig, IBot bot)
        {
            Option.Options.MySetting = applicationConfig.GetValue<string>("MySetting");
        }
        
        //Loads commands
        private static void AddCommands(IBot bot, string name)
        {
            bot.SlashCommandsExt.RegisterCommands<ExampleAction>();
            Logger.LogInformation($"{name} has Registered ExampleAction Slash Commands");
            
            bot.Commands.RegisterCommands<ExampleCommand>();
            Logger.LogInformation($"{name} has Registered Example Command");
        }
        
    }
}