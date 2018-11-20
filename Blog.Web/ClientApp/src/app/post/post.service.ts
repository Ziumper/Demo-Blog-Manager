import { Injectable } from '@angular/core';
import { HttpService } from '../core/http.service';
import { Observable, throwError } from 'rxjs';
import { PostPagedModel } from './models/post-paged.model';
import { PostModel } from './models/post.model';
import { BaseQueryModel } from '../core/models/base-query.model';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private postApiUrl: string;

  constructor(private http: HttpService) {
    this.postApiUrl = 'api/post';
   }

   public getPostsPaged(query: BaseQueryModel): Observable<PostPagedModel> {
      const params = query.getParams();
      return this.http.get<PostPagedModel>(this.postApiUrl + '/paged?', params);
   }

   public getPostsPagedByTagId(query: BaseQueryModel, tagId: number): Observable<PostPagedModel> {
      const params = query.getParams();
      return this.http.get<PostPagedModel>(this.postApiUrl + '/paged/tag/' + tagId + '?', params);
   }

   public getPostsPagedByBlogId(query: BaseQueryModel, blogId: number): Observable<PostPagedModel> {
      const params = query.getParams();
      return this.http.get<PostPagedModel>(this.postApiUrl + 'paged/blog/' + blogId + '?', params);
   }

   public getPostById(id: number): Observable<PostModel> {
      return this.http.get<PostModel>(this.postApiUrl + id.toString());
   }

   public updatePost(post: PostModel): Observable<PostModel> {
      return this.http.put<PostModel>(this.postApiUrl, post);
   }

   public addPost(post: PostModel): Observable<PostModel> {
      return this.http.post<PostModel>(this.postApiUrl, post);
   }
}
