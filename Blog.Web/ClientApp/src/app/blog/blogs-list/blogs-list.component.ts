import { Component, OnInit } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { BlogService } from '../blog.service';
import { Router } from '@angular/router';


@Component({
    selector: 'app-blogs-list',
    templateUrl: './blogs-list.component.html',
    styleUrls: ['./blogs-list.component.scss']
})
export class BlogsListComponent implements OnInit {
    blogs: Array<BlogModel>;

    constructor(private blogService: BlogService, private router: Router) {
        this.blogs = new Array<BlogModel>();
    }

    public ngOnInit(): void {
       this.getBlogs();
    }

    public editBlog(id: number) {
        this.router.navigateByUrl('/edit-blog/' + id);
    }

    public deleteBlog(id: number) {
        this.blogService.deleteBlog(id).subscribe(() => {
            this.getBlogs();
        });

    }

    private getBlogs(): void {
        this.blogService.getBlogs().subscribe((blogs: Array<BlogModel>) => {
            this.blogs = blogs;
        });

    }
}
