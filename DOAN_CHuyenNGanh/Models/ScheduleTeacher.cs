using DOAN_CHuyenNGanh.Models;

namespace IdentitySample.Models
{
    public class ScheduleTeacher
    {
        public string Id { get; set; }
        
        public int Lesson { get; set; }

        public int weekdays { get; set; }

        public Semester Semester { get; set; }

        public Year Year { get; set; }

        public Teacher Teacher { get; set; }

        public Class Class { get; set; }
             
    }
}