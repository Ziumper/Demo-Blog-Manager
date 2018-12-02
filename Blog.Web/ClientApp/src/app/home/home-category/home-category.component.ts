import { Component, OnInit, Input } from '@angular/core';
import { CategoryWithPostModel } from 'src/app/category/models/categoryWithPosts.model';
import { CategoryService } from 'src/app/category/category.service';

@Component({
    selector: 'app-home-category',
    templateUrl: './home-category.component.html',
    styleUrls: ['./home-category.component.scss']
})
export class HomeCategoryComponent implements OnInit {

    public categories: Array<CategoryWithPostModel>;

    constructor(private categoryService: CategoryService) {
        this.categories = new Array<CategoryWithPostModel>();
    }

    ngOnInit(): void {
        this.categoryService.getCategoriesWithPosts(3).subscribe(response => {
            this.categories = response;
          });
    }
}
