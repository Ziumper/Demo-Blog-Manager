import { Component, OnInit, Input } from '@angular/core';
import { CommentService } from '../comment.service';
import { ActivatedRoute } from '@angular/router';
import { CommentModel } from '../models/comment.model';
import { CommentsQuery } from '../models/comments-query.model';


@Component({
  selector: 'app-comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.scss']
})
export class CommentsListComponent implements OnInit {

    public comments: Array<CommentModel>;
    public canLoadMore: boolean;

    @Input()
    public commentCount: number;

    private postId: number;
    private query: CommentsQuery;
    private commentsTake: number;
    private commentsSkip: number;
    private commentsStep: number;


    constructor(private commentService: CommentService, private route: ActivatedRoute) {}

    public ngOnInit(): void {
        this.commentsTake = 10;
        this.commentsStep = 10;
        this.commentsSkip = 0;
        this.canLoadMore = false;
        this.comments = new Array<CommentModel>();
        this.postId = this.route.snapshot.params['id'];
        this.query = new CommentsQuery(this.commentsSkip, this.postId, this.commentsTake);
        this.getComments();
    }

    private getComments(): void {
      this.commentService.getComments(this.query).subscribe(response => {
          this.comments = response;
          this.validateLoad();
      });
    }

    public onCommentFormSubmit(submited: boolean): void {
      if (submited) {
        this.getComments();
      }
    }

    public loadMore(): void {
      const skip = this.commentsTake;
      this.commentsTake = this.commentsTake + this.commentsStep;
      this.query.take = this.commentsTake;
      const query = new CommentsQuery(skip, this.postId, this.commentsTake);
      this.commentService.getComments(query).subscribe(response => {
        this.comments = this.comments.concat(response);
        this.validateLoad();
      });
    }

    private validateLoad(): void {
      this.canLoadMore = this.commentsTake <= this.commentCount;
    }


}
