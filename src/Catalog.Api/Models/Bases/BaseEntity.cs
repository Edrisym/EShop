namespace Catalog.Api.Models.Bases;

public abstract class BaseEntity<TKey>
{
    protected BaseEntity(
        TKey id,
        DateTime timeOfGeneration,
        bool isDeleted = false,
        DateTime? timeOfDeletion = null,
        DateTime? timeOfEdition = null)
    {
        Id = id;
        IsDeleted = isDeleted;
        TimeOfGeneration = timeOfGeneration;
        TimeOfDeletion = timeOfDeletion;
        TimeOfEdition = timeOfEdition;
    }

    public TKey Id { get; private init; }
    public DateTime TimeOfGeneration { get; private init; } = DateTime.UtcNow;
    public bool IsDeleted { get; protected set; }
    public DateTime? TimeOfDeletion { get; protected set; } = default!;
    public DateTime? TimeOfEdition { get; protected set; } = default!;
}