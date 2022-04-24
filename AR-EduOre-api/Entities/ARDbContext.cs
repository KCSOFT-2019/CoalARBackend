using Microsoft.EntityFrameworkCore;

namespace AR_EduOre_api.Entities
{
    public class ARDbContext : DbContext
    {
        public ARDbContext(DbContextOptions<ARDbContext> options) : base(options) { }

        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<CourseEquipment> CourseEquipments { get; set; }
        public DbSet<CourseTeacherProfile> CourseTeacherProfiles { get; set; }
        public DbSet<DailyQuestion> DailyQuestions { get; set; }
        public DbSet<DailyQuestionBank> DailyQuestionBanks { get; set; }
        public DbSet<DiscussionQuestionBank> DiscussionQuestionsBanks { get; set; }
        public DbSet<ExaminationPaperBank> ExaminationPaperBanks { get; set; }
        public DbSet<OfflineCourse> OfflineCourses { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }
        public DbSet<OnlineCourseEvaluation> OnlineCourseEvaluations { get; set; }
        public DbSet<OpenCourse> OpenCourses { get; set; }
        public DbSet<OpenCourseEvaluation> OpenCourseEvaluations { get; set; }
        public DbSet<QuestionChoiceBank> QuestionChoiceBanks { get; set;}
        public DbSet<StudentAnswerRecord> StudentAnswerRecords { get; set; }
        public DbSet<StudentCollection> StudentCollections { get; set; }
        public DbSet<TextInformation> TextInformation { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<CourseStudentProfile> CourseStudentProfile { get; set; }
    }
}
