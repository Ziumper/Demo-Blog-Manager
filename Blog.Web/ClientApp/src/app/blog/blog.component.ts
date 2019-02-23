import { Component, OnInit } from '@angular/core';
import { BlogModel } from './models/blog.model';
import { BlogService } from './blog.service';
import { ActivatedRoute } from '@angular/router';
import { PostListConfig } from '../core/config/post-list.config';
import { PostService } from '../post/post.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent extends PostListConfig  implements OnInit {
  public blog: BlogModel;
  private blogId: number;

  constructor(private blogService: BlogService,
     private activatedRouteBlog: ActivatedRoute,
     private postServiceBlog: PostService ) {
       super(activatedRouteBlog, postServiceBlog);
       this.blogId = activatedRouteBlog.snapshot.params['blogId'];
  }

  public ngOnInit(): void {
    this.blogService.getBlogById(this.blogId).subscribe(response => {
      this.blog = response;
    });
    super.ngOnInit();
  }

}


