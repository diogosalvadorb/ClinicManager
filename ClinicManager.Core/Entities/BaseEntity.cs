namespace ClinicManager.Core.Entities
{
    public class BaseEntity
    {
        protected BaseEntity() { }
        public Guid Id { get; set; }
    }
}
