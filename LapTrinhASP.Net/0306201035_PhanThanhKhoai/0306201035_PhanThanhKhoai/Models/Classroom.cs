using System;
namespace _0306201035_PhanThanhKhoai.Models
{
	public class Classroom
	{
		public int Id { get; set; }
		public String Name { get; set; }
		public int Room { get; set; }
		public String Courses { get; set; }

		public List<Student> Students { get; set; }
	}
}

