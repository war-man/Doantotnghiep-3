using DOAN_CHuyenNGanh.Models;
using DOAN_CHuyenNGanh.Models.DTOs;
using IdentitySample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace DOAN_CHuyenNGanh.Service
{
    public class ManageTeacherService
    {
        private ApplicationDbContext _dbContext = null;
        public ManageTeacherService()
        {
            _dbContext = new ApplicationDbContext();
        }
     

        public IEnumerable<ListTeacherDTO> GetListTeacher()
        {
            var result = _dbContext.Teachers.Include("ApplicationUser").AsEnumerable().Select(a => new ListTeacherDTO
            {
                Id = a.Id,
                address = a.address,
                birth_day =  a.birth_day,
                email =a.ApplicationUser.Email,
                name_Teacher =a.name_Teacher,
                native_land= a.name_birth_place,
                phone_number =a.phone_number,
                 sex =a.sex,
                status_deleted=a.status_deleted
            }); 
            
            return result;
        }
    }
}