﻿using CacheInMemory.Model;

namespace CacheInMemory.Repositories
{
    public interface IBranchesRespository
    {
        Task CreateAsync(Branch newBranch);
        Task DeleteAsync(string branchName);
        Task<List<Branch>> GetAsync();
        Task UpdateAsync(string branchName, Branch branch);
    }
}