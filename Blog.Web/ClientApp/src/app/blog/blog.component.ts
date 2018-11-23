import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostListConfig } from '../core/config/post-list.config';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent extends PostListConfig {

  constructor(private route: ActivatedRoute) {
    super();
  }

  public getPosts(): void {
    const blogId = this.route.snapshot.params['blogId'];
    if (blogId) {
      this.postQueryModel.blogId = blogId;
      this.postSerivce.getPostsPagedByBlogId(this.postQueryModel).subscribe(response => {
        this.posts = response.entities;
        this.collectionSize = response.size;
        this.page = response.page;
      });
     }
    const tagId = this.route.snapshot.params['tagId'];
    if (tagId) {
      const newTags = new Array<number>();
      newTags.push(tagId);
      this.postQueryModel.tagsIds = newTags;
      this.postSerivce.getPostsPagedByBlogIdAndTags(this.postQueryModel).subscribe(response => {
        this.posts = response.entities;
        this.page = response.page;
        this.collectionSize = response.size;
      });
    }
  }
}

