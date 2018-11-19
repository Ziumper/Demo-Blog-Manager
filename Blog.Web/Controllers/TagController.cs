using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Bll.Services.Tags;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Tag")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTag(string name){
            var result = await _tagService.AddNewTagAsync(name);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var result = await _tagService.GetAllTagsAsync();
            return Ok(result);
        }
    }
}