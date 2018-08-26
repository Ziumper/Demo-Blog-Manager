import { Component, OnInit } from '@angular/core';
import { CreateBlogModel } from '../models/create-blog.model';
import { BlogService } from '../blog.service';

@Component({
    selector: 'app-blog-form',
    templateUrl: './blog-form.component.html',
    styleUrls: ['./blog-form.component.scss']
})
export class BlogFormComponent implements OnInit {

    public model: CreateBlogModel;

    constructor(private blogService: BlogService) {
        this.model = new CreateBlogModel('');
     }

    public ngOnInit(): void { }

    public onSubmit() {
        console.log('Adding new blog!');
        console.log(this.model);
        this.blogService.addBlog(this.model).subscribe( b => {
            console.log(b);
        });

    }
}
