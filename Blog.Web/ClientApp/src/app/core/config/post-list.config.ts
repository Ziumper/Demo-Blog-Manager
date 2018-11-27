import { PostModel } from 'src/app/post/models/post.model';
import { PostQueryModel } from 'src/app/post/models/post-query.model';
import { PostService } from 'src/app/post/post.service';
import { OnInit, OnDestroy } from '@angular/core';
import { AppInjector } from '../app-injector.service';
import { PostSearchService } from 'src/app/post/post-search/post-search.service';
import { Subscription } from 'rxjs';

export class PostListConfig implements OnInit, OnDestroy  {
    public posts: Array<PostModel>;
    public collectionSize: number;
    public page: number;
    public pageSize: number;

    protected postQueryModel: PostQueryModel;
    protected postSerivce: PostService;
    protected postSearchService: PostSearchService;
    protected subscription: Subscription;

    constructor() {
        const injector = AppInjector.getInjector();
        this.postSerivce = injector.get(PostService);
        this.postSearchService = injector.get(PostSearchService);
        this.posts = new Array<PostModel>();
        this.collectionSize = 0;
        this.page = 1;
        this.pageSize = 5;
        this.postQueryModel = new PostQueryModel(this.page, 5, 1, true, '', [0], 0);

        this.subscription = this.postSearchService.getMessage().subscribe(message => {
            this.onSearch(message);
        });
    }

    public ngOnInit(): void {
        this.getPosts();
    }

    public ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }


    public getPosts(): void {
        this.postSerivce.getPostsPaged(this.postQueryModel).subscribe(response => {
            this.posts = response.entities;
            this.collectionSize = response.count;
            this.page = response.page;
            this.pageSize = response.size;
        });
    }

    public onPageChanged(page: number): void {
        this.postQueryModel.page = page;
        this.getPosts();
    }

    public onSearch(searchQuery: string): void {
        this.postQueryModel.searchQuery = searchQuery;
        this.getPosts();
    }

}
