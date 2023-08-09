using BlazorCrudDotNet7.Server.Data;
using BlazorCrudDotNet7.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet7.Server.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly DataContext _context;

    public CategoryService(DataContext context)
    {
        _context = context;
    }

    public Task<List<Category>> GetCategories()
    {
        return _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryById(int categoryId)
    {
        return await _context.Categories.FindAsync(categoryId);
    }

    public async Task<Category> CreateCategory(Category category)
    {
        _context.Add(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category?> UpdateCategory(int categoryId, Category category)
    {
        var dbEmployee = await _context.Categories.FindAsync(categoryId);
        if (dbEmployee != null)
        {
            dbEmployee.Name = category.Name;

            await _context.SaveChangesAsync();
        }

        return dbEmployee;
    }

    public async Task<bool> DeleteCategory(int categoryId)
    {
        var category = await _context.Categories.FindAsync(categoryId);
        
        if (category == null)
        {
            return false;
        }

        _context.Remove(category);
        await _context.SaveChangesAsync();

        return true;
    }
}