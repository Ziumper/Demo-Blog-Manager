import { Component, OnInit, Input, EventEmitter, Output, OnDestroy } from '@angular/core';
import { PostService } from '../post.service';
import { PostModel } from '../models/post.model';
import { PostQueryModel } from '../models/post-query.model';
import { PostPagedModel } from '../models/post-paged.model';
import { AlertService } from 'src/app/core/services/alert.service';

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

    public postsPagedModel: PostPagedModel;

    constructor(private postService: PostService) {
        this.postsPagedModel = new PostPagedModel();
    }

    public ngOnInit(): void {
       this.getPosts();
    }

    public onPageChange($event) {
        this.postQueryModel.page = $event;
        this.getPosts();
    }

    private getPosts(): void {
        this.postService.getPostsPaged(this.postQueryModel).subscribe((data: PostPagedModel) => {
            this.postsPagedModel = data;
         });
    }
}

