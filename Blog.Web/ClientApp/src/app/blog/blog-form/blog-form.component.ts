import { Component, OnInit } from '@angular/core';
import { CreateBlogModel } from '../models/create-blog.model';

@Component({
    selector: 'app-blog-form',
    templateUrl: './blog-form.component.html',
    styleUrls: ['./blog-form.component.scss']
})
export class BlogFormComponent implements OnInit {

    public model: CreateBlogModel;

    constructor() {
        this.model = new CreateBlogModel('');
     }

    public ngOnInit(): void { }

    public onSubmit() {
        console.log('Adding new blog!');
    }
}
