using System.Threading.Tasks;

namespace Zoo.Core.Data
{
    public interface ISeeder
    {
        /// <summary>
        /// Runs the seeder logic
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        Task SeedAsync(IUnitOfWork unitOfWork);
    }
}