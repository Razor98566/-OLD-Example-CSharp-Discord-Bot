using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DSharpWrapperBotTest.Commands
{
    public class ExampleCommand : BaseCommandModule
    {
        [Command("goodbye")]
        [Aliases(new string[] { "bye", "gb" })]
        [Description("Say Goodbye To  The World")]
        public async Task GoodbyeAsync(CommandContext ctx, string worldName = "world", [RemainingText] string extra = null)
        {
            await ctx.RespondAsync($"{ctx.Message.Author.Mention} says Goodbye {worldName}");
        }
    }
}