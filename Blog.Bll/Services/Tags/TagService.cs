using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Bll.Dto.Tags;
using Blog.Bll.Exceptions;
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

        public async Task<TagDto> AddNewTagAsync(TagDto tagDto)
        {
            Tag myTag = _mapper.Map<TagDto,Tag>(tagDto);
            
            var result = await _tagRepository.AddAsync(myTag);
            var mappedResult = _mapper.Map<Tag,TagDto>(myTag);

            await _tagRepository.SaveAsync();

            return mappedResult;
        }

        public async Task<TagDto> DeleteTagAsync(int id)
        {
            Tag tagToDelete = await _tagRepository.FindByFirstAsync(tag => tag.Id == id);
            if(tagToDelete == null) throw new ResourceNotFoundException("Tag with id: " + id +" not found");
            
            tagToDelete = _tagRepository.Delete(tagToDelete);

            TagDto mappedTag = _mapper.Map<Tag,TagDto>(tagToDelete);

            await _tagRepository.SaveAsync();

            return mappedTag;
        }

        public async Task<TagDto> EditTagAsync(TagDto tagDto)
        {
            Tag tagToEdit = await _tagRepository.FindByFirstAsync(tag => tag.Id == tagDto.Id);
            if(tagToEdit == null) throw new ResourceNotFoundException("Tag with id: " + tagDto.Id +" not found");
            
            tagToEdit.SetModificationTime();
            tagToEdit = _tagRepository.Edit(tagToEdit);

            await _tagRepository.SaveAsync();

            TagDto mappedTag = _mapper.Map<Tag,TagDto>(tagToEdit);
            return mappedTag;
        }

        public async Task<List<TagDto>> GetAllTagsAsync(){
            var result = await _tagRepository.GetAllAsync();
            List<TagDto> resultDto = new List<TagDto>();
            foreach (var item in result)
            {
                var tagDto = _mapper.Map<Tag,TagDto>(item);
                resultDto.Add(tagDto);
            }

            return resultDto;
        }

    }
}
