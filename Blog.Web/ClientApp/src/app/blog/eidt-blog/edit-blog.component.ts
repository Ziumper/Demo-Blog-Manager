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

    private id: number;

    constructor(private blogService: BlogService,private route:ActivatedRoute) {
        this.model = new BlogModel(0, '');
        this.id = 0;
     }

    public ngOnInit(): void {
        this.getIdFromRoute();
        this.getBlog();
    }

    public onSubmit(): void {}

    private getIdFromRoute(): void {
        this.id = this.route.snapshot.params['id'];
    }

    private getBlog(): void {
        this.blogService.getBlogById(this.id).subscribe(response => {
            this.model = response;
        })
    }
}
