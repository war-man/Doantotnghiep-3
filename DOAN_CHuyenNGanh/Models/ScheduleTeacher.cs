using DOAN_CHuyenNGanh.Models;

namespace IdentitySample.Models
{
    public class ScheduleTeacher
    {
        public int Id { get; set; }
        
        public int Lesson { get; set; }

        public int weekdays { get; set; }

        public Semester Semester { get; set; }

        public string SemesterId { get; set; }

        public Year Year { get; set; }

        public string YearId { get; set; }

        public Teacher Teacher { get; set; }

        public string TeacherId { get; set; }

        public Class Class { get; set; }

        public string ClassId { get; set; }
    }
}