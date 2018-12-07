import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { PostService } from '../post.service';
import { PostModel } from '../models/post.model';
import { PostQueryModel } from '../models/post-query.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-posts-list',
    templateUrl: './posts-list.component.html',
    styleUrls: ['./posts-list.component.scss']
})

export class PostsListComponent implements OnInit {


    public posts: Array<PostModel>;
    public collectionSize: number;
    public page: number;
    public pageSize: number;
    public postQueryModel: PostQueryModel;

    constructor(private postService: PostService,
        private activatedRoute: ActivatedRoute) {
        this.posts = new Array<PostModel>();
        this.collectionSize = 0;
        this.page = 1;
        this.pageSize = 5;
        this.postQueryModel = new PostQueryModel(this.page, 5, 1, true, '', [0], 0);
    }

    public ngOnInit(): void {

    }

    public onPageChange(page: number): void {
        this.postQueryModel.page = page;
        this.getPosts();
    }

    public getPosts(): void {
        const blogId = this.activatedRoute.snapshot.params['blogId'];
        if (blogId) {
            this.postQueryModel.blogId = blogId;
            this.postService.getPostsPagedByBlogId(this.postQueryModel)
            .subscribe(response => {
                this.posts = response.entities;
                this.pageSize = response.size;
                this.collectionSize = response.count;
                this.page = response.page;
            });
        }

    }


}

