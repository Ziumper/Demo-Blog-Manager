import { Component, OnInit } from '@angular/core';
import { PostListConfig } from '../core/config/post-list.config';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-tag',
    templateUrl: './tag.component.html',
    styleUrls: ['./tag.component.scss']
})
export class TagComponent extends PostListConfig implements OnInit {

    constructor(private route: ActivatedRoute) {
        super();
    }

    public ngOnInit(): void {
        const id = this.route.snapshot.params['id'];
        this.postQueryModel.tagsIds = [id];
        this.getPosts();
    }

    public getPosts(): void {
        this.postSerivce.getPostsPagedByTags(this.postQueryModel).subscribe(response => {
            this.posts = response.entities;
            this.collectionSize = response.count;
            this.page = response.page;
        });
    }
}
