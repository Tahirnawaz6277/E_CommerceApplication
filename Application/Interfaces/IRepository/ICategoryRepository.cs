﻿using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.Common.ResultPattern;

namespace E_Commerce.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Result<Category>> CreateAsync(Category category);
        Task<Result<Category>> GetByIdAsync(Guid id);
        Task<Result<List<Category>>> GetAllAsync();

    }
}
