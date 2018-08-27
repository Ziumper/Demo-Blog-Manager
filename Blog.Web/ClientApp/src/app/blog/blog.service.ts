import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BlogModel } from './models/blog.model';
import { CreateBlogModel } from './models/create-blog.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  public blogApiUrl: string;

  constructor(private http: HttpClient ) {
    this.blogApiUrl = 'api/blog';
   }

  public addBlog(blog: CreateBlogModel): Observable<BlogModel> {
    return this.http.post<BlogModel>(this.blogApiUrl, blog);
  }

  public getBlogs(): Observable<Array<BlogModel>> {
    return this.http.get<Array<BlogModel>>(this.blogApiUrl);
  }

  public getBlogById(id: number): Observable<BlogModel>{
    let url = this.blogApiUrl + '/' + id;
    return this.http.get<BlogModel>(url);
  }
}
