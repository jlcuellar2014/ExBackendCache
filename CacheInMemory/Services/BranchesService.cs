using CacheInMemory.Cache;
using CacheInMemory.DTOs;
using CacheInMemory.Model;
using Mapster;

namespace CacheInMemory.Services
{
    public class BranchesService(ICacheContext cache, IDataContext data) : IBranchesService
    {
        public List<BranchReadDTO> GetBranches() => cache.Branches.Adapt<List<BranchReadDTO>>();
        
        public async Task CreateBranchAsync(BranchCreateDTO branch)
        {
            try
            {
                data.Branches.Add(new Branch { 
                    CountryCode = branch.CountryCode,
                    Name = branch.Name,
                    Description = branch.Description,
                });

                await data.SaveChangesAsync();
                cache.CleanBranchesCache();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateBranchAsync(string branchName, BranchUpdateDTO branch)
        {
            try
            {
                var oldBranch = data.Branches.FirstOrDefault(x => x.Name.ToUpper().Equals(branchName.Trim().ToUpper()))??
                    throw new ArgumentException("There is no brach with this name.", nameof(branchName));

                if (branch.Name != null)
                    oldBranch.Name = branch.Name ?? string.Empty;

                if (branch.Description != null)
                    oldBranch.Description = branch.Description;

                if (branch.CountryCode != null)
                    oldBranch.CountryCode = branch.CountryCode ?? string.Empty;

                await data.SaveChangesAsync();
                cache.CleanBranchesCache();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteBranchAsync(string branchName)
        {
            try
            {
                var oldBranch = data.Branches.FirstOrDefault(x => x.Name.ToUpper().Equals(branchName.Trim().ToUpper())) ??
                   throw new ArgumentException("There is no brach with this name.", nameof(branchName));

                data.Branches.Remove(oldBranch);

                await data.SaveChangesAsync();
                cache.CleanBranchesCache();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
