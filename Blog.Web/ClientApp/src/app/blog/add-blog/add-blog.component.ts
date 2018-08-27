import { Component, OnInit } from '@angular/core';
import { CreateBlogModel } from '../models/create-blog.model';
import { BlogService } from '../blog.service';
import { BlogModel } from '../models/blog.model';

@Component({
    selector: 'app-add-blog',
    templateUrl: './add-blog.component.html',
    styleUrls: ['./add-blog.component.scss']
})
export class AddBlogComponent implements OnInit {


    constructor(private blogService: BlogService) {
       
     }

    public ngOnInit(): void { }

    public onSubmit(model: BlogModel) {
        console.log('Adding new blog!');
        let createModel = new CreateBlogModel(model.title);
        console.log(createModel);
        this.blogService.addBlog(createModel).subscribe( b => {
            console.log(b);
        });

    }
}
