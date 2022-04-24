using System.Threading.Channels;
using AR_EduOre_api.Helpers;
using AR_EduOre_api.Models;
using AR_EduOre_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AR_EduOre_api.Controllers;
[Route("user")]
public class UserInformationController : ControllerBase
{
    
    public UserInformationController(IConfiguration configuration, IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        Configuration = configuration;
        Mapper = mapper;
        RepositoryWrapper = repositoryWrapper;
    }
    public IConfiguration Configuration { get; }
    public IMapper Mapper { get; }
    public IRepositoryWrapper RepositoryWrapper { get; }
    [Authorize, HttpGet("getclassmates", Name = nameof(GetClassUsers))]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetClassUsers()
    {
        var phone = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
        //var class = await RepositoryWrapper.UserInformation.GetByConditionAsync(o => o.telephone.Equals(phone)).Result.;
        var users = await RepositoryWrapper.UserInformation.GetClassmates(phone);
        var userDtoList = Mapper.Map<IEnumerable<UserDto>>(users);
        return Ok(userDtoList.ToList());
    }
    [Authorize, HttpPost("changepwd", Name = nameof(ChangePassword))]
    public async Task<ActionResult<string>> ChangePassword(string oldpwd, string newpwd)
    {
        var id = UserUtil.getUserId(HttpContext);
        var user = await RepositoryWrapper.UserInformation.GetByIdAsync(id);
        if (user == null) return BadRequest("No user");
        if (user.password != oldpwd) return BadRequest("旧密码错误");
        user.password = newpwd;
        RepositoryWrapper.UserInformation.Update(user);
        var res = await RepositoryWrapper.UserInformation.SaveAsync();
        if (!res)
        {
            return BadRequest("change failed!");
        }

        return Ok("change success!" + newpwd);
    }

}