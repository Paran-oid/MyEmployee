﻿using System.ComponentModel.DataAnnotations;

namespace MyEmployee.Models.Main_Models
{
    public class EmployeeHistory
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Type { get; set; }
        public DateTimeOffset Time { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
