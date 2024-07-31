namespace FiringRange.Code.Services.EntityContainer
{
    public interface IEntityContainer : IGlobalService
    {
        void RegisterEntity<TEntity>(TEntity entity) where TEntity : class, IFactoryEntity;
        TEntity GetEntity<TEntity>() where TEntity : class, IFactoryEntity;
    }
}