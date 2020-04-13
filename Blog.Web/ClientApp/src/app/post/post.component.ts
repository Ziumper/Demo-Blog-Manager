import { Component, OnInit } from '@angular/core';
import { PostService } from './post.service';
import { ActivatedRoute } from '@angular/router';
import { PostModel } from './models/post.model';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  public post: PostModel;

  constructor(private postService: PostService,
    private route: ActivatedRoute) {
      this.post = new PostModel();
  }

  public ngOnInit(): void {
    this.getPost();
  }

  private getPost(): void {
    const postId = this.route.snapshot.params['id'];
    if (postId) {
      this.postService.getPostByIdWithAuthor(postId).subscribe(response => {
        this.post = response;
      });
    }
  }

}
