using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetTransport.Domain;
using PetTransport.Domain.Entities;
using PetTransport.Infrastructure.Data;
using PetTransport.Infrastructure.Email;
using PetTransport.Web.Models;

public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = new User {Email = model.Email, UserName = model.Email};
        //        // добавляем пользователя
        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            // генерация токена для пользователя
        //            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //            var callbackUrl = Url.Action(
        //                "ConfirmEmail",
        //                "Account",
        //                new {userId = user.Id, code = code},
        //                protocol: HttpContext.Request.Scheme);
        //            EmailService emailService = new EmailService();
        //            await emailService.SendEmailAsync(model.Email, "Confirm your account",
        //                $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");

        //            return Content(
        //                "Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }

        //    return View(model);
        //}


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, ImageUrl = "medium_male_default.png"};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                     var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                     
                     EmailService emailService = new EmailService();
                     await emailService.SendEmailAsync(model.Email, "Confirm your account",
                         $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");
                }

                return Content(
                    "Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Login", "Account");
            else
                return View("Error");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            model.ReturnUrl = "/Home/Index";
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    // if (!await _userManager.IsEmailConfirmedAsync(user))
                    // {
                    //     ModelState.AddModelError(string.Empty,
                    //         $"Вы не подтвердили свой email");
                    //     return View(model);
                    // }

                    var result =
                        await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    return View(model);
                }

                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SendActivationCode(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    // генерация токена для пользователя
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new {userId = user.Id, code = code},
                        protocol: HttpContext.Request.Scheme);
                    EmailService emailService = new EmailService();
                    await emailService.SendEmailAsync(email, "Confirm your account",
                        $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");

                    return Content(
                        "Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                }
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            ChangePasswordViewModel model = new ChangePasswordViewModel {Id = user.Id, Email = user.Email};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user) || user.IsDeleted))
                {
                    // пользователь с данным email может отсутствовать в бд
                    // тем не менее мы выводим стандартное сообщение, чтобы скрыть 
                    // наличие или отсутствие пользователя в бд 
                    return Content("Такого аккаунта не существует или email не подтвержден!");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new {userId = user.Id, code = code},
                    protocol: HttpContext.Request.Scheme);
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(model.Email, "Reset Password",
                    $"Для сброса пароля пройдите по ссылке: <a href='{callbackUrl}'>link</a>");
                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("Error") : View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return View("ResetPasswordConfirmation");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return View("ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateProfile()
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = await _userManager.FindByEmailAsync(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value);

            var profileViewModel = new UpdateProfileViewModel();
            if (user.ImageUrl != null)
            {
                profileViewModel.ProfileImage = Path.Combine(_webHostEnvironment.WebRootPath, "img", user.ImageUrl);
            }

            profileViewModel.FirstName = user.FirstName;
            profileViewModel.LastName = user.LastName;
            profileViewModel.Location = user.Location;
            profileViewModel.ProfileImage = user.ImageUrl;

            return View(profileViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProfile([FromForm]UpdateProfileViewModel model)
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = await _userManager.FindByEmailAsync(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value);
            if (model.File != null)
            {
                user.ImageUrl = UploadedFile(model.File);
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Location = model.Location;
            await _signInManager.RefreshSignInAsync(user);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();


            var res = HttpContext.User.Claims;

            return RedirectToAction("UpdateProfile", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfileImage([FromForm]IFormFile file)
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = await _userManager.FindByEmailAsync(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value);
            user.ImageUrl = UploadedFile(file);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index", "Home");
        }

        
        private string UploadedFile(IFormFile file)  
        {  
            string uniqueFileName = null;  
  
            if (file != null)  
            {  
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;  
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);  
                using (var fileStream = new FileStream(filePath, FileMode.Create))  
                {  
                    file.CopyTo(fileStream);  
                }  
            }  
            return uniqueFileName;  
        }  
        
        [HttpGet]
        public async Task<IActionResult> DeleteAccount()
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = await _userManager.FindByEmailAsync(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value);
            user.DeleteUser();

            await _userManager.SetEmailAsync(user, $"{Guid.NewGuid().ToString()}@email.co");
            await _userManager.SetUserNameAsync(user, $"{Guid.NewGuid().ToString()}@email.co");
            await _userManager.UpdateNormalizedEmailAsync(user);
            await _userManager.UpdateNormalizedUserNameAsync(user);
            _context.Update(user);
            await _context.SaveChangesAsync();


            var usekr = await _userManager.FindByEmailAsync("dimonnn.26@gmail.com");
            
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
