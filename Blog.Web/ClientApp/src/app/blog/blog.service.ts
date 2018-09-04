import { Injectable } from '@angular/core';
import { BlogModel } from './models/blog.model';
import { CreateBlogModel } from './models/create-blog.model';
import { Observable } from 'rxjs';
import { HttpService } from '../core/http.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  private blogApiUrl: string;

  constructor(private http: HttpService,private httpClient: HttpClient ) {
    this.blogApiUrl = 'api/blog';
   }

  public addBlog(blog: CreateBlogModel): Observable<BlogModel> {
    return this.http.post<BlogModel>(this.blogApiUrl, blog);
  }

  public getBlogs(): Observable<Array<BlogModel>> {
    return this.http.get<Array<BlogModel>>(this.blogApiUrl);
  }

  public searchBlogs(query : String): Observable<Array<BlogModel>> {
    const url = this.blogApiUrl + '/' + query 
    return this.http.getSmall<Array<BlogModel>>(url);
  }

  public getBlogById(id: number): Observable<BlogModel> {
    const url = this.blogApiUrl + '/' + id;
    return this.http.get<BlogModel>(url);
  }

  public updateBlog(blog: BlogModel): Observable<BlogModel> {
    return this.http.put<BlogModel>(this.blogApiUrl, blog);
  }

  public deleteBlog(id: number): Observable<BlogModel> {
    return this.http.delete<BlogModel>(this.blogApiUrl + '/' + id);
  }
}
