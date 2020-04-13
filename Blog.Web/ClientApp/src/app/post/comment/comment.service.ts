import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CommentModel } from './models/comment.model';


@Injectable()
export class CommentService {

  private postApiUrl: string;

  constructor(private http: HttpClient) {
    this.postApiUrl = 'api/comment';
   }

   public addPost(comment: CommentModel): Observable<CommentModel> {
    return this.http.post<CommentModel>(this.postApiUrl, comment);
 }


}
