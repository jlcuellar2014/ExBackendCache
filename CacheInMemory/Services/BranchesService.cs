using CacheInMemory.DTOs;
using CacheInMemory.Model;
using CacheInMemory.Repositories;
using Mapster;

namespace CacheInMemory.Services
{
    public class BranchesService(IBranchesRespository respository) : IBranchesService
    {
        public List<BranchReadDTO> GetBranches() 
            => respository.GetBranches().Adapt<List<BranchReadDTO>>();

        public async Task CreateBranchAsync(BranchCreateDTO branch)
            => await respository.CreateBranchAsync(branch.Adapt<Branch>());

        public async Task UpdateBranchAsync(string branchName, BranchUpdateDTO branch)
            => await respository.UpdateBranchAsync(branchName, branch.Adapt<Branch>());

        public async Task DeleteBranchAsync(string branchName)
            => await respository.DeleteBranchAsync(branchName);
    }
}
