import { Injectable } from '@angular/core';
import { BlogModel } from './models/blog.model';
import { Observable } from 'rxjs';
import { HttpService } from '../core/http.service';
import { BlogPagedModel } from './models/blogs-paged-model';
import { BaseQueryModel } from '../core/models/base-query.model';


@Injectable()
export class BlogService {

  private blogApiUrl: string;

  constructor(private http: HttpService ) {
    this.blogApiUrl = 'api/blog';
   }

  public addBlog(blog: BlogModel): Observable<BlogModel> {
    return this.http.post<BlogModel>(this.blogApiUrl, blog);
  }

  public getBlogs(): Observable<Array<BlogModel>> {
    return this.http.get<Array<BlogModel>>(this.blogApiUrl);
  }

  public searchBlogsByTitlePaged(page: number, size: number, title: string): Observable<BlogPagedModel> {
    return this.http.getSmall(this.blogApiUrl + '/paged/' + page + '/' + size + '/' + title);
  }

  public getBlogsPagedFilteredByTitle( query: BaseQueryModel): Observable<BlogPagedModel> {
    return this.http.getSmall<BlogPagedModel>(this.blogApiUrl + '/paged?', query.getParams());
  }

  public getBlogById(id: number): Observable<BlogModel> {
    const url = this.blogApiUrl + '/' + id;
    return this.http.get<BlogModel>(url);
  }

  public updateBlog(blog: BlogModel): Observable<BlogModel> {
    return this.http.put<BlogModel>(this.blogApiUrl, blog);
  }

  public deleteBlog(id: number): Observable<BlogModel> {
    return this.http.deleteSmall<BlogModel>(this.blogApiUrl + '/' + id);
  }
}
