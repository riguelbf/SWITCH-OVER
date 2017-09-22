namespace SWITCH_OVER.Shared.Commands
{
	public abstract class CommandResponse : ICommand
	{
		//public static CommandResponse Ok = new CommandResponse { Success = true };
		//public static CommandResponse Fail = new CommandResponse { Success = false };

		protected CommandResponse(bool success = false)
		{
			Success = success;
		}

		protected bool Success { get; }
	}
}
