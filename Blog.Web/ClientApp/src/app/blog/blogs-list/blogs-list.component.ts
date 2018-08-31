import { Component, OnInit } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { BlogService } from '../blog.service';
import { Router } from '@angular/router';
import { CreateBlogModel } from '../models/create-blog.model';


@Component({
    selector: 'app-blogs-list',
    templateUrl: './blogs-list.component.html',
    styleUrls: ['./blogs-list.component.scss']
})
export class BlogsListComponent implements OnInit {
    blogs: Array<BlogModel>;
    searchQuery: string;

    constructor(private blogService: BlogService, private router: Router) {
        this.blogs = new Array<BlogModel>();
        this.searchQuery = '';
    }

    public ngOnInit(): void {
       this.getBlogs();
    }

    public editBlog(id: number) {
        this.router.navigateByUrl('/edit-blog/' + id);
    }

    public deleteBlog(blog: BlogModel) {
        this.blogService.deleteBlog(blog.blogEntityId).subscribe(() => {
            this.removeBlog(blog);
        });

    }

    private getBlogs(): void {
        this.blogService.getBlogs().subscribe((blogs: Array<BlogModel>) => {
            this.blogs = blogs;
        });

    }

    private removeBlog(blog: BlogModel){
        const blogArrayIndex = this.blogs.indexOf(blog,0);
            if(blogArrayIndex > - 1){
                this.blogs.splice(blogArrayIndex,1);
            }
    }
}
