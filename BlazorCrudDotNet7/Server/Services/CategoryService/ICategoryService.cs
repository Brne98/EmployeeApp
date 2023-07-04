using BlazorCrudDotNet7.Shared.Entities;

namespace BlazorCrudDotNet7.Server.Services.CategoryService;

public interface ICategoryService
{
    Task<List<Category>> GetCategories();
    Task<Category?> GetCategoryById(int id);
    Task<Category> CreateCategory(Category category);
    Task<Category> UpdateCategory(int id, Category category);
    Task<bool> DeleteCategory(int id);
}