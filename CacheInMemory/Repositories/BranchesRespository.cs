using CacheInMemory.Cache;
using CacheInMemory.Model;

namespace CacheInMemory.Repositories
{
    public class BranchesRespository(ICacheContext cache, IDataContext data) : IBranchesRespository
    {
        public List<Branch> GetAll() => cache.GetBranches();

        public async Task CreateAsync(Branch newBranch)
        {
            try
            {
                data.Branches.Add(newBranch);

                await data.SaveChangesAsync();

                cache.CleanBranchesCache();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(string branchName, Branch branch)
        {
            try
            {
                var oldBranch = data.Branches.FirstOrDefault(x => x.Name.ToUpper().Equals(branchName.Trim().ToUpper())) ??
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

        public async Task DeleteAsync(string branchName)
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
