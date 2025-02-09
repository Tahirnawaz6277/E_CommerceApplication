﻿using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Application.DTOS;

namespace E_Commerce.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Result<CategoryResponse>> CreateAsync(CategoryRequest category);
        
    }
}