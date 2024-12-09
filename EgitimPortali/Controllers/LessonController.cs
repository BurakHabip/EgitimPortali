using AutoMapper;
using EgitimPortali.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using EgitimPortali.Repositories;
using EgitimPortali.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EgitimPortali.Controllers
{
    public class LessonController : Controller
    {
        private readonly LessonRepository _lessonRepository;
        private readonly EducationRepository _educationRepository;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;

        public LessonController(LessonRepository lessonRepository, INotyfService notyf, EducationRepository educationRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _notyf = notyf;
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var lessons = await _lessonRepository.GetAllAsync();
            var lessonModels = _mapper.Map<List<LessonModel>>(lessons);
            return View(lessonModels);
        }

        [Authorize(Roles = "Admin,Teacher")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(LessonModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var lesson = _mapper.Map<Lesson>(model);
            lesson.Created = DateTime.Now;
            lesson.Updated = DateTime.Now;
            await _lessonRepository.AddAsync(lesson);
            _notyf.Success("Ders Eklendi...");
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Update(int id)
        {
            var lesson = await _lessonRepository.GetByIdAsync(id);
            var lessonModel = _mapper.Map<LessonModel>(lesson);
            return View(lessonModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(LessonModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var lesson = await _lessonRepository.GetByIdAsync(model.Id);
            lesson.Name = model.Name;
            lesson.IsActive = model.IsActive;
            lesson.Updated = DateTime.Now;
            await _lessonRepository.UpdateAsync(lesson);
            _notyf.Success("Ders Güncellendi...");
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Delete(int id)
        {
            var lesson = await _lessonRepository.GetByIdAsync(id);
            var lessonModel = _mapper.Map<LessonModel>(lesson);
            return View(lessonModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(LessonModel model)
        {
            var educations = await _educationRepository.GetAllAsync();
            if (educations.Count(c => c.LessonId == model.Id) > 0)
            {
                _notyf.Error("Eğitim Kayıtlı Olan Ders Silinemez!");
                return RedirectToAction("Index");
            }
            await _lessonRepository.DeleteAsync(model.Id);
            _notyf.Success("Ders Silindi...");
            return RedirectToAction("Index");
        }

    }
}
