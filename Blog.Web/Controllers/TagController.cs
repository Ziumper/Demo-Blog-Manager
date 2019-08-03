using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Bll.Dto.Tags;
using Blog.Bll.Services.Tags;
using Blog.Web.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Tag")]
    public class TagController : BaseBlogAppController
    {
        private readonly ITagService _tagService;
        
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTag([FromBody]TagDto tag){
            var result = await _tagService.AddNewTagAsync(tag);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var result = await _tagService.GetAllTagsAsync();
            return Ok(result);
        }

        [HttpGet("{tagName}")]
        public async Task<IActionResult> GetAllTagsByName(string tagName)
        {
            var result = await _tagService.GetAllTagsAsyncByName(tagName);
            return Ok(result);
        }
    }
}