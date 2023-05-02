using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController:Controller
{
    private readonly ICategoryRepository _categoryRepo;

    public CategoryController(ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> categoryList = _categoryRepo.GetAll().ToList();
        return View(categoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category obj)
    {   
        if(obj.Name==obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name","The DisplayOrder cannot exactly match the Name");
        } 
         if(ModelState.IsValid)
         {
            _categoryRepo.Add(obj);
            _categoryRepo.Save();
             TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
         }
         return View(obj);
    }
    public IActionResult Edit(int? id)
    {
        if(id == null || id ==0)
        {
            return NotFound();
        }
        var categoryId = _categoryRepo.Get(u => u.Id == id);
        if(categoryId is null ) return NotFound();
        return View(categoryId);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if(obj.Name==obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name","The DisplayOrder cannot exactly match the Name");
        } 
         if(ModelState.IsValid)
         {
            _categoryRepo.Update(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
         }
         return View(obj);
    }

    public IActionResult Delete(int? id)
    {
        if(id == null || id ==0)
        {
            return NotFound();
        }
        var categoryId = _categoryRepo.Get(u => u.Id == id);
        if (categoryId is null ) return NotFound();
        return View(categoryId);
    }
     
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _categoryRepo.Get(u => u.Id == id);

        if(obj == null) return NotFound();

        _categoryRepo.Remove(obj);
        _categoryRepo.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
     
}