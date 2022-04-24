namespace AR_EduOre_api.Models;

public class ChapterCreated
{
    public bool head { get; set; }
    public string name { get; set; }
    public Guid course_id { get; set; }
    public Guid? next_id { get; set; }
}