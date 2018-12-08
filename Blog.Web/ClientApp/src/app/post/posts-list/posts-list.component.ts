import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { PostService } from '../post.service';
import { PostModel } from '../models/post.model';
import { PostQueryModel } from '../models/post-query.model';
import { ActivatedRoute } from '@angular/router';
import { AppInjector } from 'src/app/core/app-injector.service';

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

    protected postService: PostService;
    protected activatedRoute: ActivatedRoute;

    constructor() {
        const injector = AppInjector.getInjector();
        this.postService = injector.get(PostService);
        this.activatedRoute = injector.get(ActivatedRoute);

        this.posts = new Array<PostModel>();
        this.collectionSize = 0;
        this.page = 1;
        this.pageSize = 5;
        this.postQueryModel = new PostQueryModel(this.page, 5, 1, true, '', [0], 0, 0);
    }

    public ngOnInit(): void {
        this.getPosts();
    }

    public onPageChange(page: number): void {
        this.postQueryModel.page = page;
        this.getPosts();
    }

    public getPosts(): void {
        const blogId = this.activatedRoute.snapshot.params['blogId'];
        const tagId = this.activatedRoute.snapshot.params['tagId'];
        if (blogId && tagId) {
            this.postQueryModel.blogId = blogId;
            this.postQueryModel.tagsIds = new Array<number>();
            this.postQueryModel.tagsIds.push(tagId);
            this.postService.getPostsPagedByBlogIdAndTags(this.postQueryModel).subscribe(response => {
                this.posts = response.entities;
                this.page = response.page;
                this.collectionSize = response.count;
                this.pageSize = response.size;
            });
        }
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

