import { Component, OnInit } from '@angular/core';
import { PostListConfig } from '../core/config/post-list.config';
import { CategoryModel } from './models/category.model';
import { CategoryService } from './category.service';
import { ActivatedRoute } from '@angular/router';
import { PostService } from '../post/post.service';
import { PostSearchService } from '../post/post-search/post-search.service';

@Component({
    selector: 'app-category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.scss']
})
export class CategoryComponent extends PostListConfig implements OnInit  {

    public category: CategoryModel;

    constructor(private categoryService: CategoryService,
        private activatedRouteCategory: ActivatedRoute,
        private postServiceCategory: PostService,
        ) {
        super( activatedRouteCategory, postServiceCategory);
    }

    public ngOnInit(): void {
        const categoryId = this.activatedRouteCategory.snapshot.params['categoryId'];
        this.categoryService.getCategoryById(categoryId)
        .subscribe(response => {
            this.category = response;
        });
        super.ngOnInit();
     }

    public onSearch(searchQuery: string): void {
    }

    public getPosts(): void {
        const categoryId = this.activatedRouteCategory.snapshot.params['categoryId'];
        this.postQueryModel.categoryId = categoryId;
        this.postServiceCategory.getPostsPagedByCategoryId(this.postQueryModel).subscribe(response => {
            this.pageSize = response.size;
            this.posts = response.entities;
            this.page = response.page;
            this.collectionSize = response.count;
        });
    }
}
