using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace DSharpWrapperBotTest.Actions
{
    [SlashCommandGroup("Examples","Example Commands", true)]
    public class ExampleAction : ApplicationCommandModule
    {
        [SlashCommand("helloge", "Say Hello to the world", true)]
        public async Task SayHelloAsync(InteractionContext ctx,
            [Option("Username", "Whom to greet", false)] string worldName = "world")
        {
            await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"Hello {worldName}"));
        }
    }
}