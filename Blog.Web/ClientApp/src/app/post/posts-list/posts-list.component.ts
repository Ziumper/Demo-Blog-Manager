import { Component, OnInit, Input, EventEmitter, Output, OnDestroy } from '@angular/core';
import { PostService } from '../post.service';
import { PostModel } from '../models/post.model';
import { PostQueryModel } from '../models/post-query.model';
import { PostPagedModel } from '../models/post-paged.model';

@Component({
    selector: 'app-posts-list',
    templateUrl: './posts-list.component.html',
    styleUrls: ['./posts-list.component.scss']
})

export class PostsListComponent implements OnInit {
    public posts: Array<PostModel>;
    public page: number;
    public pageSize: number;
    @Input()
    public postQueryModel: PostQueryModel;

    constructor(private postService: PostService) {
    }

    public ngOnInit(): void {
        this.postService.getPostsPaged(this.postQueryModel).subscribe((data: PostPagedModel) => {
            this.posts = data.entities;
            this.page = data.page;
            this.pageSize = data.size;
        });
    }

}

