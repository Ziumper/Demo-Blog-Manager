import { Component, OnInit } from '@angular/core';
import { PostService } from './post.service';
import { ActivatedRoute } from '@angular/router';
import { PostModel } from './models/post.model';
import { PostWithComments } from './models/post-with-comments.model';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  public post: PostWithComments;

  constructor(private postService: PostService,
    private route: ActivatedRoute) {
      this.post = new PostWithComments();
  }

  public ngOnInit(): void {
    const postId = this.route.snapshot.params['id'];
    if (postId) {
      this.postService.getPostByBlogIdAndPostIdAndWithComments(postId).subscribe(response => {
        this.post = response;
      });
    }
  }

}
