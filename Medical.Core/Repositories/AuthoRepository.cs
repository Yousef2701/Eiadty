﻿using Medical.Core.Dtos;
using Medical.Core.Helpers;
using Medical.Core.Interfaces;
using Medical.EF.Data;
using Medical.EF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Medical.EF.Repositories
{
    public class AuthoRepository : IAuthoRepository
    {

        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly JWT _jWT;

        public AuthoRepository(UserManager<ApplicationIdentityUser> userManager,
                               ApplicationDbContext context,
                               IOptions<JWT> jWT)
        {
            _userManager = userManager;
            _context = context;
            _jWT = jWT.Value;
        }

        public async Task<AuthModel> RegisterAsync(RegisterDTO dto, string role)
        {
            var email = dto.Phone + "@Gmail.Com";
            var emailfound = await _userManager.FindByEmailAsync(email.ToUpper());
            if (emailfound is not null)
            {
                return new AuthModel
                {
                    Message = "This Phone number is already in use"
                };
            }
            if (dto.Password != dto.CheckPassword)
            {
                return new AuthModel
                {
                    Message = "Check Password is not correct"
                };
            }
            var user = new ApplicationIdentityUser
            {
                PhoneNumber = dto.Phone,
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AuthModel { Message = "Something went wrong in creating this account" };
            }
            await _userManager.AddToRoleAsync(user, role);

            var JwtSecurityToken = await CreateJwtToken(user);

            return new AuthModel
            {
                Phone = dto.Phone,
                //SExpiration = JwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Role = role,
                Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken),
            };
        }

        public async Task<string> DeleteUser(ApplicationIdentityUser user)
        {
            await _userManager.DeleteAsync(user);
            return "ok";
        }

        public async Task<JwtSecurityToken> CreateJwtToken(ApplicationIdentityUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            foreach (var role in roles)
                roleClaims.Add(new Claim(ClaimTypes.Role, role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Prn,user.PhoneNumber)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWT.key));
            var signingCredentioals = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jWT.Issuer,
                audience: _jWT.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jWT.DurationInDays),
                signingCredentials: signingCredentioals);

            return jwtSecurityToken;
        }

        public async Task<ApplicationIdentityUser> GetUser(string phone)
        {
            var user = await _userManager.FindByEmailAsync(phone + "@Gmail.com".ToUpper());
            return user;
        }

        public async Task<AuthModel> GetTokenAsync(LogInDTO model)
        {
            var authModel = new AuthModel();
            var user = await _userManager.FindByEmailAsync(model.Phone + "@Gmail.com".ToUpper());
            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Phone or Password is incorrect";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);

            authModel.Phone = model.Phone;
            authModel.Role = _userManager.GetRolesAsync(user).ToString();
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            //authModel.Expiration = jwtSecurityToken.ValidTo;

            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                authModel.RefreshToken = activeRefreshToken.Token;
                authModel.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authModel.RefreshToken = refreshToken.Token;
                authModel.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }

            return authModel;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return true;
        }

        public async Task<string> GetRole(string phone)
        {
            string email = phone + "@gmail.com";

            var user = _context.Users.Where(m => m.Email == email).FirstOrDefault();

            if (user != null)
            {
                string roleid = _context.UserRoles.Where(m => m.UserId == user.Id).Select(m => m.RoleId).FirstOrDefault();
                string role = _context.Roles.Where(m => m.Id == roleid).Select(m => m.Name).FirstOrDefault();

                return role;
            }
            return "";
        }

        public async Task<string> AppendAccount(string phone)
        {
            if(phone is not null)
            {
                var user = _context.Users.Where(m => m.Email == phone + "@Gmail.Com").SingleOrDefault();
                if(user is not null)
                {
                    user.EmailConfirmed = false;
                    await _userManager.UpdateAsync(user);

                    return "User is Appended";
                }
                return "User Not Found!";
            }
            return "Phone is Required!";
        }

        public async Task<string> ActivateAccount(string phone)
        {
            if (phone is not null)
            {
                var user = _context.Users.Where(m => m.Email == phone + "@Gmail.Com").SingleOrDefault();
                if (user is not null)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);

                    return "User is Activate";
                }
                return "User Not Found!";
            }
            return "Phone is Required!";
        }

        public async Task<string> IsAccountAvtive(string phone)
        {
            if (phone is not null)
            {
                var user = _context.Users.Where(m => m.Email == phone + "@Gmail.Com").SingleOrDefault();
                if (user is not null)
                {
                    bool check = user.EmailConfirmed;

                    if (check)
                        return "true";
                    else
                        return "false";
                }

                return "User Not Found!";
            }
            return "Phone is required!";
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),

                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }
    }
}
