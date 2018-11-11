import { Injectable } from '@angular/core';
import { HttpService } from '../core/http.service';
import { Observable, throwError } from 'rxjs';
import { PostPagedModel } from './models/post-paged.model';
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
      return this.http.get<PostPagedModel>(this.postApiUrl + '/paged?', query.getParams());
   }
}
