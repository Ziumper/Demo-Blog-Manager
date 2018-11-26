import { Injectable } from '@angular/core';
import { HttpService } from '../core/http.service';
import { Observable, throwError } from 'rxjs';
import { PostPagedModel } from './models/post-paged.model';
import { PostModel } from './models/post.model';
import { BaseQueryModel } from '../core/models/base-query.model';
import { PostQueryModel } from './models/post-query.model';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private postApiUrl: string;

  constructor(private http: HttpService) {
    this.postApiUrl = 'api/post';
   }

   public getPostsPaged(query: PostQueryModel): Observable<PostPagedModel> {
      const params = query.getParams();
      return this.http.get<PostPagedModel>(this.postApiUrl + '/paged?', params);
   }

   public getPostsPagedByBlogId(query: PostQueryModel): Observable<PostPagedModel> {
      const params = query.getParams();
      return this.http.get<PostPagedModel>(this.postApiUrl + '/blog/paged?', params);
   }

   public getPostsPagedByBlogIdAndTags(query: PostQueryModel): Observable<PostPagedModel> {
      const params = query.getParams();
      return this.http.get<PostPagedModel>(this.postApiUrl + 'blog/tags/paged?', params);
   }

   public getPostsPagedByTags(query: PostQueryModel): Observable<PostPagedModel> {
      const params = query.getParams();
      return this.http.get<PostPagedModel>(this.postApiUrl + 'tags/paged?', params);
   }

   public getPostById(id: number): Observable<PostModel> {
      return this.http.get<PostModel>(this.postApiUrl + '/' + id.toString());
   }

   public updatePost(post: PostModel): Observable<PostModel> {
      return this.http.put<PostModel>(this.postApiUrl, post);
   }

   public addPost(post: PostModel): Observable<PostModel> {
      return this.http.post<PostModel>(this.postApiUrl, post);
   }
}
