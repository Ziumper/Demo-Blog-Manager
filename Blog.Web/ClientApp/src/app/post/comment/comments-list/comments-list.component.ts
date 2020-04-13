import { Component, OnInit } from '@angular/core';
import { CommentService } from '../comment.service';
import { ActivatedRoute } from '@angular/router';
import { CommentModel } from '../models/comment.model';


@Component({
  selector: 'app-comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.scss']
})
export class CommentsListComponent implements OnInit {
    public comments: Array<CommentModel>;

    private postId: number;

    constructor(private commentService: CommentService, private route: ActivatedRoute) {}

    public ngOnInit(): void {
        this.comments = new Array<CommentModel>();
        this.postId = this.route.snapshot.params['id'];
    }

  public submit(): void {
      this.commentService.getCommentsByPostId(this.postId).subscribe(response => {
          this.comments = response;
      });
  }


}
