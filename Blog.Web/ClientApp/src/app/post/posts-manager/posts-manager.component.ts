import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';
import { ActivatedRoute } from '@angular/router';
import { PostSearchService } from '../post-search/post-search.service';
import { PostQueryModel } from '../models/post-query.model';


@Component({
    selector: 'app-posts-manager',
    templateUrl: './posts-manager.component.html',
    styleUrls: ['./posts-manager.component.scss']
})
export class PostsManagerComponent implements OnInit {

    public blogId;
    public postQueryModel: PostQueryModel;

    constructor(private managerPostService: PostService,
        private managerPostSearchService: PostSearchService,
        private managerActivatedRoute: ActivatedRoute) {
        this.blogId = this.managerActivatedRoute.parent.snapshot.params['blogId'];
        this.postQueryModel = new PostQueryModel();
    }

    public ngOnInit(): void {
        this.getPosts();
    }

    public getPosts() {
        // const blogId = this.managerActivatedRoute.parent.snapshot.params['blogId'];
        // if (blogId) {
        //     this.postQueryModel.blogId = blogId;
        //     this.managerPostService.getPostsPaged(this.postQueryModel).subscribe( response => {
        //         this.posts = response.entities;
        //         this.page = response.page;
        //         this.collectionSize = response.count;
        //         this.pageSize = response.size;
        //     });
        // }
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
        // this.checkOrder(filter);
        // this.postQueryModel.filter = filter;
        // this.getPosts();
    }

    private checkOrder(filter: number): void {
        // if (this.postQueryModel.filter === filter) {
        //     this.postQueryModel.order = !this.postQueryModel.order;
        // } else {
        //     this.postQueryModel.order = false;
        // }
    }

}
