namespace SWITCH_OVER.Shared.Commands
{
	public abstract class CommandResponse : Command
	{
		//public static CommandResponse Ok = this ne CommandResponse { Success = true };
		//public static CommandResponse Fail = new CommandResponse { Success = false };

		protected CommandResponse(bool success = false)
		{
			Success = success;
		}

		protected bool Success { get; }
	}
}
