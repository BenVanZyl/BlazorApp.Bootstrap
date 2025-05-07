
// TODO: Move to SnowStorm component


namespace BlazorApp.Bootstrap.Data.Infrastructure.DomainEntities
{
    public interface IDomainEntity
    {
    }

    public class DomainEntity : IDomainEntity
    {
    }

    public class DomainEntityWithId : DomainEntity
    {
        public long Id { get; set; }
    }
}
