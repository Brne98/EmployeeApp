using BlazorCrudDotNet7.Server.Services.CategoryService;
using BlazorCrudDotNet7.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet7.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<List<Category>> GetCategories()
    {
        return await _categoryService.GetCategories();
    }
    
    [HttpGet("{id}")]
    public async Task<Category?> GetCategoryById(int id)
    {
        return await _categoryService.GetCategoryById(id);
    }

    [HttpPost]
    public async Task<Category> CreateCategory(Category category)
    {
        return await _categoryService.CreateCategory(category);
    }

    [HttpPut("{id}")]
    public async Task<Category> UpdateCategory(int id, Category category)
    {
        return await _categoryService.UpdateCategory(id, category);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteCategory(int id)
    {
        return await _categoryService.DeleteCategory(id);
    }
}