import { Component, OnInit } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { BlogService } from '../blog.service';
import { Router } from '@angular/router';
import { LoaderService } from '../../core/loader/loader.service';
import { Subject, Observable } from 'rxjs';
import { debounceTime, switchMap, distinctUntilChanged } from 'rxjs/operators';
import { BlogPagedModel } from '../models/blogs-paged-model';
import { BaseQueryModel } from 'src/app/core/models/base-query.model';

@Component({
    selector: 'app-blogs-manager',
    templateUrl: './blogs-manager.component.html',
    styleUrls: ['./blogs-manager.component.scss'],
})
export class BlogsManagerComponent implements OnInit {
    public blogs: Array<BlogModel>;
    public searchTerm: Subject<string>;
    public isLoading: boolean;
    public blogQueryModel: BaseQueryModel;
    public collectionSize: number;

    constructor(
        private blogService: BlogService,
        private router: Router,
        private loaderService: LoaderService
    ) {
        this.blogs = new Array<BlogModel>();
        this.isLoading = false;
        this.collectionSize = 0;
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
        this.getBlogs();
    }

    public sort(filter: number) {
        console.log('Sorting by ' + filter);
        this.checkOrder(filter);
        this.blogQueryModel.filter = filter;
        this.getBlogs();
    }

    private checkOrder(filter: number): void {
        if (this.blogQueryModel.filter === filter) {
            this.blogQueryModel.order = !this.blogQueryModel.order;
        } else {
            this.blogQueryModel.order = false;
        }
    }

    private search(searchTerm: Observable<string>): Observable<BlogPagedModel> {
        return searchTerm.pipe(
            debounceTime(400),
            distinctUntilChanged(),
            switchMap((query: string) => {
                this.blogQueryModel.searchQuery = query;
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
        this.blogs = result.entities;
        this.blogQueryModel.page = result.page;
        this.collectionSize = result.count;
        this.blogQueryModel.size = result.size;
    }

    private initalizeBlogQueryModel(): void {
        this.blogQueryModel = new BaseQueryModel(1, 10, 0, false, '');
    }
}
