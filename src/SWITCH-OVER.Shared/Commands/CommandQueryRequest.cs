using SWITCH_OVER.Shared.Enums;

namespace SWITCH_OVER.Shared.Commands
{
	public abstract class CommandQueryRequest : Command

	{
		public int OffSet { get; set; }
		public int Limit { get; set; }
		public OrdinationType OrderType { get; set; }
	}
}
