import { Component, OnInit, Input } from '@angular/core';
import { CreateBlogModel } from '../models/create-blog.model';
import { BlogService } from '../blog.service';
import { BlogModel } from '../models/blog.model';

@Component({
    selector: 'app-add-blog',
    templateUrl: './add-blog.component.html',
    styleUrls: ['./add-blog.component.scss']
})
export class AddBlogComponent implements OnInit {

    @Input()
    public action: string;

    constructor(private blogService: BlogService) {
       this.action = "Add";
     }

    public ngOnInit(): void { }

    public onSubmit(model: BlogModel) {
        let createModel = new CreateBlogModel(model.title);
        this.blogService.addBlog(createModel);
          

    }
}
