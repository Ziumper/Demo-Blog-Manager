import { Component, OnInit, Input } from '@angular/core';
import { PostQueryModel } from '../models/post-query.model';
import { PostService } from '../post.service';
import { PostModel } from '../models/post.model';

@Component({
    selector: 'app-posts-list',
    templateUrl: './posts-list.component.html',
    styleUrls: ['./posts-list.component.scss']
})
export class PostsListsComponent implements OnInit {

    @Input()
    public postQuery: PostQueryModel;

    public posts: Array<PostModel>;

    constructor(private postService: PostService) {
        this.posts = new Array<PostModel>();
        this.postQuery = new PostQueryModel();
    }

    public ngOnInit(): void {
        this.getTestPosts();
        console.log('Hello from post list component');
        console.log('post title ' + this.postQuery.title);
    }

    public getPosts(): void {
        this.postService.getPostsPaged(this.postQuery);
    }

    public getTestPosts(): void {
        const postModel1 = new PostModel();
        postModel1.title = 'Test postModel1';
        postModel1.content = 'testContent';
        for (let i = 0; i < 10 ; i++) {
            this.posts.push(postModel1);
        }
    }

}
