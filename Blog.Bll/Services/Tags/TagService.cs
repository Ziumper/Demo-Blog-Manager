using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Bll.Dto.Tags;
using Blog.Dal.Models;
using Blog.Dal.Repositories.Tags;

namespace Blog.Bll.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository,IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<TagDto> AddNewTagAsync(string name)
        {
            Tag myTag = new Tag();
            
            myTag.SetModificationAndCreationTime();
            myTag.Name = name;
            
            var result = await _tagRepository.AddAsync(myTag);
            var mappedResult = _mapper.Map<Tag,TagDto>(myTag);

            return mappedResult;
        }
    }
}
