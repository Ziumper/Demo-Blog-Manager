import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { CreateBlogModel } from '../models/create-blog.model';
import { ActivatedRoute } from '@angular/router';
import { BlogService } from '../blog.service';

@Component({
    selector: 'app-blog-form',
    templateUrl: './blog-form.component.html',
    styleUrls: ['./blog-form.component.scss']
})
export class BlogFormComponent implements OnInit {

    public model: BlogModel;

    public constructor(private routed: ActivatedRoute, private blogService: BlogService) {
        this.model = new BlogModel();
    }

    public ngOnInit(): void { }

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
