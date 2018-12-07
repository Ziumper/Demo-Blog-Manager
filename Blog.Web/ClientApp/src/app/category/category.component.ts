import { Component, OnInit } from '@angular/core';
import { BaseQueryModel } from '../core/models/base-query.model';
import { PostListConfig } from '../core/config/post-list.config';
import { CategoryModel } from './models/category.model';
import { CategoryService } from './category.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.scss']
})
export class CategoryComponent extends PostListConfig implements OnInit  {

    public category: CategoryModel;

    constructor(private categoryService: CategoryService,
        private activatedRoute: ActivatedRoute) {
        super();
    }

    public ngOnInit(): void {
        const categoryId = this.activatedRoute.snapshot.params['categoryId'];
        this.categoryService.getCategoryById(categoryId)
        .subscribe(response => {
            this.category = response;
        });
     }

    public onSearch(searchQuery: string): void {
    }
}
