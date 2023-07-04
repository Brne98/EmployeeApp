using BlazorCrudDotNet7.Server.Data;
using BlazorCrudDotNet7.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<Category> UpdateCategory(int id, Category category)
    {
        var dbProduct = await _context.Categories.FindAsync(id);
        
        if (dbProduct != null)
        {
            dbProduct.Name = category.Name;

            await _context.SaveChangesAsync();
        }

        return dbProduct;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var dbProduct = await _context.Categories.FindAsync(id);
        if (dbProduct == null)
        {
            return false;
        }

        _context.Remove(dbProduct);
        await _context.SaveChangesAsync();

        return true;
    }
}