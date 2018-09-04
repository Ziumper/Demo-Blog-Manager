import { Component, OnInit } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { BlogService } from '../blog.service';
import { Router } from '@angular/router';
import { LoaderService } from '../../core/loader/loader.service';
import { Subject, Observable } from 'rxjs';
import { debounceTime, switchMap, distinctUntilChanged } from 'rxjs/operators';
import { BlogPagedModel } from '../models/blogs-paged-model';


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
    public pageSize: number;
    public collectionSize: number;
    public iterationIndex: number;
    public searchQuery: string;

    constructor(
        private blogService: BlogService, 
        private router: Router,
        private loaderService: LoaderService
    ) {
        this.blogs = new Array<BlogModel>();
        this.isLoading = false;
        
        this.page = 1;
        this.pageSize = 10;
        this.collectionSize = 0;
        this.iterationIndex = 0;
        this.searchQuery = '';
        
    }

    public ngOnInit(): void {
        this.searchTerm = new Subject<string>();
        
        this.getBlogs();

        this.subscribeToLoad();

        this.search(this.searchTerm).subscribe( (result: BlogPagedModel) =>{
            this.blogs = result.blogs;
            this.page = result.page;
            this.collectionSize = result.count;
            this.pageSize = result.size;
        })
    }

    public editBlog(id: number) {
        this.router.navigateByUrl('/edit-blog/' + id);
    }

    public deleteBlog(blog: BlogModel) {
        this.blogService.deleteBlog(blog.blogEntityId).subscribe(() => {
            this.removeBlog(blog);
            this.getBlogs();
        });

    }

    public onPageChange(page) : void {
        this.page = page;

        if(this.page > 1){
            this.iterationIndex = 10 * page-1;
        }else
        { 
            this.iterationIndex = 0
        }

        this.getBlogs();
    }

    private search(searchTerm :Observable<string>) : Observable<BlogPagedModel> {
        return searchTerm.pipe(
            debounceTime(400),
            distinctUntilChanged(),
            switchMap((query: string)=> this.blogService.searchBlogsByTitlePaged(this.page,this.pageSize,query))
        );
        
    }


    private getBlogs(): void {
        this.blogService.searchBlogsByTitlePaged(this.page,this.pageSize,this.searchQuery).subscribe((result : BlogPagedModel) => {
            this.blogs = result.blogs;
            this.page = result.page;
            this.collectionSize = result.count;
            this.pageSize = result.size;
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
