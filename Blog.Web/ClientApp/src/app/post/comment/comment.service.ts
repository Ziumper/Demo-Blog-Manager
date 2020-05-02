import { Injectable } from '@angular/core';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CommentModel } from './models/comment.model';
import { CommentsQuery } from './models/comments-query.model';


@Injectable()
export class CommentService {

    private commentApiUrl: string;
    private commentForm: BehaviorSubject<boolean>;

    constructor(private http: HttpClient) {
        this.commentApiUrl = 'api/comment';
        this.commentForm = new BehaviorSubject<boolean> (true);
    }


    public addComment(comment: CommentModel): Observable<CommentModel> {
        return this.http.post<CommentModel>(this.commentApiUrl, comment);
    }

    public getComments(query: CommentsQuery): Observable<Array<CommentModel>> {
        const params = query.getParams();
        return this.http.get<Array<CommentModel>>(this.commentApiUrl + '/comments?', {params: params});
    }

    public getCommentsCount(postId: number): Observable<number> {
        return this.http.get<number>(this.commentApiUrl + '/count/' + postId);
    }

    public emitCommentForm(): void {
        this.commentForm.next(true);
    }

    public getCommentsFormObservable() {
        return this.commentForm.asObservable();
    }


}
