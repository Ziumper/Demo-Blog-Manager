import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { PostModel } from '../models/post.model';
import { ActivatedRoute, Router } from '@angular/router';
import { PostService } from '../post.service';
import { AlertService } from 'src/app/core/services/alert.service';


@Component({
    selector: 'app-post-form',
    templateUrl: './post-form.component.html',
    styleUrls: ['./post-form.component.scss']
})
export class PostFormComponent implements OnInit {
    public model: PostModel;
    public tagName: String;
    public url: String;

    constructor(private postService: PostService, private route: ActivatedRoute,
        private alertService: AlertService,
        private router: Router) {
        this.model = new PostModel();
    }

    public ngOnInit(): void {
        this.model.blogId = this.route.parent.snapshot.params['blogId'];
        const postId = this.route.snapshot.params['postId'];
        if (postId) {
            this.postService.getPostById(postId).subscribe( response => {
                this.model = response;
            });
        }
    }

    public submit(model: PostModel): void {
        const id = this.route.snapshot.params['id'];
        if (id) {
            this.model.id = id;
            this.postService.updatePost(model).subscribe();
        } else {
            this.postService.addPost(model).subscribe(response => {
                this.alertService.success('Post succesfully added', true);
                this.router.navigate(['/', 'blog-manager', this.model.blogId, 'blog']);
            });
        }
    }

}
