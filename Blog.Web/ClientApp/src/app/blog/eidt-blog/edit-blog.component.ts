import { Component, OnInit } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { BlogService } from '../blog.service';

@Component({
    selector: 'app-edit-blog',
    templateUrl: './edit-blog.component.html',
    styleUrls: ['./edit-blog.component.scss']
})
export class EditBlogComponent implements OnInit {

    public model: BlogModel;

    constructor(private blogService: BlogService) {
        this.model = new BlogModel(0, '');
     }

    public ngOnInit(): void {}

    public onSubmit(): void {}
}
