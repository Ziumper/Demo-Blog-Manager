import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { CreateBlogModel } from '../models/create-blog.model';

@Component({
    selector: 'app-blog-form',
    templateUrl: './blog-form.component.html',
    styleUrls: ['./blog-form.component.scss']
})
export class BlogFormComponent implements OnInit {

    @Input()
    public model: BlogModel;

    @Output()
    public submited: EventEmitter<BlogModel>

    public constructor() { 
        this.model = new BlogModel();
        this.submited = new EventEmitter<BlogModel>();
    }

    public ngOnInit(): void { }

    public submit(model: BlogModel): void {
        this.submited.emit(model);
    }
}
