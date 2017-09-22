namespace SWITCH_OVER.Shared.Entities
{
	/// <summary>
	/// Abstract class responsible for aggregated type and responsible 
	/// </summary>
	public abstract class EntityBase<TIdentity>
	{
		protected TIdentity Id { get; set; }
	}
}
