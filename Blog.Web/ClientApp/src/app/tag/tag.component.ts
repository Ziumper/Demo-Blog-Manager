import { Component, OnInit } from '@angular/core';
import { PostListConfig } from '../core/config/post-list.config';
import { ActivatedRoute } from '@angular/router';
import { PostSearchService } from '../post/post-search/post-search.service';
import { PostService } from '../post/post.service';

@Component({
    selector: 'app-tag',
    templateUrl: './tag.component.html',
    styleUrls: ['./tag.component.scss']
})
export class TagComponent extends PostListConfig implements OnInit {

    constructor(private tagActivatedRoute: ActivatedRoute,
        private postSearchServiceTag: PostSearchService,
        private postServiceTag: PostService) {
        super(postSearchServiceTag, tagActivatedRoute, postServiceTag);
    }

    public ngOnInit(): void {
        super.ngOnInit();
    }

    public getPosts() {
        const tagId = this.tagActivatedRoute.snapshot.params['tagId'];
        this.postQueryModel.tagsIds = new Array<number>();
        this.postQueryModel.tagsIds.push(tagId);
        this.postServiceTag.getPostsPagedByTags(this.postQueryModel).subscribe(response => {
            this.posts = response.entities;
            this.pageSize = response.size;
            this.collectionSize = response.count;
            this.page  = response.page;
        });
    }

}
