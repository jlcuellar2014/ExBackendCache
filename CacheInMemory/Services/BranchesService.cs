using CacheInMemory.DTOs;
using CacheInMemory.Model;
using CacheInMemory.Repositories;
using Mapster;

namespace CacheInMemory.Services
{
    public class BranchesService(IBranchesRespository repo) : IBranchesService
    {
        public async Task<List<BranchReadDTO>> GeAsync()
        {
            var branches = await repo.GeAsync();
            return branches.Adapt<List<BranchReadDTO>>();
        }

        public async Task CreateAsync(BranchCreateDTO branch)
            => await repo.CreateAsync(branch.Adapt<Branch>());

        public async Task UpdateAsync(string branchName, BranchUpdateDTO branch)
            => await repo.UpdateAsync(branchName, branch.Adapt<Branch>());

        public async Task DeleteAsync(string branchName)
            => await repo.DeleteAsync(branchName);
    }
}
