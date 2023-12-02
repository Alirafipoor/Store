using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Application.Services.Commands.EditUser;
using Store.Application.Services.Commands.RegisterUser;
using Store.Application.Services.Commands.RemoveUser;
using Store.Application.Services.Commands.UserStatusChange;

using Store.Application.Services.User.Queries.GetRole;
using Store.Application.Services.User.Queries.GetUser;
using Store.Domain.Entites.Users;
using System.Collections.Generic;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IGetUserService _getUserService;
        private readonly IGetRoleServices _getRoleServices;
        private readonly IRemoveUserService _removeUserService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IUserSatusChangeService _userStatuschange;
        private readonly IEditUserService _editUserService;
        public UserController(IGetUserService getuserservice,IGetRoleServices getroleservice,IRegisterUserService registerUserService, IRemoveUserService removeuserservice , IUserSatusChangeService userSatusChangeService, IEditUserService edituserservice )
        {
            _getUserService = getuserservice;
            _getRoleServices = getroleservice;
            _registerUserService = registerUserService;
            _removeUserService = removeuserservice;
            _userStatuschange = userSatusChangeService;
            _editUserService = edituserservice;
        }
        public IActionResult Index(string SearchKey,int page)
        {
            return View(_getUserService.Execute(new RequestGetUser
            {
                SearchKey = SearchKey,
                page = page
            })
            );
        }
        [HttpGet]
        public IActionResult create()
        {
            ViewBag.Roles = new SelectList(_getRoleServices.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            List<Role> roles = new List<Role>()
            {
                new Role
                {
                    Id = RoleId,
                }
            };

            
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,

                Password = Password,
                RePasword = RePassword,
            }) ;
            return Json(result);
        }


        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_userStatuschange.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string Fullname)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = Fullname,
                UserId = UserId,
            }));
        }
    }
}
