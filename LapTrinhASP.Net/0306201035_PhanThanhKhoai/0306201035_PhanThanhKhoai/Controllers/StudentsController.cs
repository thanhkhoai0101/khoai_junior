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
    public class StudentsController : Controller
    {


        // GET: /<controller>/
        private EshopContext _context;
        public StudentsController(EshopContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            var students = _context.Students.Include(s=>s.Classroom).ToList();
            return View(students);
        }
        public IActionResult Details(int? id)
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
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id,Code,FullName,DateOfBirth,Address,MahtPoints,PhysicsPoints,ChemistryPoints,MediumPoints,ClassroomId")] Student student)
        { 
            student.MediumPoints = (student.MathPoints + student.ChemistryPoints + student.PhysicsPoints) / 3;
            var rand = new Random();
            student.Code =1;
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edits(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students =  _context.Students.FirstOrDefault(s=>s.Id ==id);
            if (students == null)
            {
                return NotFound();
            }
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Name", students.ClassroomId);
            return View(students);
        }
        [HttpPost]
        public IActionResult Edits(int? id, [Bind("Id,Code,FullName,DateOfBirth,Address,MathPoints,PhysicsPoints,ChemistryPoints,MediumPoints,ClassroomId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }
            student.MediumPoints = (student.MathPoints + student.ChemistryPoints + student.PhysicsPoints) / 3;
            _context.Students.Update(student);
             _context.SaveChanges();
             return RedirectToAction(nameof(Index));
          
        }
        public IActionResult Deletes(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            _context.Students.Remove(student);
            return RedirectToAction("Index");
        }
 

    }
}

