namespace AR_EduOre_api.Models;

public class CreatedOfflineCourse
{
    public string offline_name { get; set;}
    public byte[]? offline_picture { get; set; }
    public DateTime offline_begin_date { get; set; }
    public DateTime offline_end_date { get;  set; }

    
    public string offline_space { get; set; }
    public DateTime offline_enroll_begin_date { get; set; }
    public DateTime Offline_enroll_end_date { get; set; }
    public bool offline_course_if { get; set; }
}