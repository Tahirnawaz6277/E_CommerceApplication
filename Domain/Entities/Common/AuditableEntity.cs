namespace Domain.Entities.Common
{
    public abstract class AuditableEntity
    {
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public void MarkAsDelete()
        {
            DeletedOn = DateTime.Now;
        }
    }
}
