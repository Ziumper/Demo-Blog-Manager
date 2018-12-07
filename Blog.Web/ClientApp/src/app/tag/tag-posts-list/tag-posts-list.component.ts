import { Component, OnInit } from '@angular/core';
import { PostsListComponent } from 'src/app/post/posts-list/posts-list.component';

@Component({
    selector: 'app-tag-posts-list',
    templateUrl: './tag-posts-list.component.html',
    styleUrls: ['./tag-posts-list.component.scss']
})
export class TagPostsListComponent extends PostsListComponent implements OnInit {
    constructor() {
        super();
    }

    ngOnInit(): void {
        const tagId = this.activatedRoute.snapshot.params['tagId'];
        this.postQueryModel.tagsIds = new Array<number>();
        this.postQueryModel.tagsIds.push(tagId);
        this.postService.getPostsPagedByTags(this.postQueryModel).subscribe(response => {
            this.posts = response.entities;
            this.pageSize = response.size;
            this.collectionSize = response.count;
            this.page  = response.page;
        });
    }
}
