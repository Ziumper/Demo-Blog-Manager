import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { ActivatedRoute } from '@angular/router';
import { BlogService } from '../blog.service';

@Component({
    selector: 'app-blog-form',
    templateUrl: './blog-form.component.html',
    styleUrls: ['./blog-form.component.scss']
})
export class BlogFormComponent implements OnInit {

    public model: BlogModel;

    public constructor(
        private routed: ActivatedRoute,
        private blogService: BlogService) {
    }

    public ngOnInit(): void {
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
