namespace AR_EduOre_api.Models;

public class UpdateCourse
{
    public Guid open_id { get; set; }
    public Guid offline_id { get; set; }
    public Guid online_id { get; set; }
    public bool if_course_equipment { get; set; }
    public string equipment_name { get; set; }
    public string equipment_type { get; set; }
    public int AR_ADDRESS_API { get; set; }
}