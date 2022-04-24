using System.Threading.Channels;
using AR_EduOre_api.Entities;
using AR_EduOre_api.Helpers;
using AR_EduOre_api.Models;
using AR_EduOre_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AR_EduOre_api.Controllers;
[Route("teacher")]
public class TeacherController : ControllerBase
{
    public TeacherController(IConfiguration configuration, IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        Configuration = configuration;
        Mapper = mapper;
        RepositoryWrapper = repositoryWrapper;
    }
    
    public IConfiguration Configuration { get; }
    public IMapper Mapper { get; }
    public IRepositoryWrapper RepositoryWrapper { get; }
    [Authorize, HttpGet("getowncourses", Name = nameof(GetOwnLessons))]
    public async Task<ActionResult> GetOwnLessons()
    {
        var guid = UserUtil.getUserId(HttpContext);

        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 1)
        {
            return BadRequest("U are not a teacher");
        }
        
        
        if (!await RepositoryWrapper.CourseTeacherProfile.isExistUserIdAsync(guid))
        {
            return BadRequest("U don't have any course");
        }
            
        var courseprofiles =await RepositoryWrapper.CourseTeacherProfile.GetByUserIdAsync(guid);
        
        return Ok((courseprofiles));
    }
    [Authorize, HttpGet("hasonlinecourse", Name = nameof(HasOnlineCourse))]
    public async Task<ActionResult> HasOnlineCourse()
    {
        var guid = UserUtil.getUserId(HttpContext);
        
        if (!await RepositoryWrapper.CourseTeacherProfile.isExistUserIdAsync(guid))
        {
            throw new Exception("[CourseTeacherProfile]U are not Teacher!");
        }

        var hasOnline = await RepositoryWrapper.CourseTeacherProfile.hasOnlineCourse(guid);
        return Ok(hasOnline);
    }

    [Authorize, HttpGet("hasofflinecourse", Name = nameof(HasOfflineCourse))]
    public async Task<ActionResult> HasOfflineCourse()
    {
        var guid = UserUtil.getUserId(HttpContext);
        if (!await RepositoryWrapper.CourseTeacherProfile.isExistUserIdAsync(guid))
        {
            throw new Exception("[CourseTeacherProfile]U are not Teacher!");
        }
        var hasOffline = await RepositoryWrapper.CourseTeacherProfile.hasOfflineCourse(guid);
        return Ok(hasOffline);
    }
    
    [Authorize, HttpGet("hasopencourse", Name = nameof(HasOpenCourse))]
    public async Task<ActionResult> HasOpenCourse()
    {
        var guid = UserUtil.getUserId(HttpContext);
        if (!await RepositoryWrapper.CourseTeacherProfile.isExistUserIdAsync(guid))
        {
            throw new Exception("[CourseTeacherProfile]U are not Teacher!");
        }
        var hasOpen = await RepositoryWrapper.CourseTeacherProfile.hasOfflineCourse(guid);
        return Ok(hasOpen);
    }

    [Authorize, HttpPost("createonlinecourse", Name = nameof(CreateOnlineCourse))]
    public async Task<ActionResult> CreateOnlineCourse(CreatedOnlineCourse createdOnlineCourse, Guid courseId)
    {
        var guid = UserUtil.getUserId(HttpContext);
        
        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 1)
        {
            return BadRequest("[CourseTeacherProfile]U are not Teacher!");
        }

        
        if (!await RepositoryWrapper.CourseEquipment.isExistAsync(courseId))
        {
            return BadRequest("[CourseTeacherProfile]CourseEquipment does not exist!");
        }
        if(await RepositoryWrapper.CourseTeacherProfile.GetByConditionAsync(p => p.online_id.Equals(courseId))!= null) {
            return BadRequest("该大课程已经有子课程了");
        }
        createdOnlineCourse.online_course_status = 0;
        createdOnlineCourse.online_course_if = false;
        var onlineCourse = Mapper.Map<OnlineCourse>(createdOnlineCourse);
        
        RepositoryWrapper.OnlineCourse.Create(onlineCourse);
        var res =await RepositoryWrapper.OnlineCourse.SaveAsync();
        if (!res)
        {
            return BadRequest("创建资源OnlineCourse失败");
        }

        var courseteacher = new CourseTeacherProfile { online_id = onlineCourse.ID,UserId = guid};
        RepositoryWrapper.CourseTeacherProfile.Create(courseteacher);
        
        var res2 = await RepositoryWrapper.CourseTeacherProfile.SaveAsync();
        if (!res2)
        {
            return BadRequest("创建资源OnlineCourse-创建资源CourseTeacherProfile失败");
        }

        var cor =await RepositoryWrapper.CourseEquipment.GetByIdAsync(courseId);
        cor.online_id = onlineCourse.ID;
        RepositoryWrapper.CourseEquipment.Update(cor);
        var res3 = await RepositoryWrapper.CourseEquipment.SaveAsync();
        if (!res3)
        {
            return BadRequest("创建OnlineCourse-更新Course失败");
        }
        
        RepositoryWrapper.CourseTeacherProfile.Create(new CourseTeacherProfile(){online_id = onlineCourse.ID, UserId = guid});
        var res4 = await RepositoryWrapper.CourseTeacherProfile.SaveAsync();
        if (!res4)
        {
            return BadRequest("创建CourseTeacher失败");
        }
        return Ok(onlineCourse);
    }
    
    [Authorize, HttpPost("createofflinecourse", Name = nameof(CreateOfflineCourse))]
    public async Task<ActionResult> CreateOfflineCourse(CreatedOfflineCourse createdOfflineCourse, Guid courseId)
    {
        var guid = UserUtil.getUserId(HttpContext);
        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 1)
        {
            throw new Exception("[CourseTeacherProfile]U are not Teacher!");
        }

        
        if (!await RepositoryWrapper.CourseEquipment.isExistAsync(courseId))
        {
            throw new Exception("[CourseTeacherProfile]CourseEquipment does not exist!");
        }
        var offlineCourse = Mapper.Map<OnlineCourse>(createdOfflineCourse);
        
        RepositoryWrapper.OnlineCourse.Create(offlineCourse);
        var res =await RepositoryWrapper.OnlineCourse.SaveAsync();
        if (!res)
        {
            throw new Exception("创建资源OnlineCourse失败");
        }

        var courseteacher = new CourseTeacherProfile { online_id = offlineCourse.ID,UserId = guid};
        RepositoryWrapper.CourseTeacherProfile.Create(courseteacher);
        
        var res2 = await RepositoryWrapper.CourseTeacherProfile.SaveAsync();
        if (!res2)
        {
            throw new Exception("创建资源OnlineCourse-创建资源CourseTeacherProfile失败");
        }

        var cor =await RepositoryWrapper.CourseEquipment.GetByIdAsync(courseId);
        cor.online_id = offlineCourse.ID;
        RepositoryWrapper.CourseEquipment.Update(cor);
        var res3 = await RepositoryWrapper.CourseEquipment.SaveAsync();
        if (!res3)
        {
            throw new Exception("创建OnlineCourse-更新Course失败");
        }
        return Ok(offlineCourse);
    }
    [Authorize, HttpPost("addChapter", Name = nameof(addChapter))]
    public async Task<ActionResult<string>> addChapter(Guid online_id, string name)
    {
        var guid = UserUtil.getUserId(HttpContext);

        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 1)
        {
            return BadRequest("U are not a teacher");
        }
        
        
        if (await RepositoryWrapper.CourseTeacherProfile.GetByConditionAsync(profile => profile.online_id.Equals(online_id) && profile.UserId.Equals(guid)) == null)
        {
            return BadRequest("这不是你的课程or查无此课");
        }

        var ccc = await RepositoryWrapper.Chapter.GetByConditionAsync(chapter => chapter.course_id.Equals(online_id));
        if (ccc.Count() == 0)
        {
            Console.WriteLine("noooooooooooo");
            Chapter newchapter = new Chapter() { course_id = online_id, name = name, head = true , next_id = null};
            RepositoryWrapper.Chapter.Create(newchapter);
            var res =await RepositoryWrapper.Chapter.SaveAsync();
            if (!res)
            {
                return BadRequest("创建头章节失败");
            }
            
            
            return Ok("创建 头章节 成功");
            
        }
        
        {
            var last = RepositoryWrapper.Chapter.GetByConditionAsync(cc => cc.course_id.Equals(online_id) && cc.next_id == null).Result.FirstOrDefault();
            if (last == null)
            {
                return BadRequest("没有 尾结点");
            }

            var newcp = Mapper.Map<Chapter>(new ChapterCreated() { course_id = online_id, head = false, name = name, next_id = null });
            RepositoryWrapper.Chapter.Create(newcp);
            last.next_id = newcp.id;
            RepositoryWrapper.Chapter.Update(last);
            var res =await RepositoryWrapper.Chapter.SaveAsync();
            if (!res)
            {
                return BadRequest("保存失败");
            }

            return Ok("创建章节成功");
        }
        

        
        
        
    }

    [Authorize, HttpGet("getallchapter", Name = nameof(getAllChapter))]
    public async Task<ActionResult<IEnumerable<Chapter>>> getAllChapter(Guid online_id)
    {
        var guid = UserUtil.getUserId(HttpContext);

        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 1)
        {
            return BadRequest("U are not a teacher");
        }


        if (await RepositoryWrapper.CourseTeacherProfile.GetByConditionAsync(profile => profile.online_id.Equals(online_id) && profile.UserId.Equals(guid)) == null)
        {
            return BadRequest("这不是你的课程");
        }

        List<Chapter> res = new List<Chapter>();

        var head = await RepositoryWrapper.Chapter.getHead(online_id);
        if (head == null)
        {
            return BadRequest("Error 无此课头结点");
        }

        res.Add(head);
        while (await RepositoryWrapper.Chapter.getNext(head.id) != null)
        {
            var p = await RepositoryWrapper.Chapter.GetByIdAsync((Guid)head.next_id);
            res.Add(p);
            head = p;
        }
        
        
        return Ok(res);
    }
    [Authorize, HttpPost("editchaptername", Name = nameof(EditChapterName))]
    public async Task<ActionResult<string>> EditChapterName(Guid id, string newName)
    {
        var guid = UserUtil.getUserId(HttpContext);

        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 1)
        {
            return BadRequest("U are not a teacher");
        }
        
        
        

        var cp = await RepositoryWrapper.Chapter.GetByIdAsync(id);
        if (cp == null) return BadRequest("无此ID章节");
        cp.name = newName;
        RepositoryWrapper.Chapter.Update(cp);
        var res =await RepositoryWrapper.Chapter.SaveAsync();
        if (!res)
        {
            return BadRequest("保存失败");
        }

        return Ok("修改成功！");
    }
    [Authorize, HttpDelete("deletechapter", Name = nameof(DeleteChapter))]
    public async Task<ActionResult<string>> DeleteChapter(Guid chapter_id)
    {
        var guid = UserUtil.getUserId(HttpContext);

        if ((await RepositoryWrapper.UserInformation.GetByIdAsync(guid)).base_role_name != 1)
        {
            return BadRequest("U are not a teacher");
        }
        var cp = await RepositoryWrapper.Chapter.GetByIdAsync(chapter_id);
        if (cp == null) return BadRequest("无此ID章节");

        if (cp.head == true)
        {
            var next_id = cp.next_id;
            if (next_id != null)
            {
                var next = await RepositoryWrapper.Chapter.GetByIdAsync((Guid)next_id);
                next.head = true;
                RepositoryWrapper.Chapter.Update(next);
                RepositoryWrapper.Chapter.Delete(cp);
            }
            else
            {
                RepositoryWrapper.Chapter.Delete(cp);
            }
            
        } else if (cp.next_id == null)
        {
            var front =  RepositoryWrapper.Chapter.GetByConditionAsync(c => c.next_id.Equals(cp.id)).Result.FirstOrDefault();
            front.next_id = null;
            RepositoryWrapper.Chapter.Update(front);
            RepositoryWrapper.Chapter.Delete(cp);
        }
        else
        {
            var front =  RepositoryWrapper.Chapter.GetByConditionAsync(c => c.next_id.Equals(cp.id)).Result.FirstOrDefault();
            front.next_id = cp.next_id;
            RepositoryWrapper.Chapter.Update(front);
            RepositoryWrapper.Chapter.Delete(cp);
        }
        
        
        var res =await RepositoryWrapper.Chapter.SaveAsync();
        if (!res) return BadRequest("删除失败");
        return Ok("删除成功");

    }
    //public async Task<ActionResult> 
    
}