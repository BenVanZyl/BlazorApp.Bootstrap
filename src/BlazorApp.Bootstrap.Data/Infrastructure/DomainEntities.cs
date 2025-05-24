
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

    public class DomainEntityWithIdString : DomainEntity
    {
        public string Id { get; set; } = string.Empty;
    }
}
