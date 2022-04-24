using AR_EduOre_api.Entities;
using AR_EduOre_api.Helpers;
using AR_EduOre_api.Models;
using AR_EduOre_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AR_EduOre_api.Controllers;
[Route("admin")]
public class AdminController : ControllerBase
{
    public AdminController (IConfiguration configuration, IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        Configuration = configuration;
        RepositoryWrapper = repositoryWrapper;
        Mapper = mapper;
    }
    
    public IConfiguration Configuration { get; }
    public IMapper Mapper { get; }
    public IRepositoryWrapper RepositoryWrapper { get; }

    [Authorize, HttpPost("changepwd", Name = nameof(changePwd))]
    public async Task<ActionResult<string>> changePwd(Guid gid, string newpwd)
    {
        if (gid == null || newpwd == null)
        {
            return BadRequest("[Admin]用户或新密码为空");
        }
        var guid = UserUtil.getUserId(HttpContext);
        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 2)
        {
            return BadRequest("[Admin]U are not Admin!");
        }

        var user =await RepositoryWrapper.UserInformation.GetByIdAsync(gid);
        if (user == null)
        {
            return BadRequest("[Admin]该用户不存在，请检查UUID");
        }
        user.password = newpwd;
        RepositoryWrapper.UserInformation.Update(user);
        var res  = await RepositoryWrapper.UserInformation.SaveAsync();
        if (!res)
        {
            return BadRequest("[Admin]保存失败");
        }

        return Ok("[Admin]Save success");
    }
    
    
    [Authorize,HttpGet("getall", Name = nameof(GetUsersAsync))]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync()
    {
        var guid = UserUtil.getUserId(HttpContext);
        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 2)
        {
            throw new Exception("[Admin]U are not Admin!");
        }
        var authors = (await RepositoryWrapper.UserInformation.GetAllAsync());
        var authorList = Mapper.Map<IEnumerable<UserDto>>(authors);
        return authorList.ToList();
    }

    [Authorize, HttpPost("delete", Name = nameof(DeleteUser))]
    public async Task<ActionResult<string>> DeleteUser(Guid id)
    {
        if (id == null)
        {
            return BadRequest("[Admin] id为空");
        }
        var guid = UserUtil.getUserId(HttpContext);
        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 2)
        {
            return BadRequest("[Admin]U are not Admin!");
        }

        var user = await RepositoryWrapper.UserInformation.GetByIdAsync(id);
        if (user == null)
        {
            return BadRequest("[Admin]User不存在");
        }
        RepositoryWrapper.UserInformation.Delete(user);
        var res =await RepositoryWrapper.UserInformation.SaveAsync();
        if (!res)
        {
            return BadRequest("[Admin]保存失败");
        }

        return Ok("保存成功");
    }
    
    [Authorize,HttpPost("addteacher", Name = nameof(AddTeacher))]
    public async Task<ActionResult<string>> AddTeacher(string telephone, string username, string pwd)
    {
        if (telephone == null || telephone==null || pwd==null )
        {
            return BadRequest("[Admin]参数不全");
        }
        var guid = UserUtil.getUserId(HttpContext);
        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 2)
        {
            return BadRequest("[Admin]U are not Admin!");
        }
        if (await RepositoryWrapper.UserInformation.isTelephoneExistAsync(telephone))
        {
            return BadRequest("手机号已注册!");
            throw new Exception("已注册");
        }

        var registerUser = new RegisterUser() { Name = username, Password = pwd, Sex = false, Telephone = telephone };
        var User = Mapper.Map<UserInformation>(registerUser);
        
        User.base_role_name = 1;
            
        RepositoryWrapper.UserInformation.Create(User);
        var result = await RepositoryWrapper.UserInformation.SaveAsync();
        if(!result)
        {
            return BadRequest("创建资源UserInformation失败");
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
        return Ok("[Admin]创建Teacher成功");

    }
    
    
    [Authorize,HttpPost("addstudent", Name = nameof(AddStudent))]
    public async Task<ActionResult<string>> AddStudent(string telephone, string username, string pwd)
    {
        if (telephone == null || telephone==null || pwd==null )
        {
            return BadRequest("[Admin]参数不全");
        }
        var guid = UserUtil.getUserId(HttpContext);
        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 2)
        {
            return BadRequest("[Admin]U are not Admin!");
        }
        if (await RepositoryWrapper.UserInformation.isTelephoneExistAsync(telephone))
        {
            return BadRequest("手机号已注册!");
            throw new Exception("已注册");
        }

        var registerUser = new RegisterUser() { Name = username, Password = pwd, Sex = false, Telephone = telephone };
        var User = Mapper.Map<UserInformation>(registerUser);
        
        User.base_role_name = 0;
            
        RepositoryWrapper.UserInformation.Create(User);
        var result = await RepositoryWrapper.UserInformation.SaveAsync();
        if(!result)
        {
            return BadRequest("创建资源UserInformation失败");
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
        return Ok("[Admin]创建Student成功");

    }
    
    [Authorize,HttpGet("getallteacher", Name = nameof(GetTeacherAsync))]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetTeacherAsync()
    {
        var guid = UserUtil.getUserId(HttpContext);
        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 2)
        {
            throw new Exception("[CourseTeacherProfile]U are not Admin!");
        }
        var authors = (await RepositoryWrapper.UserInformation.GetByConditionAsync(user => user.base_role_name == 1));
        var authorList = Mapper.Map<IEnumerable<UserDto>>(authors);
        return authorList.ToList();
    }
    [Authorize,HttpGet("getallstudent", Name = nameof(GetStudentAsync))]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetStudentAsync()
    {
        var guid = UserUtil.getUserId(HttpContext);
        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 2)
        {
            throw new Exception("[CourseTeacherProfile]U are not Admin!");
        }
        var authors = (await RepositoryWrapper.UserInformation.GetByConditionAsync(user => user.base_role_name == 0));
        var authorList = Mapper.Map<IEnumerable<UserDto>>(authors);
        return authorList.ToList();
    }
}