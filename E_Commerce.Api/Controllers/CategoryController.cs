using E_Commerce.Application.DTOS;
using E_Commerce.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("test")]
        //[AllowAnonymous]
        public IActionResult Test()
        {
            return Ok("Category controller is reachable");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRequest categoryRequest)
        {
            if (categoryRequest is null)
            {
                return BadRequest("Category cann't be null");
            }
            var category = await _categoryService.CreateAsync(categoryRequest);
            return category.IsSuccess
                ? Ok(category) 
                : BadRequest(category);
        }
    }
}
