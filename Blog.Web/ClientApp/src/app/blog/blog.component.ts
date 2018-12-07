import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostListConfig } from '../core/config/post-list.config';
import { BlogService } from './blog.service';
import { BlogModel } from './models/blog.model';
import { CategoryModel } from '../category/models/category.model';
import { TagModel } from '../tag/models/tag.model';
import { tap, catchError } from 'rxjs/operators';
import { LoaderService } from '../core/loader/loader.service';
import { empty } from 'rxjs';
import { LoggerService } from '../core/logger.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent extends PostListConfig implements OnInit {

  public blog: BlogModel;
  public categories: Array<CategoryModel>;
  public tags: Array<TagModel>;

  constructor(private route: ActivatedRoute,
    private blogService: BlogService,
    private loaderService: LoaderService,
    private loggerService: LoggerService) {
    super();
    this.blog = new BlogModel(0, '', new Date(), new Date(), new CategoryModel(0, ''));
    this.categories = new Array<CategoryModel>();
    this.tags = new Array<TagModel>();
  }

  public ngOnInit(): void {
    const blogId = this.route.snapshot.params['blogId'];
    if (blogId) {
      this.loaderService.activateLoading();
      this.blogService.getBlogById(blogId).pipe(
        catchError((error) => {
          this.loaderService.deactivateLoading();
          this.loggerService.error(error);
          return empty();
        })
      )
      .subscribe(response => {
        this.loggerService.info(response);
        this.getPosts();
        this.blog = response;
      });
    }
  }


  public getPosts(): void {
    const blogId = this.route.snapshot.params['blogId'];
    if (blogId) {
      this.postQueryModel.blogId = blogId;
      const tagId = this.route.snapshot.params['tagId'];
      if (tagId) {
        this.getPostsPagedByBlogIdAndTagId(blogId, tagId);
      } else {
        this.getPostsPagedByBlogId(blogId);
      }
    }
  }

  private getPostsPagedByBlogIdAndTagId(blogId: number, tagId: number) {
    const newTags = new Array<number>();
    newTags.push(tagId);
    this.postQueryModel.tagsIds = newTags;
    this.postSerivce.getPostsPagedByBlogIdAndTags(this.postQueryModel)
    .pipe(catchError((error) => {
      this.loaderService.deactivateLoading();
      this.loggerService.error(error);
      return empty();
    }))
    .subscribe(response => {
      this.loaderService.deactivateLoading();
      this.loggerService.info(response);
      this.posts = response.entities;
      this.page = response.page;
      this.collectionSize = response.count;
      this.pageSize = response.size;
    });
  }

  private getPostsPagedByBlogId(blogId: number): void {
    this.postSerivce.getPostsPagedByBlogId(this.postQueryModel)
        .pipe(catchError((error) => {
          this.loaderService.deactivateLoading();
          this.loggerService.error(error);
          return empty();
        }))
        .subscribe(response => {
          this.loaderService.deactivateLoading();
          this.loggerService.info(response);
          this.posts = response.entities;
          this.collectionSize = response.count;
          this.pageSize = response.size;
          this.page = response.page;
        });
  }
}


