import { Component, OnInit } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { BlogService } from '../blog.service';
import { Router } from '@angular/router';
import { LoaderService } from '../../core/loader/loader.service';
import { Subject, Observable } from 'rxjs';
import { debounceTime, switchMap, distinctUntilChanged } from 'rxjs/operators';


@Component({
    selector: 'app-blogs-list',
    templateUrl: './blogs-list.component.html',
    styleUrls: ['./blogs-list.component.scss'],
})
export class BlogsListComponent implements OnInit {
    public blogs: Array<BlogModel>;
    public searchTerm: Subject<string>;
    public isLoading: boolean;
    public page: number;


    constructor(
        private blogService: BlogService, 
        private router: Router,
        private loaderService: LoaderService
    ) {
        this.blogs = new Array<BlogModel>();
        this.isLoading = false;
        this.page=1;
        
    }

    public ngOnInit(): void {
        this.searchTerm = new Subject<string>();
        this.getBlogs();
        this.subscribeToLoad();

        this.search(this.searchTerm).subscribe( (results: Array<BlogModel>) =>{
            this.blogs = results;
        })
    }

    public editBlog(id: number) {
        this.router.navigateByUrl('/edit-blog/' + id);
    }

    public deleteBlog(blog: BlogModel) {
        this.blogService.deleteBlog(blog.blogEntityId).subscribe(() => {
            this.removeBlog(blog);
        });

    }

    private search(searchTerm :Observable<string>) : Observable<Array<BlogModel>> {
        return searchTerm.pipe(
            debounceTime(400),
            distinctUntilChanged(),
            switchMap((query: string)=> this.blogService.searchBlogs(query))
        );
        
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
