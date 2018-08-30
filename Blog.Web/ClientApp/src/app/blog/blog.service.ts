import { Injectable } from '@angular/core';
import { BlogModel } from './models/blog.model';
import { CreateBlogModel } from './models/create-blog.model';
import { Observable } from 'rxjs';
import { HttpService } from '../core/http.service';

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

  public getBlogById(id: number): Observable<BlogModel>{
    let url = this.blogApiUrl + '/' + id;
    return this.http.get<BlogModel>(url);
  }

  public updateBlog(blog: BlogModel): Observable<BlogModel>{
    return this.http.put<BlogModel>(this.blogApiUrl,blog);
  }
}
