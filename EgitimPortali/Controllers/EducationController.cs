using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using EgitimPortali.Models;
using Microsoft.AspNetCore.Mvc;
using EgitimPortali.Repositories;
using EgitimPortali.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace EgitimPortali.Controllers
{
    public class EducationController : Controller
    {
        private readonly EducationRepository _educationRepository;
        private readonly LessonRepository _lessonRepository;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;
        private readonly AppDbContext _context;
        public EducationController(EducationRepository educationRepository, LessonRepository lessonRepository, IMapper mapper, INotyfService notyf)
        {
            _educationRepository = educationRepository;
            _lessonRepository = lessonRepository;
            _mapper = mapper;
            _notyf = notyf;
        }
        public async Task<IActionResult> Index()
        {
            var educations = await _educationRepository.GetAllAsync();
            var educationModels = _mapper.Map<List<EducationModel>>(educations);
            return View(educationModels);
        }
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Add()
        {
            var lessons = await _lessonRepository.GetAllAsync();
            var lessonsSelectList = lessons.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.Lessons = lessonsSelectList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(EducationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var education = _mapper.Map<Education>(model);
            education.Created = DateTime.Now;
            education.Updated = DateTime.Now;
            await _educationRepository.AddAsync(education);
            _notyf.Success("Eğitim Eklendi...");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var lessons = await _lessonRepository.GetAllAsync();
            var lessonsSelectList = lessons.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.Lessons = lessonsSelectList;
            var education = await _educationRepository.GetByIdAsync(id);
            var educationModel = _mapper.Map<EducationModel>(education);
            return View(educationModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EducationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var education = await _educationRepository.GetByIdAsync(model.Id);
            education.Name = model.Name;
            education.Description = model.Description;
            education.IsActive = model.IsActive;
            education.LessonId = model.LessonId;
            education.Updated = DateTime.Now;

            await _educationRepository.UpdateAsync(education);
            _notyf.Success("Eğitim Güncellendi...");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var education = await _educationRepository.GetByIdAsync(id);
            var educationModel = _mapper.Map<EducationModel>(education);
            return View(educationModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EducationModel model)
        {

            await _educationRepository.DeleteAsync(model.Id);
            _notyf.Success("Eğitim Silindi...");
            return RedirectToAction("Index");
        }
    }
}