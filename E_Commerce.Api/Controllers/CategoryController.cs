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
        public IActionResult Test()
        {
            return Ok("Category controller is reachable");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _categoryService.GetAllAsync();
            return result.IsSuccess
                 ? Ok(result)
                : BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRequest categoryRequest)
        {
            var result = await _categoryService.CreateAsync(categoryRequest);
            return result.IsSuccess
                       ? CreatedAtAction(
                           actionName: nameof(GetByIdAsync),
                           routeValues: new { id = result.Value.CategoryId },
                           value: result)
                       : BadRequest(result.Message);
        }
    }
}