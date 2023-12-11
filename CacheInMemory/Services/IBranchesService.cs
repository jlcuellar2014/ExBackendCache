using CacheInMemory.DTOs;

namespace CacheInMemory.Services
{
    public interface IBranchesService
    {
        Task CreateAsync(BranchCreateDTO branch);
        Task DeleteAsync(string branchName);
        Task<List<BranchReadDTO>> GeAsync();
        Task UpdateAsync(string branchName, BranchUpdateDTO branch);
    }
}