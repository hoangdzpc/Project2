﻿namespace AppRating1.Models
{
    public class RatedEntity
    {
       
        public int ServiceTypeId { get; set; } // Khóa ngoại đến bảng ServiceType
        public string Name { get; set; }
    }
}