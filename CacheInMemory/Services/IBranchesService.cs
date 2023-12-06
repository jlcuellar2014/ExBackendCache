using CacheInMemory.DTOs;

namespace CacheInMemory.Services
{
    public interface IBranchesService
    {
        List<BranchDTO> GetBranches();
        Task CreateBranchAsync(BranchDTO branch);
        Task DeleteBranchAsync(string branchName);
        Task UpdateBranchAsync(string branchName, BranchDTO branch);
    }
}