import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../category.service';
import { CategoryModel } from '../models/category.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-category-form',
    templateUrl: './category-form.component.html',
    styleUrls: ['./category-form.component.scss']
})
export class CategoryFormComponent implements OnInit {

    public model: CategoryModel;

    constructor(private categoryService: CategoryService, private route: ActivatedRoute) {
        this.model = new CategoryModel();
    }

    public ngOnInit(): void {
        const id = this.route.snapshot.params['id'];
        if (id) {
            this.model.id = id;
            this.categoryService.getCategoryById(id).subscribe(response => {
                this.model = response;
            });
        }
    }

    public submit(model: CategoryModel): void {
        const id = this.route.snapshot.params['id'];
        if (id) {
            this.model.id = id;
            this.categoryService.updateCategory(model);
        } else {
            this.categoryService.addCategory(model);
        }
    }


}
