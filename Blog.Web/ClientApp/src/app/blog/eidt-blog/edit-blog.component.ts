import { Component, OnInit } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { BlogService } from '../blog.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-edit-blog',
    templateUrl: './edit-blog.component.html',
    styleUrls: ['./edit-blog.component.scss']
})
export class EditBlogComponent implements OnInit {

    public model: BlogModel;
    public action: string;

    constructor(private blogService: BlogService,private route:ActivatedRoute) {
        this.model = new BlogModel(0, '');
        this.action = "Edit"
    }

    public ngOnInit(): void {
        let id = this.getIdFromRoute();
        this.getBlog(id);
    }

    public onSubmit(model: BlogModel): void {
        this.updateBlog(model);
    }

    private getIdFromRoute(): number {
        return this.route.snapshot.params['id'];
    }

    private getBlog(id: number): void {
        this.blogService.getBlogById(id).subscribe(response => {
            this.model = response;
        })
    }

    private updateBlog(model: BlogModel) : void {
        this.blogService.updateBlog(model).subscribe(response => {
            this.model = response;
        })
    }

   
}
