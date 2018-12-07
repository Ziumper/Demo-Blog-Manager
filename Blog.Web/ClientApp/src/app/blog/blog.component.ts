import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostListConfig } from '../core/config/post-list.config';
import { BlogService } from './blog.service';
import { BlogModel } from './models/blog.model';
import { CategoryModel } from '../category/models/category.model';
import { TagModel } from '../tag/models/tag.model';
import { tap, catchError } from 'rxjs/operators';
import { LoaderService } from '../core/loader/loader.service';
import { empty, forkJoin } from 'rxjs';
import { LoggerService } from '../core/logger.service';
import { CategoryService } from '../category/category.service';
import { TagService } from '../tag/tag.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent extends PostListConfig implements OnInit {

  public blog: BlogModel;
  public categories: Array<CategoryModel>;
  public tags: Array<TagModel>;

  private blogId: number;
  private tagId: number;

  constructor(private route: ActivatedRoute,
    private blogService: BlogService,
    private loaderService: LoaderService,
    private loggerService: LoggerService,
    private categoryService: CategoryService,
    private tagService: TagService) {
    super();

    this.blogId = this.route.snapshot.params['blogId'];
    this.tagId = this.route.snapshot.params['tagId'];

    this.postQueryModel.blogId = this.blogId;

    if (this.tagId) {
      this.postQueryModel.tagsIds = new Array<number>();
      this.postQueryModel.tagsIds.push(this.tagId);
    }
  }

  public ngOnInit(): void {
    if (this.tagId) {
      forkJoin(
        this.blogService.getBlogById(this.blogId),
        this.postSerivce.getPostsPagedByBlogIdAndTags(this.postQueryModel),
        this.tagService.getAllTags(),
        this.categoryService.getAllCategories()
      ).pipe(catchError((error) => {
        this.loaderService.deactivateLoading();
        this.loggerService.error(error);
        return empty();
      })).subscribe(([blog, postsPagedModel, tags, categories]) => {
        this.loggerService.info([blog, postsPagedModel, tags, categories]);
        this.loaderService.deactivateLoading();
        this.blog = blog;
        this.posts = postsPagedModel.entities;
        this.tags = tags;
        this.categories = categories;
      });
    } else {
      forkJoin(
        this.blogService.getBlogById(this.blogId),
        this.postSerivce.getPostsPagedByBlogId(this.postQueryModel),
        this.tagService.getAllTags(),
        this.categoryService.getAllCategories()
      ).pipe(catchError((error) => {
        this.loaderService.deactivateLoading();
        this.loggerService.error(error);
        return empty();
      })).subscribe(([blog, postsPagedModel, tags, categories]) => {
        this.blog = blog;
        this.posts = postsPagedModel.entities;
        this.tags = tags;
        this.categories = categories;
      });
    }

  }

  public onSearch(searchQuery) {
    this.postQueryModel.searchQuery = searchQuery;
    this.getPosts();
  }

  public getPosts(): void {
    if (this.blogId) {
      if (this.tagId) {
        this.getPostsPagedByBlogIdAndTagId(this.blogId, this.tagId);
      } else {
        this.getPostsPagedByBlogId(this.blogId);
      }
    }
  }

  private getPostsPagedByBlogIdAndTagId(blogId: number, tagId: number) {
    this.loaderService.deactivateSmallLoading();
    this.postSerivce.getPostsPagedByBlogIdAndTags(this.postQueryModel)
    .pipe(catchError((error) => {
      this.loggerService.error(error);
      this.loaderService.deactivateSmallLoading();
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
    this.loaderService.acitvateSmallLoading();
    this.postSerivce.getPostsPagedByBlogId(this.postQueryModel)
        .pipe(catchError((error) => {
          this.loaderService.deactivateSmallLoading();
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


