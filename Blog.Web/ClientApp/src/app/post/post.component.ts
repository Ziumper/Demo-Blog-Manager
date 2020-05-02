import { Component, OnInit } from '@angular/core';
import { PostService } from './post.service';
import { ActivatedRoute } from '@angular/router';
import { PostModel } from './models/post.model';
import { CommentService } from './comment/comment.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  public post: PostModel;
  public commentsCount: number;

  private postId;

  constructor(
    private postService: PostService,
    private route: ActivatedRoute,
    private commentsService: CommentService
  ) {}

  public ngOnInit(): void {
    this.post = new PostModel();
    this.postId = this.route.snapshot.params['id'];
    this.commentsCount = 0;

    this.subscribeToCommentForm();
    this.getPost();
    this.getCommentsCount();
  }

  private getCommentsCount() {
      this.commentsService.getCommentsCount(this.postId).subscribe(
        response => {
          this.commentsCount = response;
        }
      );
  }

  private getPost(): void {
    if (this.postId) {
      this.postService.getPostByIdWithAuthor(this.postId).subscribe(response => {
        this.post = response;
      });
    }
  }

  private subscribeToCommentForm(): void {
    this.commentsService.getCommentsFormObservable().subscribe(response => {
      if (response) {
        this.getCommentsCount();
      }
    });
  }

}
