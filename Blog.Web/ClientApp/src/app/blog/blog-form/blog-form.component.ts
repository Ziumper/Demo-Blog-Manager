import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BlogModel } from '../models/blog.model';
import { ActivatedRoute } from '@angular/router';
import { BlogService } from '../blog.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'app-blog-form',
    templateUrl: './blog-form.component.html',
    styleUrls: ['./blog-form.component.scss']
})
export class BlogFormComponent implements OnInit {

    public blogForm: FormGroup;
    public submitted: boolean;

    public constructor(
        private formBuilder: FormBuilder,
        private routed: ActivatedRoute,
        private blogService: BlogService) {
    }

    get title() { return this.blogForm.get('title'); }

    public ngOnInit(): void {
        this.submitted = false;
        const id = this.routed.parent.snapshot.params['blogId'];
        this.blogForm = this.formBuilder.group({
            id: [id],
            title: ['', Validators.required],
            creationDate: [],
            modificationDate: []
        });

      
        if (id) {
            this.blogService.getBlogById(id).subscribe(response => {
                this.blogForm.setValue(response);
            });
        }
    }

    public onSubmit(): void {
        this.submitted = true;
        const id = this.routed.snapshot.params['blogId'];
        if (id) {
            this.blogService.updateBlog(this.blogForm.value).subscribe();
        } else {
            this.blogService.addBlog(this.blogForm.value).subscribe();
        }
    }
}
