using CacheInMemory.DTOs;
using CacheInMemory.Model;

namespace CacheInMemory.Repositories
{
    public interface IBranchesRespository
    {
        Task CreateBranchAsync(Branch newBranch);
        Task DeleteBranchAsync(string branchName);
        List<Branch> GetBranches();
        Task UpdateBranchAsync(string branchName, Branch branch);
    }
}