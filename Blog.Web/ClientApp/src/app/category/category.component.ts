import { Component, OnInit } from '@angular/core';
import { BaseQueryModel } from '../core/models/base-query.model';
import { PostListConfig } from '../core/config/post-list.config';
import { CategoryModel } from './models/category.model';

@Component({
    selector: 'app-category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.scss']
})
export class CategoryComponent extends PostListConfig implements OnInit  {

    public categories: Array<CategoryModel>;

    constructor() {
        super();
    }

    public ngOnInit(): void {

     }

    public onSearch(searchQuery: string): void {
    }
}
