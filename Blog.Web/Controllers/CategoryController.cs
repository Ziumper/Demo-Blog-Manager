using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Bll.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService){
            _categoryService = categoryService;
        }

        [HttpGet("paged/category/posts")]
        public async Task<IActionResult> GetCategoriesWithPosts(){
            var result = await _categoryService.GetCategoriesWithPostsAsync();
            return Ok(result);
        }
    }
}