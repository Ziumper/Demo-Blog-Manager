import { Component, OnInit, Input } from '@angular/core';
import { PostService } from '../post.service';
import { PostModel } from '../models/post.model';
import { BaseQueryModel } from 'src/app/core/models/base-query.model';
import { PostQueryModel } from '../models/post-query.model';

@Component({
    selector: 'app-posts-list',
    templateUrl: './posts-list.component.html',
    styleUrls: ['./posts-list.component.scss']
})
export class PostsListsComponent implements OnInit {

    @Input()
    public postQuery: PostQueryModel;
    public posts: Array<PostModel>;
    public collectionCount: number;

    constructor(private postService: PostService) {
        this.posts = new Array<PostModel>();
        this.postQuery = new PostQueryModel(1, 10, 1, true, 'post',0,0);
        this.collectionCount = 0;
    }

    public ngOnInit(): void {
        console.log(this.postQuery);
        this.getPosts();
    }

    private getPosts(): void {
        this.postService.getPostsPaged(this.postQuery).subscribe(response => {
            this.posts = response.entities;
            this.postQuery.size = response.size;
            this.postQuery.page = response.page;
            this.collectionCount = response.count;
        });
    }

    public onPageChange(page): void {
        this.postQuery.page = page;
        this.getPosts();
    }
}
