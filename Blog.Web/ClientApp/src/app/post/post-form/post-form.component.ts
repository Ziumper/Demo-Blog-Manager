import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { PostModel } from '../models/post.model';
import { ActivatedRoute } from '@angular/router';
import { PostService } from '../post.service';

@Component({
    selector: 'app-post-form',
    templateUrl: './post-form.component.html',
    styleUrls: ['./post-form.component.scss']
})
export class PostFormComponent implements OnInit {
    public model: PostModel;

    constructor(private postService: PostService, private route: ActivatedRoute) {
        this.model = new PostModel();
     }

    public ngOnInit(): void { }

    public submit(model: PostModel): void {
        const id = this.route.snapshot.params['id'];
        if (id) {
            this.model.id = id;
            this.postService.updatePost(model).subscribe( response => {
                this.model = response;
            });
        } else {
            this.postService.addPost(model).subscribe(response => {
                this.model = response;
            });
        }
    }
}
