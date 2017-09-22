namespace SWITCH_OVER.Shared.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
	    void Handle(T command);
	}
}
