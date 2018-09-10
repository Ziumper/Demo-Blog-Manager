import { Component, OnInit } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { BlogService } from '../blog.service';
import { Router } from '@angular/router';
import { LoaderService } from '../../core/loader/loader.service';
import { Subject, Observable } from 'rxjs';
import { debounceTime, switchMap, distinctUntilChanged } from 'rxjs/operators';
import { BlogPagedModel } from '../models/blogs-paged-model';
import { BlogQueryModel } from '../models/blog-query.model';



@Component({
    selector: 'app-blogs-list',
    templateUrl: './blogs-list.component.html',
    styleUrls: ['./blogs-list.component.scss'],
})
export class BlogsListComponent implements OnInit {
    public blogs: Array<BlogModel>;
    public searchTerm: Subject<string>;
    public isLoading: boolean;
    public blogQueryModel: BlogQueryModel;
    public collectionSize: number;
    public iterationIndex: number;

    constructor(
        private blogService: BlogService,
        private router: Router,
        private loaderService: LoaderService
    ) {
        this.blogs = new Array<BlogModel>();
        this.isLoading = false;
        this.collectionSize = 0;
        this.iterationIndex = 0;

        this.initalizeBlogQueryModel();
    }

    public ngOnInit(): void {
        this.searchTerm = new Subject<string>();
        this.getBlogs();
        this.subscribeToLoad();
        this.search(this.searchTerm).subscribe( (result: BlogPagedModel) => {
            this.updateResult(result);
        });
    }

    public editBlog(id: number) {
        this.router.navigateByUrl('/edit-blog/' + id);
    }

    public deleteBlog(blog: BlogModel) {
        this.blogService.deleteBlog(blog.id).subscribe(() => {
            this.removeBlog(blog);
            this.getBlogs();
        });

    }

    public onPageChange(page): void {
        this.blogQueryModel.page = page;

        if (page > 1) {
            this.iterationIndex = 10 * page - 1;
        } else {
            this.iterationIndex = 0;
        }

        this.getBlogs();
    }

    public sortById(): void {
        console.log('Sorting by Id');
        this.blogQueryModel.filter = 0;
        this.blogQueryModel.order = !this.blogQueryModel.order;
    }

    public sortByTitle(): void {
        console.log('Sorting by Title');
        this.blogQueryModel.filter  = 3;
        this.blogQueryModel.order = !this.blogQueryModel.order;
    }

    private search(searchTerm: Observable<string>): Observable<BlogPagedModel> {
        return searchTerm.pipe(
            debounceTime(400),
            distinctUntilChanged(),
            switchMap((query: string) => {
                this.blogQueryModel.title = query;
                return this.blogService.getBlogsPagedFilteredByTitle(this.blogQueryModel);
            })
        );

    }

    private getBlogs(): void {
        this.blogService.getBlogsPagedFilteredByTitle(this.blogQueryModel).subscribe((result: BlogPagedModel) => {
            this.updateResult(result);
        });

    }

    private removeBlog(blog: BlogModel) {
        const blogArrayIndex = this.blogs.indexOf(blog, 0);
            if (blogArrayIndex > - 1) {
                this.blogs.splice(blogArrayIndex, 1);
            }
    }

    private subscribeToLoad(): void {
        const smallLoader = this.loaderService.getSmallLoaderObservable();
        smallLoader.subscribe((isLoading: boolean) => {
            this.isLoading = isLoading;
        });

    }

    private updateResult(result: BlogPagedModel): void {
        this.blogs = result.blogs;
        this.blogQueryModel.page = result.page;
        this.collectionSize = result.count;
        this.blogQueryModel.size = result.size;
    }

    private initalizeBlogQueryModel(): void {
        this.blogQueryModel = new BlogQueryModel();
        this.blogQueryModel.page = 1;
        this.blogQueryModel.size = 10;
        this.blogQueryModel.title = '';
        this.blogQueryModel.filter = 0;
        this.blogQueryModel.order = false;
    }
}
