using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PetTransport.Domain.Entities;
using PetTransport.Infrastructure.Data;

namespace PetTransport.Web;

	public class AdditionalUserClaimsPrincipalFactory
			: UserClaimsPrincipalFactory<User, IdentityRole>
	{
		private readonly ApplicationDbContext _context;

		public AdditionalUserClaimsPrincipalFactory(
			UserManager<User> userManager,
			RoleManager<IdentityRole> roleManager,
			IOptions<IdentityOptions> optionsAccessor,
			ApplicationDbContext context)
			: base(userManager, roleManager, optionsAccessor)
		{
			_context = context;
		}

		public override async Task<ClaimsPrincipal> CreateAsync(User user)
		{
			var principal = await base.CreateAsync(user);
			var identity = (ClaimsIdentity)principal.Identity;

			var userInDb = _context.Users.FirstOrDefault(s => s.Id == user.Id);
			var res = userInDb.ImageUrl;
			identity.AddClaim(new Claim("ImageUrl", res));

			return principal;
		}
	}
