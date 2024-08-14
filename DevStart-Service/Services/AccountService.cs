using DevStart_DataAccsess.Identity;
using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevStart_Service.Services
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<AppRole> _roleManager;

		public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		public async Task<IdentityResult> RegisterUserAsync(RegisterViewModel model)
		{
			var user = new AppUser { UserName = model.UserName, Email = model.Email };
			return await _userManager.CreateAsync(user, model.Password);
		}

		public async Task<SignInResult> LoginUserAsync(LoginViewModel model)
		{
			return await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
		}

		public async Task LogoutUserAsync()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel model)
		{
			var user = await _userManager.GetUserAsync(Thread.CurrentPrincipal.Identity);
			return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
		}

		public async Task<IdentityResult> AssignRoleAsync(AssignRoleViewModel model)
		{
			var user = await _userManager.FindByIdAsync(model.UserId);
			return await _userManager.AddToRoleAsync(user, model.Role);
		}

		public async Task<IList<string>> GetRolesAsync(AppUser user)
		{
			return await _userManager.GetRolesAsync(user);
		}
	}
}
