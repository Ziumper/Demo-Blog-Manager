import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';
import { ActivatedRoute } from '@angular/router';
import { PostSearchService } from '../post-search/post-search.service';
import { PostListConfig } from 'src/app/core/config/post-list.config';

@Component({
    selector: 'app-posts-manager',
    templateUrl: './posts-manager.component.html',
    styleUrls: ['./posts-manager.component.scss']
})
export class PostsManagerComponent extends PostListConfig implements OnInit {

    public blogId;

    constructor(private managerPostService: PostService,
        private managerPostSearchService: PostSearchService,
        private managerActivatedRoute: ActivatedRoute) {
        super(managerActivatedRoute, managerPostService);
            this.blogId = this.managerActivatedRoute.parent.snapshot.params['blogId'];
    }


    public getPosts() {
        const blogId = this.managerActivatedRoute.parent.snapshot.params['blogId'];
        if (blogId) {
            this.postQueryModel.blogId = blogId;
            this.managerPostService.getPostsPaged(this.postQueryModel).subscribe( response => {
                this.posts = response.entities;
                this.page = response.page;
                this.collectionSize = response.count;
                this.pageSize = response.size;
            });
        }
    }

    public publishPost() {
        console.log('Pusblish post');
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
