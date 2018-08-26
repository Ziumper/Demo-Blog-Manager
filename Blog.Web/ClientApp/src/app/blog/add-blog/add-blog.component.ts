import { Component, OnInit } from '@angular/core';
import { CreateBlogModel } from '../models/create-blog.model';
import { BlogService } from '../blog.service';

@Component({
    selector: 'app-add-blog',
    templateUrl: './add-blog.component.html',
    styleUrls: ['./add-blog.component.scss']
})
export class AddBlogComponent implements OnInit {

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
