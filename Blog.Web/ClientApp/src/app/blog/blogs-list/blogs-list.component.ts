import { Component, OnInit } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { BlogService } from '../blog.service';

@Component({
    selector: 'app-blogs-list',
    templateUrl: './blogs-list.component.html',
    styleUrls: ['./blogs-list.component.scss']
})
export class BlogsListComponent implements OnInit {
    blogs: Array<BlogModel>;

    constructor(private blogService: BlogService) {
        this.blogs = new Array<BlogModel>();
  }

    public ngOnInit(): void {
        this.blogService.getBlogs().subscribe(blogs => this.blogs = blogs);
  }
}
