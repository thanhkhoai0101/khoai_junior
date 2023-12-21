using System;
using System.ComponentModel;

namespace _0306201035_PhanThanhKhoai.Models
{
	public class Student
	{
		
		public int Id { get; set; }
		public int Code { get; set; }
		public String FullName { get; set; }
		public  DateTime DateOfBirth { get; set; }
		public String Address { get; set; }
		public float MathPoints { get; set; }
        public float PhysicsPoints { get; set; }
        public float ChemistryPoints { get; set; }
        public float MediumPoints { get; set; }
		public int ClassroomId { get; set; }
        [DisplayName("Lớp")]
        public Classroom Classroom { get; set; }
    }
}

