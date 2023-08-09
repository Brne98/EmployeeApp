using BlazorCrudDotNet7.Shared.Entities;

namespace BlazorCrudDotNet7.Server.Services.CategoryService;

public interface ICategoryService
{
    Task<List<Category>> GetCategories();
    Task<Category?> GetCategoryById(int categoryId);
    Task<Category> CreateCategory(Category category);
    Task<Category?> UpdateCategory(int categoryId, Category category);
    Task<bool> DeleteCategory(int categoryId);
}