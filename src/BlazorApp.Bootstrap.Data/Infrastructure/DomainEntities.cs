
// TODO: Move to SnowStorm component


namespace BlazorApp.Bootstrap.Data.Infrastructure.DomainEntities
{
    public interface IDomainEntity
    {
    }

    public class DomainEntity : IDomainEntity
    {

        public virtual void Save<T>(T entity) where T : DomainEntity
        {
            // Save logic for the entity, e.g., using a DbContext
            // This is just a placeholder; actual implementation would depend on the data access layer used.
            throw new NotImplementedException("Save method needs to be implemented in the derived class.");
        }
    }

    public class DomainEntityWithId : DomainEntity
    {
        public long Id { get; set; }
    }

    public class DomainEntityWithIdString : DomainEntity
    {
        public string Id { get; set; } = string.Empty;
    }
}
