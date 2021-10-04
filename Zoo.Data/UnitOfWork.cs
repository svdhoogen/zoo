using Zoo.Core;
using Zoo.Core.Repositories;
using Zoo.Data.Repositories;

namespace Zoo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IGiraffeRepository _giraffeRepository;
        private IZebraRepository _zebraRepository;

        public IGiraffeRepository Giraffes => _giraffeRepository ??= new GiraffeRepository();

        public IZebraRepository Zebras => _zebraRepository ??= new ZebraRepository();
    }
}