import { Component, OnInit } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { BlogService } from '../blog.service';
import { Router } from '@angular/router';
import { LoaderService } from '../../core/loader/loader.service';


@Component({
    selector: 'app-blogs-list',
    templateUrl: './blogs-list.component.html',
    styleUrls: ['./blogs-list.component.scss'],
})
export class BlogsListComponent implements OnInit {
    blogs: Array<BlogModel>;
    searchQuery: string;
    isLoading: boolean;

    constructor(
        private blogService: BlogService, 
        private router: Router,
        private loaderService: LoaderService
    ) {
        this.blogs = new Array<BlogModel>();
        this.searchQuery = '';
        this.isLoading = false;
    }

    public ngOnInit(): void {
       this.getBlogs();
       this.subscribeToLoad();
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

    private subscribeToLoad(): void{
        const smallLoader = this.loaderService.getSmallLoaderObservable()
        smallLoader.subscribe((isLoading: boolean) => {
            this.isLoading = isLoading;
        })

    }
}
