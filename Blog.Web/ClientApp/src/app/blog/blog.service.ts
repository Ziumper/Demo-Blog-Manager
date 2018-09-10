import { Injectable } from '@angular/core';
import { BlogModel } from './models/blog.model';
import { CreateBlogModel } from './models/create-blog.model';
import { Observable } from 'rxjs';
import { HttpService } from '../core/http.service';
import { BlogPagedModel } from './models/blogs-paged-model';
import { BlogQueryModel } from './models/blog-query.model';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  private blogApiUrl: string;

  constructor(private http: HttpService ) {
    this.blogApiUrl = 'api/blog';
   }

  public addBlog(blog: CreateBlogModel): Observable<BlogModel> {
    return this.http.post<BlogModel>(this.blogApiUrl, blog);
  }

  public getBlogs(): Observable<Array<BlogModel>> {
    return this.http.get<Array<BlogModel>>(this.blogApiUrl);
  }

  public searchBlogsByTitlePaged(page: number, size: number, title: string): Observable<BlogPagedModel> {
    return this.http.getSmall(this.blogApiUrl + '/paged/' + page + '/' + size + '/' + title);
  }

  public getBlogsPagedFilteredByTitle( query: BlogQueryModel): Observable<BlogPagedModel> {
    return this.http.getSmall<BlogPagedModel>(this.blogApiUrl + '/paged?' );
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
