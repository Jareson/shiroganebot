using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shiroganebot.Modules
{
	// Create a module with the 'sample' prefix
	[Group("sample")]
	public class SampleModule : ModuleBase<SocketCommandContext>
	{
		// ~sample square 20 -> 400
		[Command("square")]
		[Summary("Squares a number.")]
		public async Task SquareAsync([Summary("The number to square.")] int num)
		{
			// We can also access the channel from the Command Context.
			await Context.Channel.SendMessageAsync($"{num}^2 = {Math.Pow(num, 2)}");
		}

		[Command("deletemessage")]
		[Summary("Deletes message that called this command.")]
		public async Task DeleteMessageAsync()
		{
			await Context.Message.DeleteAsync();
			await ReplyAsync("Message Deleted");
		}
	}
}
