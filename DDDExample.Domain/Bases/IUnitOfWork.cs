namespace DDDExample.Domain.Bases
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> GuardarCambiosAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
