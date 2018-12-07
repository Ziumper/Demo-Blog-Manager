import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../category.service';
import { CategoryModel } from '../models/category.model';

@Component({
    selector: 'app-categories-list',
    templateUrl: './categories-list.component.html',
    styleUrls: ['./categories-list.component.scss']
})
export class CategoriesListComponent implements OnInit {

    public categories: Array<CategoryModel>;

    constructor(private categoryService: CategoryService) {
        this.categories = new Array<CategoryModel>();
    }

    public ngOnInit(): void {
        this.categoryService.getAllCategories().subscribe(response => {
            this.categories = response;
        });
   }
}
