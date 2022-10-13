using Microsoft.AspNetCore.Mvc;
using NLayer_Backend_Business.Abstract;

namespace NLayer_Backend_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listCategories = _categoryService.GetAll();
            if (listCategories.Success)
            {
                return Ok(listCategories.Data);
            }
            return BadRequest(listCategories.Message);
        }
    }
}
