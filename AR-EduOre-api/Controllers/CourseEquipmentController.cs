using AR_EduOre_api.Entities;
using AR_EduOre_api.Models;
using AR_EduOre_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AR_EduOre_api.Controllers;
[Route("courseequipment")]
public class CourseEquipmentController : ControllerBase
{
    public CourseEquipmentController(IConfiguration configuration, IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        Configuration = configuration;
        Mapper = mapper;
        RepositoryWrapper = repositoryWrapper;
    }
    public IConfiguration Configuration { get; }
    public IMapper Mapper { get; }
    public IRepositoryWrapper RepositoryWrapper { get; }
    [Authorize, HttpGet("getall", Name = nameof(GetAll))]
    public async Task<ActionResult<IEnumerable<CourseEquipment>>> GetAll()
    {
        var equips =  await RepositoryWrapper.CourseEquipment.GetAllAsync();
        return equips.ToList();
    }
    
    [Authorize, HttpGet("search", Name = nameof(GetSearch))]
    public async Task<ActionResult<IEnumerable<CourseEquipment>>> GetSearch(string name)
    {
        var equips = await RepositoryWrapper.CourseEquipment.GetByConditionAsync(o => o.equipment_name.Contains(name));
        return equips.ToList();
    }
    [Authorize, HttpPost("create", Name = nameof(CreateCourse))]
    public async Task<ActionResult> CreateCourse(CourseCreated courseCreated)
    {
        var course = Mapper.Map<CourseEquipment>(courseCreated);
        course.AR_ADDRESS_API = 0;
        RepositoryWrapper.CourseEquipment.Create(course);
        var result = await RepositoryWrapper.CourseEquipment.SaveAsync();
        if (!result)
        {
            throw new Exception("创建资源Course失败");
        }
        
        var cc = Mapper.Map<CourseCreated>(course);
        return Ok(cc);
    }
    [Authorize, HttpPatch("update", Name = nameof(PartiallyUpdateCourse))]
    public async Task<IActionResult> PartiallyUpdateCourse(Guid CourseId,[FromBody]JsonPatchDocument<UpdateCourse> patchDocument)
    {
        var course = await RepositoryWrapper.CourseEquipment.GetByIdAsync(CourseId);
        if (course == null)
        {
            return NotFound("no course");
        }

        var updateCourse = Mapper.Map<UpdateCourse>(course);
        
        patchDocument.ApplyTo(updateCourse, ModelState);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        

        Mapper.Map(updateCourse, course, typeof(UpdateCourse), typeof(CourseEquipment));
        RepositoryWrapper.CourseEquipment.Update(course);
        Console.WriteLine(course.equipment_name);
        if (!await RepositoryWrapper.CourseEquipment.SaveAsync())
        {
            throw new Exception("更新资源Course失败");
        }

        return NoContent();
    }
    [HttpDelete("/delete/{courseId}")]
    public async Task<ActionResult> DeleteCourse(Guid courseId)
    {
        var course = await RepositoryWrapper.CourseEquipment.GetByIdAsync(courseId);
        if (course == null)
        {
            return NotFound();
        }
        RepositoryWrapper.CourseEquipment.Delete(course);
        var res = await RepositoryWrapper.CourseEquipment.SaveAsync();
        if (!res)
        {
            throw new Exception("删除资源CourseEquipment失败");
        }

        return NoContent();
    }
    
    
    
}