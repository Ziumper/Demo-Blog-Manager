import { Injectable } from '@angular/core';
import { HttpService } from '../core/http.service';
import { Observable, throwError } from 'rxjs';
import { PostPagedModel } from './models/post-paged.model';
import { PostQueryModel } from './models/post-query.model';
import { PostModel } from './models/post.model';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private postApiUrl: string;

  constructor(private http: HttpService) {
    this.postApiUrl = 'api/post';
   }

   public getPostsPaged(query: PostQueryModel): Observable<PostPagedModel> {
      return this.http.get<PostPagedModel>(this.postApiUrl + '/paged?', query.getParams());
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
