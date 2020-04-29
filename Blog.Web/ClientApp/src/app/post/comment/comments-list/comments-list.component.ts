import { Component, OnInit } from '@angular/core';
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

    private postId: number;
    private query: CommentsQuery;

    constructor(private commentService: CommentService, private route: ActivatedRoute) {}

    public ngOnInit(): void {
        this.comments = new Array<CommentModel>();
        this.postId = this.route.snapshot.params['id'];
        this.query = new CommentsQuery(0, this.postId, 10);
        this.getComments();
    }

    private getComments(): void {
      this.commentService.getComments(this.query).subscribe(response => {
          this.comments = response;
      });
    }


}
