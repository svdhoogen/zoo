using Zoo.Core.Repositories;

namespace Zoo.Core
{
    public interface IUnitOfWork
    {
        IZebraRepository Zebras { get; }
        IGiraffeRepository Giraffes { get; }
    }
}