import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { PostPagedModel } from './models/post-paged.model';
import { PostModel } from './models/post.model';
import { PostQueryModel } from './models/post-query.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private postApiUrl: string;

  constructor(private http: HttpClient) {
    this.postApiUrl = 'api/post';
   }

   public getPostsPaged(query: PostQueryModel): Observable<PostPagedModel> {
      const params = query.getParams();
      return this.http.get<PostPagedModel>(this.postApiUrl + '/paged?', {params: params});
   }

   public getPostsPagedByBlogId(query: PostQueryModel): Observable<PostPagedModel> {
      const params = query.getParams();
      return this.http.get<PostPagedModel>(this.postApiUrl + '/blog/paged?', {params: params});
   }

   public getPostsPagedByBlogIdAndTags(query: PostQueryModel): Observable<PostPagedModel> {
      const params = query.getParams();
      return this.http.get<PostPagedModel>(this.postApiUrl + 'blog/tags/paged?', {params: params});
   }

   public getPostsPagedByTags(query: PostQueryModel): Observable<PostPagedModel> {
      const params = query.getParams();
      return this.http.get<PostPagedModel>(this.postApiUrl + 'tags/paged?', {params: params});
   }

   public getPostById(id: number): Observable<PostModel> {
      return this.http.get<PostModel>(this.postApiUrl + '/' + id.toString());
   }

   public getPostByBlogIdAndPostIdAndWithComments(blogId: number, postId: number) {
      return this.http.get<PostModel>(this.postApiUrl + '/' + blogId + '/' + postId + '/comments' );
   }

   public updatePost(post: PostModel): Observable<PostModel> {
      return this.http.put<PostModel>(this.postApiUrl, post);
   }

   public addPost(post: PostModel): Observable<PostModel> {
      return this.http.post<PostModel>(this.postApiUrl, post);
   }

   public getPostsPagedByCategoryId(postQuery: PostQueryModel) {
      return this.http.get<PostPagedModel>(this.postApiUrl + 'category/paged?' , {params: postQuery.getParams()});
   }

   public deletePostById(id: number): Observable<PostModel> {
      return this.http.delete<PostModel>(this.postApiUrl + '/' + id.toString());
   }

   public getPostsByContentOrTitle(searchString: string): Observable<Array<PostModel>> {
      return this.http.get<Array<PostModel>>(this.postApiUrl + '/' + searchString);
   }
}
