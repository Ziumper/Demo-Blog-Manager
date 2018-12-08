import { Component, OnInit } from '@angular/core';
import { PostsListComponent } from 'src/app/post/posts-list/posts-list.component';
import { PostService } from 'src/app/post/post.service';
import { ActivatedRoute } from '@angular/router';
import { PostSearchService } from 'src/app/post/post-search/post-search.service';

@Component({
    selector: 'app-tag-posts-list',
    templateUrl: './tag-posts-list.component.html',
    styleUrls: ['./tag-posts-list.component.scss']
})
export class TagPostsListComponent extends PostsListComponent implements OnInit {
    constructor(private tagPostService: PostService, private tagActivatedRoute: ActivatedRoute,
        private tagPostSearchService: PostSearchService) {
        super(tagPostService, tagPostSearchService, tagActivatedRoute );
    }

    ngOnInit(): void {
        const tagId = this.tagActivatedRoute.snapshot.params['tagId'];
        this.postQueryModel.tagsIds = new Array<number>();
        this.postQueryModel.tagsIds.push(tagId);
        this.tagPostService.getPostsPagedByTags(this.postQueryModel).subscribe(response => {
            this.posts = response.entities;
            this.pageSize = response.size;
            this.collectionSize = response.count;
            this.page  = response.page;
        });
    }
}
