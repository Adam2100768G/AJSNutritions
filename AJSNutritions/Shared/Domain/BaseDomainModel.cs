namespace AJSNutritions.Shared.Domain
{
	/*
	 * BaseDomainModel is the base class for all domain models in the application.
	 * It has properties to log when an entity was created or changed.
	 */
	public abstract class BaseDomainModel
	{
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateUpdated { get; set; }
		public string? CreatedBy { get; set; }
		public string? UpdatedBy { get; set; }
	}
}
