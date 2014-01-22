namespace Core.Interfaces
{
    public interface IEntity<T> where T : struct
    {
        T Id { get; }
    }
}
    