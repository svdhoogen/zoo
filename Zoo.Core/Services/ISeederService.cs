using System.Threading.Tasks;

namespace Zoo.Core.Services
{
    public interface ISeederService
    {
        /// <summary>
        /// Seeds the current environment.
        /// </summary>
        /// <returns></returns>
        Task SeedAsync();
    }
}