import { Component, OnInit } from '@angular/core';
import { PostsListComponent } from 'src/app/post/posts-list/posts-list.component';

@Component({
    selector: 'app-name',
    templateUrl: './name.component.html',
    styleUrls: ['./name.component.scss']
})
export class BlogTagPostsListComponent extends PostsListComponent implements OnInit {
    constructor() {
        super();
    }

    public ngOnInit(): void {
        const blogId = this.activatedRoute.snapshot.params['blogId'];
        const tagId = this.activatedRoute.snapshot.params['tagId'];
        this.postQueryModel.blogId = blogId;
        this.postQueryModel.tagsIds = new Array<number>();
        this.postQueryModel.tagsIds.push(tagId);
        this.postService.getPostsPagedByBlogIdAndTags(this.postQueryModel)
        .subscribe(response => {
            this.posts = response.entities;
            this.page = response.page;
            this.collectionSize = response.count;
            this.pageSize = response.size;
        });
    }


}
