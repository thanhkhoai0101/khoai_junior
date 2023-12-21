using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0306201035_PhanThanhKhoai.Data;
using _0306201035_PhanThanhKhoai.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _0306201035_PhanThanhKhoai.Controllers
{
    public class ClassroomsController : Controller
    {
        private EshopContext _context;
        public ClassroomsController(EshopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Classrooms = _context.Classrooms.ToList();
            return View(Classrooms);
        }
        public IActionResult Details(int ? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var students = _context.Students.Include(s => s.Classroom).FirstOrDefault(x => x.Id == id);
            if (students == null)
            {
                return RedirectToAction("Index");
            }

            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id,Name,Room,Courses")] Classroom classroom)
        {

            _context.Classrooms.Add(classroom);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edits(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = _context.Classrooms.FirstOrDefault(s => s.Id == id);
            if (classroom == null)
            {
                return NotFound();
            }
          
            return View(classroom);
        }
        [HttpPost]
        public IActionResult Edits(int? id, [Bind("Id,Name,Room,Courses")] Classroom classroom)
        {
            if (id != classroom.Id)
            {
                return NotFound();
            }
           
            _context.Classrooms.Update(classroom);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Deletes(int? id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            _context.Students.Remove(student);
            return RedirectToAction("Index");
        }
    }
}

