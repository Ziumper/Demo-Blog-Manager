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

    public category: CategoryModel;
    public model: BlogModel;
    public categories: Array<CategoryModel>;

    public constructor(
        private routed: ActivatedRoute,
        private blogService: BlogService,
        private categoryService: CategoryService) {
        this.model = new BlogModel(0, '', new Date(), new Date(), new CategoryModel(0, ''));
        this.categories = new Array<CategoryModel>();
    }

    public ngOnInit(): void {
        this.categoryService.getAllCategories().subscribe(response => {
            this.categories = response;
        });
        const id = this.routed.parent.snapshot.params['blogId'];
        if (id) {
            this.blogService.getBlogById(id).subscribe(response => {
                this.model = response;
            });
        }
    }

    public submit(model: BlogModel): void {
        const id = this.routed.snapshot.params['blogId'];
        if (id) {
            this.model.id = id;
            this.blogService.updateBlog(model).subscribe();
        } else {
            this.blogService.addBlog(model).subscribe();
        }
    }
}
