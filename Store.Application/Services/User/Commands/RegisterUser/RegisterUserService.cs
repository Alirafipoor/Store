using Store.Application.interfaces.Contexts;
using Store.Common;
using Store.Common.Dtos;
using Store.Domain.Entites.Users;

namespace Store.Application.Services.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;
        public RegisterUserService(IDataBaseContext con)
        {
            _context = con;
        }
        
       
            public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(request.Email))
                    {
                        return new ResultDto<ResultRegisterUserDto>()
                        {
                            Data = new ResultRegisterUserDto()
                            {
                                UserId = 0,
                            },
                            IsSuccess = false,
                            Message = "پست الکترونیک را وارد نمایید"
                        };
                    }

                    if (string.IsNullOrWhiteSpace(request.FullName))
                    {
                        return new ResultDto<ResultRegisterUserDto>()
                        {
                            Data = new ResultRegisterUserDto()
                            {
                                UserId = 0,
                            },
                            IsSuccess = false,
                            Message = "نام را وارد نمایید"
                        };
                    }
                    if (string.IsNullOrWhiteSpace(request.Password))
                    {
                        return new ResultDto<ResultRegisterUserDto>()
                        {
                            Data = new ResultRegisterUserDto()
                            {
                                UserId = 0,
                            },
                            IsSuccess = false,
                            Message = "رمز عبور را وارد نمایید"
                        };
                    }
                    if (request.Password != request.RePasword)
                    {
                        return new ResultDto<ResultRegisterUserDto>()
                        {
                            Data = new ResultRegisterUserDto()
                            {
                                UserId = 0,
                            },
                            IsSuccess = false,
                            Message = "رمز عبور و تکرار آن برابر نیست"
                        };
                    }
                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(request.Password);

                User user = new User()
                    {
                        Email = request.Email,
                        FullName = request.FullName,
                        Password = hashedPassword,
                        IsActive = true,
                };

                    List<RoleInRegisterUserDto> userInRoles = new List<RoleInRegisterUserDto>();

                    foreach (var item in request.roles)
                    {
                        var roles = _context.Roles.Find(item.Id);
                        userInRoles.Add(new RoleInRegisterUserDto
                        {
                           Id = item.Id,
                        });
                    }
                List<Role> roless = new List<Role>();
                    foreach (var role in userInRoles)
                        {
                    var roole=_context.Roles.Find(role.Id);
                        
                        roless= new List<Role>() {

                    new Role()
                        {
                            Id = roole.Id,
                            Name=roole.Name,

                        }
                    };
                }

                    user.Roles = roless;

                    _context.Users.Add(user);

                    _context.SaveChanges();

                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = user.Id,

                        },
                        IsSuccess = true,
                        Message = "ثبت نام کاربر انجام شد",
                    };
                }
                catch (Exception)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "ثبت نام انجام نشد !"
                    };
                }
            }
        }
    }

