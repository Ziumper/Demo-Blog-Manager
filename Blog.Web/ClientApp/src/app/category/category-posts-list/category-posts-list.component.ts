import { Component, OnInit } from '@angular/core';
import { PostsListComponent } from 'src/app/post/posts-list/posts-list.component';
import { PostService } from 'src/app/post/post.service';
import { PostSearchService } from 'src/app/post/post-search/post-search.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-category-posts-list',
    templateUrl: './category-posts-list.component.html',
    styleUrls: ['./category-posts-list.component.scss']
})
export class CategoryPostsListComponent extends PostsListComponent {

    constructor(private categoryPostService: PostService,
        private categoryPostSearchService: PostSearchService,
        private categoryActivatedRoute: ActivatedRoute) {
        super(categoryPostService, categoryPostSearchService, categoryActivatedRoute);
    }

    public getPosts(): void {
        const categoryId = this.categoryActivatedRoute.snapshot.params['categoryId'];
        this.postQueryModel.categoryId = categoryId;
        this.categoryPostService.getPostsPagedByCategoryId(this.postQueryModel).subscribe(response => {
            this.pageSize = response.size;
            this.posts = response.entities;
            this.page = response.page;
            this.collectionSize = response.count;
        });
    }
}

