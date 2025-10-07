using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Dtos;
using Schoolmanagement.Domain.Entities.Identity;
using Schoolmanagement.Domain.Helper;
using Schoolmanagement.Domain.Results;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Service.IServices;
using System.Security.Claims;


namespace SchoolManagement.Service.Services
{
    public class AutherizationService : IAutherizationService
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        #endregion
        #region Constructors
        public AutherizationService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
        #endregion
        public async Task AddAsync(IdentityRole entity)
        {
            var result = await _roleManager.CreateAsync(entity);
            if (!result.Succeeded)
            {
                throw new Exception();
            }
        }

        public async Task DeleteAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            await _roleManager.DeleteAsync(role!);
        }

        public async Task<bool> ExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<IEnumerable<IdentityRole>> GetAllAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole> GetByIdAsync(string id)
        {
            return (await _roleManager.FindByIdAsync(id))!;
        }

        public async Task<ManageUserClaimsResult> GetClaimsForUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var response = new ManageUserClaimsResult();
            var usercliamsList = new List<UserClaims>();
            response.UserName = user!.Id;
            //Get USer Claims
            var userClaims = await _userManager.GetClaimsAsync(user!); //edit
                                                                       //create edit get print
            foreach (var claim in ClaimStore.claims)
            {
                var userclaim = new UserClaims();
                userclaim.Type = claim.Type;
                if (userClaims.Any(x => x.Type == claim.Type))
                {
                    userclaim.Value = true;
                }
                else
                {
                    userclaim.Value = false;
                }
                usercliamsList.Add(userclaim);
            }
            response.userClaims = usercliamsList;
            //return Result
            return response;
        }

        public async Task<List<UserRoles>> GetRolesForUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var userRoleNames = await _userManager.GetRolesAsync(user!);

            // Get all roles from the RoleManager
            var allRoles = await _roleManager.Roles.ToListAsync();

            var rList = new List<UserRoles>();
            foreach (var roleName in userRoleNames)
            {
                var role = allRoles.FirstOrDefault(r => r.Name == roleName);
                if (role != null)
                {
                    rList.Add(new UserRoles
                    {
                        RoleId = role.Id,
                        RoleName = role.Name!,
                        HasRole = true
                    });
                }
            }
            return rList;
        }

        public async Task<bool> IsExistByIdAsync(string id)
        {
            return await _roleManager.FindByIdAsync(id) != null;
        }

        public async Task<bool> RoleUsedAsync(string roleName)
        {
            var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
            return usersInRole != null && usersInRole.Any();
        }

        public async Task UpdateAsync(IdentityRole entity)
        {
            var currentRole = await _roleManager.FindByIdAsync(entity.Id);
            if (currentRole != null)
            {
                currentRole.Name = entity.Name;
                var result = await _roleManager.UpdateAsync(currentRole);
                if (!result.Succeeded)
                { throw new Exception(); }
            }
        }

        public async Task<bool> UpdateClaimsForUserAsync(UpdateUserClaimsRequest request)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(request.UserName);
                    var oldClaims = await _userManager.GetClaimsAsync(user!);
                    var removedClaims = await _userManager.RemoveClaimsAsync(user!, oldClaims);
                    if (!removedClaims.Succeeded)
                    {
                        return false;
                    }
                    var newClaims = new List<Claim>();
                    foreach (var claim in request.userClaims)
                    {
                        if (claim.Value == true)
                            newClaims.Add
                                (
                                    new Claim(claim.Type, claim.Value.ToString())
                                );
                    }
                    var added = await _userManager.AddClaimsAsync(user!, newClaims);
                    if (!added.Succeeded)
                    {
                        await transaction.RollbackAsync();
                        return false;
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }

        public async Task<bool> UpdateUserRolesAsync(UpdateUserRoleRequest request)
        {
            // Start a new transaction
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Get User
                    var user = await _userManager.FindByNameAsync(request.UserName);
                    // Get Current Roles of user
                    var roles = await _userManager.GetRolesAsync(user!);
                    //Delete User Roles 
                    var rDeleted = await _userManager.RemoveFromRolesAsync(user!, roles);
                    if (!rDeleted.Succeeded)
                        return false;
                    // create list of New Roles
                    var newRoles = request.UserRoles.Where(x => x.HasRole == true).Select(s => s.RoleName).ToList();
                    var rAdd = await _userManager.AddToRolesAsync(user!, newRoles);
                    if (!rAdd.Succeeded)
                    {
                        await transaction.RollbackAsync();
                        return false;
                    }
                    // Commit transaction if all succeeded
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception)
                {
                    // Rollback transaction on error
                    await transaction.RollbackAsync();
                    return false;
                }
            }

        }

    }
}
