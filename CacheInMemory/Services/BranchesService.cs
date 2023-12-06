using CacheInMemory.Cache;
using CacheInMemory.DTOs;
using CacheInMemory.Model;
using Mapster;

namespace CacheInMemory.Services
{
    public class BranchesService(ICacheContext cache, IDataContext context) : IBranchesService
    {
        public List<BranchDTO> GetBranches() => cache.Branches.Adapt<List<BranchDTO>>();
        
        public async Task CreateBranchAsync(BranchDTO branch)
        {
            try
            {
                context.Branches.Add(new Branch { 
                    CountryCode = branch.CountryCode,
                    Name = branch.Name,
                    Description = branch.Description,
                });

                await context.SaveChangesAsync();
                cache.CleanBranchesCache();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateBranchAsync(string branchName, BranchDTO branch)
        {
            try
            {
                var oldBranch = context.Branches.FirstOrDefault(x => x.Name.ToUpper().Equals(branchName.Trim().ToUpper()));

                if (oldBranch != null)
                {
                    oldBranch.Name = branch.Name;
                    oldBranch.Description = branch.Description;
                    oldBranch.CountryCode = branch.CountryCode;
                }

                await context.SaveChangesAsync();
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
                var oldBranch = context.Branches.FirstOrDefault(x => x.Name.ToUpper().Equals(branchName.Trim().ToUpper()));

                if (oldBranch != null)
                {
                    context.Branches.Remove(oldBranch);
                }

                await context.SaveChangesAsync();
                cache.CleanBranchesCache();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
