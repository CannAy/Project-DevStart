using DevStart_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevStart_Entity.Interfaces
{
	public interface IAccountService
	{
		Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);
		Task<SignInResult> LoginUserAsync(LoginViewModel model);
		Task LogoutUserAsync();
		Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel model);
		Task<IdentityResult> AssignRoleAsync(AssignRoleViewModel model);
		Task<IList<string>> GetRolesAsync(AppUser user);
	}
}
