
using AR_EduOre_api.Entities;
using AR_EduOre_api.Models;
using AR_EduOre_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AR_EduOre_api.Helpers;

namespace AR_EduOre_api.Controllers
{
    /// <summary>
    /// 身份认证  相关接口
    /// </summary>
    [Route("auth")]
    public class AuthenticateController : ControllerBase
    {
        public AuthenticateController(IConfiguration configuration, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            Configuration = configuration;
            RepositoryWrapper = repositoryWrapper;
            Mapper = mapper;
        }
        public IConfiguration Configuration { get; }
        public IMapper Mapper { get; }
        public IRepositoryWrapper RepositoryWrapper { get; }
        [HttpPost("token",Name = nameof(GeneralToken))]
        public IActionResult GeneralToken(LoginUser loginUser)
        {
            var user = RepositoryWrapper.UserInformation.GetByConditionAsync(o => o.telephone.Equals(loginUser.Telephone)).Result.FirstOrDefault();
            if(user == null)
            {
                return Unauthorized("No user");
            }
            
            if(loginUser.Password != user.password)
            {
                return Unauthorized("Wrong password");
            }
            

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, loginUser.Telephone),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString())
                
            };
            var tokenConfigSection = Configuration.GetSection("Security:Token");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigSection["Key"]));
            var signCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                issuer: tokenConfigSection["Issuer"],
                audience: tokenConfigSection["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(300),
                signingCredentials: signCredential);


            return Ok( new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                expiration = TimeZoneInfo.ConvertTimeFromUtc(jwtToken.ValidTo,TimeZoneInfo.Local),
                user.base_role_name
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(RegisterUser registerUser, string? code)
        {
            if (registerUser == null || registerUser.Telephone==null || registerUser.Name==null || registerUser.Sex==null || registerUser.Password == null)
            {
                return BadRequest("参数不全");
            }

            if (await RepositoryWrapper.UserInformation.isTelephoneExistAsync(registerUser.Telephone))
            {
                return BadRequest("手机号已注册!");
                throw new Exception("已注册");
            }
            var User = Mapper.Map<UserInformation>(registerUser);
            if (code != null)
            {   
                if(code.Equals("teacher"))//后期改为配置文件
                User.base_role_name = 1;
                else if (code.Equals("admin")) //后期改为配置文件
                {
                    User.base_role_name = 2;
                }
                else User.base_role_name = 0;
            }
            RepositoryWrapper.UserInformation.Create(User);
            var result = await RepositoryWrapper.UserInformation.SaveAsync();
            if(!result)
            {
                throw new Exception("创建资源UserInformation失败");
            }

            /*if (code != null && code.Equals("teacher"))
            {
                var teacher = new CourseTeacherProfile { teacher_name = User.name, UserId = User.Id};
                RepositoryWrapper.CourseTeacherProfile.Create(teacher);
                var restea = await RepositoryWrapper.CourseTeacherProfile.SaveAsync();
                if (!restea)
                {
                    throw new Exception("创建资源UserInformation-CourseTeacherProfile失败");
                }
            }*/
            var UserCreated = Mapper.Map<UserDto>(User);
            return CreatedAtRoute(nameof(GetUserAsync),
                new { UserId = UserCreated.Id },
                UserCreated);
            
        }


        [Authorize,HttpGet("getall", Name = nameof(GetUserAsync))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUserAsync()
        {
            var guid = UserUtil.getUserId(HttpContext);
            if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 2)
            {
                throw new Exception("[CourseTeacherProfile]U are not Admin!");
            }
            var authors = (await RepositoryWrapper.UserInformation.GetAllAsync());
            var authorList = Mapper.Map<IEnumerable<UserDto>>(authors);
            return authorList.ToList();
        }
        [Authorize]
        [HttpPost("update", Name = nameof(UpdateUser))]
        public async Task<ActionResult> UpdateUser(string? department, bool? sex, string? name)
        {
            
            var val = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub");
            if(val == null)
            {
                Console.WriteLine(HttpContext.User.Claims.Count());
                foreach(var clm in HttpContext.User.Claims)
                {
                    Console.WriteLine(clm.Type);
                }
                return BadRequest("null");
            }
            return Ok(val.Value);
        }
    }
}
