import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';
import { ActivatedRoute } from '@angular/router';
import { PostSearchService } from '../post-search/post-search.service';
import { PostQueryModel } from '../models/post-query.model';
import { PostPagedModel } from '../models/post-paged.model';


@Component({
    selector: 'app-posts-manager',
    templateUrl: './posts-manager.component.html',
    styleUrls: ['./posts-manager.component.scss']
})
export class PostsManagerComponent implements OnInit {

    public blogId;
    public postQueryModel: PostQueryModel;
    public postsPagedModel: PostPagedModel;

    constructor(private managerPostService: PostService,
        private managerActivatedRoute: ActivatedRoute) {
        this.blogId = this.managerActivatedRoute.parent.snapshot.params['blogId'];
        this.postQueryModel = new PostQueryModel();
        this.postsPagedModel = new PostPagedModel();
    }

    public ngOnInit(): void {
        this.getPosts();
    }

    public getPosts() {
        const blogId = this.managerActivatedRoute.parent.snapshot.params['blogId'];
        if (blogId) {
            this.postQueryModel.blogId = blogId;
            this.managerPostService.getPostsPagedByBlogId(this.postQueryModel).subscribe( response => {
               this.postsPagedModel = response;
            });
        }
    }

    public onPageChange($event) {
        this.postQueryModel.page = $event;
        this.managerPostService.getPostsPagedByBlogId(this.postQueryModel).subscribe(response => {
            this.postsPagedModel = response;
        });
    }

    public deletePost(id: number) {
        this.managerPostService.deletePostById(id).subscribe(response => {
            this.getPosts();
        });
    }

    public sort(filter: number) {
        this.checkOrder(filter);
        this.postQueryModel.filter = filter;
        this.getPosts();
    }

    private checkOrder(filter: number): void {
        if (this.postQueryModel.filter === filter) {
            this.postQueryModel.order = !this.postQueryModel.order;
        } else {
            this.postQueryModel.order = false;
        }
    }

}
