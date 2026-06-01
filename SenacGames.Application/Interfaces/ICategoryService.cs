using System;
using System.Collections.Generic;
using System.Text;
using SenacGames.Application.DTOs;


namespace SenacGames.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CategoryDto dto);
        Task<CategoryDto?> UpdateAsync(int id, CategoryDto dto);
        Task<bool> DeleteAsync(int id);
        Task<int> CountAsync();
    }
}