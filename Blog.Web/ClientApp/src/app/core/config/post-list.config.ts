import { PostModel } from 'src/app/post/models/post.model';
import { PostQueryModel } from 'src/app/post/models/post-query.model';
import { PostService } from 'src/app/post/post.service';
import { OnInit } from '@angular/core';
import { AppInjector } from '../app-injector.service';

export class PostListConfig implements OnInit  {

    public posts: Array<PostModel>;
    public collectionSize: number;
    public page: number;

    protected postQueryModel: PostQueryModel;
    protected postSerivce: PostService;

    constructor() {
        const injector = AppInjector.getInjector();
        this.postSerivce = injector.get(PostService);
        this.posts = new Array<PostModel>();
        this.collectionSize = 0;
        this.page = 1;
        this.postQueryModel = new PostQueryModel(this.page, 10, 1, true, '', [0], 0);
    }

    public ngOnInit(): void {
        this.getPosts();
    }

    public getPosts(): void {
        this.postSerivce.getPostsPaged(this.postQueryModel).subscribe(response => {
            this.posts = response.entities;
            this.collectionSize = response.size;
            this.page = response.page;
        });
    }

    public onPageChanged(page: number): void {
        this.postQueryModel.page = page;
        this.getPosts();
    }

}
