import { Component, OnInit } from '@angular/core';
import { BlogModel } from './models/blog.model';
import { BlogService } from './blog.service';
import { ActivatedRoute } from '@angular/router';
import { PostService } from '../post/post.service';
import { PostQueryModel } from '../post/models/post-query.model';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent implements OnInit {
  public blog: BlogModel;
  public postQueryModel: PostQueryModel;
  private blogId: number;

  constructor(private blogService: BlogService,
    private activatedRoute: ActivatedRoute,
    private postService: PostService) {
    this.postQueryModel = new PostQueryModel();
    this.postQueryModel.blogId = this.blogId;
  }

  public ngOnInit(): void {
    this.getBlogIdFromParams();
    this.blogService.getBlogById(this.blogId).subscribe(response => {
      this.blog = response;
    });
  }

  private getBlogIdFromParams() {
    this.blogId = this.activatedRoute.snapshot.parent.params['blogId'];
    if (!this.blogId) {
      this.blogId = this.activatedRoute.parent.snapshot.params['blogId'];
    }
  }

}


