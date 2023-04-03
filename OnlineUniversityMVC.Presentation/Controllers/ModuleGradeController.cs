using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineUniversityMVC.Application.Dtos;
using OnlineUniversityMVC.Application.Services.Interfaces;

namespace OnlineUniversityMVC.Presentation.Controllers
{
    public class ModuleGradeController : Controller
    {
        private readonly IModuleGradeService _service;

        public ModuleGradeController(IModuleGradeService service)
        {
            _service = service;
        }

        [Route("ModuleGrade/{id}/AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            var model = await _service.GetById(id);

            return View(model);
        }

        [HttpPost]
        [Route("ModuleGrade/{id}/AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdate(int id, ModuleGradeDto gradeDto)
        {
            await _service.AddOrUpdateGrade(gradeDto);
            return RedirectToAction("Students", "Student");
        }
    }
}
