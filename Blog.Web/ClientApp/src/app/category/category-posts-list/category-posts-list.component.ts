import { Component, OnInit } from '@angular/core';
import { PostsListComponent } from 'src/app/post/posts-list/posts-list.component';

@Component({
    selector: 'app-category-posts-list',
    templateUrl: './name.component.html',
    styleUrls: ['./name.component.scss']
})
export class CategoryPostsListComponent extends PostsListComponent implements OnInit {
    constructor() {
        super();
    }

    public ngOnInit(): void {
        const categoryId = this.activatedRoute.snapshot.params['categoryId'];
        this.postQueryModel.categoryId = categoryId;
        this.postService.getPostsPagedByCategoryId(this.postQueryModel).subscribe(response => {
            this.pageSize = response.size;
            this.posts = response.entities;
            this.page = response.page;
            this.collectionSize = response.count;
        });
    }
}

