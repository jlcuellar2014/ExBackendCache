using CacheInMemory.DTOs;

namespace CacheInMemory.Services
{
    public interface IBranchesService
    {
        List<BranchReadDTO> GetBranches();
        Task CreateBranchAsync(BranchCreateDTO branch);
        Task DeleteBranchAsync(string branchName);
        Task UpdateBranchAsync(string branchName, BranchUpdateDTO branch);
    }
}