using DevStart_DataAccsess.Contexts;
using DevStart_DataAccsess.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Service.Extensions
{
	public static class DependencyExtensions
	{
		public static void AddExtensions(this IServiceCollection services)
		{
			services.AddIdentity<AppUser, AppRole>(
				opt =>
				{
					opt.Password.RequiredLength = 6;    //default 6 karakter
					opt.Password.RequireNonAlphanumeric = true;
					opt.Password.RequireUppercase = true;
					opt.Password.RequireLowercase = true;
					opt.Password.RequireDigit = true;

					opt.User.RequireUniqueEmail = true;  //aynı email adresinin tekrar kullanılmasına izin vermez.
					/*opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyz0123456789";*/ //kullanıcı adı girilirken bunlardan başka birkarakter girilmesine izin vermez.
					opt.Lockout.MaxFailedAccessAttempts = 3;  //default 5
					opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default 5
				}).AddEntityFrameworkStores<DevStartContext>();
		}
	}

}
