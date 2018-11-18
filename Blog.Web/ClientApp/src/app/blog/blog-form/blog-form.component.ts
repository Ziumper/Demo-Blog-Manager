import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { ActivatedRoute } from '@angular/router';
import { BlogService } from '../blog.service';
import { CategoryService } from 'src/app/category/category.service';
import { CategoryModel } from 'src/app/category/models/category.model';

@Component({
    selector: 'app-blog-form',
    templateUrl: './blog-form.component.html',
    styleUrls: ['./blog-form.component.scss']
})
export class BlogFormComponent implements OnInit {

    public model: BlogModel;
    public categories: Array<CategoryModel>;

    public constructor(
        private routed: ActivatedRoute,
        private blogService: BlogService,
        private categoryService: CategoryService) {
        this.model = new BlogModel();
        this.categories = new Array<CategoryModel>();
    }

    public ngOnInit(): void {
        this.categories = this.getTestCategories();
        /*
        this.categoryService.getAllCategories().subscribe(response => {
            this.categories = response;
        });
        */
        const id = this.routed.snapshot.params['id'];
        if (id) {
            this.blogService.getBlogById(id).subscribe(response => {
                this.model = response;
            });
        }
    }

    private getTestCategories(): Array<CategoryModel> {
        const result = new Array<CategoryModel>();
        for (let i = 0; i < 10; i++) {
            const categoryModel = new CategoryModel();
            categoryModel.id = i;
            categoryModel.name = 'Category ' + i.toString();
            result.push(categoryModel);
        }
        return result;
    }

    public submit(model: BlogModel): void {
        const id = this.routed.snapshot.params['id'];
        if (id) {
            this.model.id = id;
            this.blogService.updateBlog(model).subscribe(response => {
                this.model = response;
            });
        } else {
            this.blogService.addBlog(model).subscribe(response => {
                this.model = response;
            });
        }
    }
}
