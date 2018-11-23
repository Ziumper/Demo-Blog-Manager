using System.Collections.Generic;
using AutoMapper;
using Blog.Dal.Models.Base;

namespace Blog.Bll.Dto.Base{

    public abstract class BaseDtoPaged<T,W> {
        public int Page {get; set;}
        //Amout of all
        public int Size {get; set;}
        //Amount of entites in page 
        public int Count {get; set;}
        public List<T> Entities {get; set;}

        public BaseDtoPaged(IMapper mapper,PagedEntity<W> entities,int page, int size){
            this.Page = page;
            this.Size = size;
            this.Count = entities.Count;

            var entitiyList = new List<T> ();

            foreach( var e in entities.Entities){
                entitiyList.Add(mapper.Map<W,T>(e));
            }

            this.Entities = entitiyList;
        }
    }
}