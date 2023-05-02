using BulkyBook.DataAccess.Data;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController:Controller
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> categoryList = _context.Categories.ToList();
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
            _context.Categories.Add(obj);
            _context.SaveChanges();
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
        var categoryId = _context.Categories.Find(id);
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
            _context.Categories.Update(obj);
            _context.SaveChanges();
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
        var categoryId = _context.Categories.Find(id);
        if(categoryId is null ) return NotFound();
        return View(categoryId);
    }
     
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _context.Categories.Find(id);

        if(obj == null) return NotFound();
        
        _context.Categories.Remove(obj);
        _context.SaveChanges();
         TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
     
}