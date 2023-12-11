using CacheInMemory.DTOs;

namespace CacheInMemory.Services
{
    public interface IBranchesService
    {
        List<BranchReadDTO> GetAll();
        Task CreateAsync(BranchCreateDTO branch);
        Task DeleteAsync(string branchName);
        Task UpdateAsync(string branchName, BranchUpdateDTO branch);
    }
}