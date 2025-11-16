namespace LinkDev.Talabat.Domain.Common
{
    public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public required TKey Id { get; set; }
    }
}
