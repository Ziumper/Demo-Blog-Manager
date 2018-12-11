import { Component, OnInit } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { BlogService } from '../blog.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-blogs-manager',
    templateUrl: './blog-manager.component.html',
    styleUrls: ['./blog-manager.component.scss'],
})
export class BlogManagerComponent implements OnInit {

    public blog: BlogModel;

    constructor(
        private blogService: BlogService,
        private activatedRoute: ActivatedRoute) {
    }

    public ngOnInit(): void {
        const id = this.activatedRoute.snapshot.params['blogId'];
        this.blogService.getBlogById(id).subscribe(response => {
            this.blog = response;
        });
    }

}
