import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostListConfig } from '../core/config/post-list.config';
import { BlogService } from './blog.service';
import { BlogModel } from './models/blog.model';
import { CategoryModel } from '../category/models/category.model';
import { TagModel } from '../tag/models/tag.model';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent extends PostListConfig implements OnInit {

  public blog: BlogModel;
  public categories: Array<CategoryModel>;
  public tags: Array<TagModel>;

  constructor(private route: ActivatedRoute, private blogService: BlogService) {
    super();
    this.blog = new BlogModel(0, '', new Date(), new Date(), new CategoryModel(0, ''));
    this.categories = new Array<CategoryModel>();
    this.tags = new Array<TagModel>();
  }

  public ngOnInit(): void {
    const blogId = this.route.snapshot.params['blogId'];
    if (blogId) {
      this.blogService.getBlogById(blogId).subscribe(response => {
        this.blog = response;
      });
      this.getPosts();
    }
  }

  public getPosts(): void {
    const blogId = this.route.snapshot.params['blogId'];
    if (blogId) {
      this.postQueryModel.blogId = blogId;
      this.postSerivce.getPostsPagedByBlogId(this.postQueryModel).subscribe(response => {
        this.posts = response.entities;
        this.collectionSize = response.count;
        this.pageSize = response.size;
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
        this.collectionSize = response.count;
        this.pageSize = response.size;
      });
    }
  }
}

