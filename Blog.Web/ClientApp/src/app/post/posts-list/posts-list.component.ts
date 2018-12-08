import { Component, OnInit, Input, EventEmitter, Output, OnDestroy } from '@angular/core';
import { PostService } from '../post.service';
import { PostModel } from '../models/post.model';
import { PostQueryModel } from '../models/post-query.model';
import { ActivatedRoute } from '@angular/router';
import { AppInjector } from 'src/app/core/app-injector.service';
import { PostSearchService } from '../post-search/post-search.service';
import { Observable, Subscription } from 'rxjs';
import { PostListConfig } from 'src/app/core/config/post-list.config';

@Component({
    selector: 'app-posts-list',
    templateUrl: './posts-list.component.html',
    styleUrls: ['./posts-list.component.scss']
})

export class PostsListComponent implements OnInit, OnDestroy {

    public posts: Array<PostModel>;
    public collectionSize: number;
    public page: number;
    public pageSize: number;
    public postQueryModel: PostQueryModel;

    private postSearch: Subscription;

    constructor(private postService: PostService, private postSearchService: PostSearchService,
        private activatedRoute: ActivatedRoute) {
        this.posts = new Array<PostModel>();
        this.collectionSize = 0;
        this.page = 1;
        this.pageSize = 5;
        this.postQueryModel = new PostQueryModel(this.page, 5, 1, true, '', [0], 0, 0);
    }

    public ngOnDestroy(): void {
       this.postSearch.unsubscribe();
    }

    public ngOnInit(): void {
        this.postSearch = this.postSearchService.getMessage().subscribe(query => {
            this.postQueryModel.searchQuery = query;
            this.getPosts();
        });
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

