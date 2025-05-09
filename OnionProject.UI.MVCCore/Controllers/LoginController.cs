using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnionProject.Application.Layer.Models.DTOs.Login;
using OnionProject.Application.Layer.Models.ViewModels.Login;
using OnionProject.Application.Layer.Services.Login;
using OnionProject.Core.Layer.Entities;

namespace OnionProject.UI.MVCCore.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        private readonly SignInManager<Uye> signInManager;
        private readonly IMapper mapper;
        public LoginController(ILoginService _loginService, SignInManager<Uye> _signInManager, IMapper _mapper)
        {
            loginService = _loginService;
            signInManager = _signInManager;
            mapper = _mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var result = await loginService.LoginAsync(login);
                if (result.UyeId != -1)
                {
                    //var user = await signInManager.UserManager.FindByIdAsync(result.UyeId.ToString());
                    await signInManager.SignInAsync(await loginService.UyeGetirAsync(result.UyeId), isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                }
            }
            return View(login);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (ModelState.IsValid)
            {
                RegisterDTO registerDTO = new RegisterDTO();
                mapper.Map(register, registerDTO);
                var result = await loginService.RegisterAsync(registerDTO);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Kayıt işlemi başarısız.");
                }
            }
            return View(register);
        }
    }
}
