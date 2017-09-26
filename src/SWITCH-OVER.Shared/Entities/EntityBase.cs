namespace SWITCH_OVER.Shared.Entities
{
	/// <summary>
	/// Abstract class responsible for aggregated type and responsible 
	/// </summary>
	public abstract class EntityBase<TIdentity>
	{
		/// <summary>
		/// Primary key property
		/// </summary>
		protected TIdentity Id { get; set; }
	}
}
