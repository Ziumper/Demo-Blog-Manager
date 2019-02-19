import { Component, OnInit, Input, EventEmitter, Output, OnDestroy } from '@angular/core';
import { PostService } from '../post.service';
import { PostModel } from '../models/post.model';
import { PostQueryModel } from '../models/post-query.model';
import { ActivatedRoute } from '@angular/router';
import { PostSearchService } from '../post-search/post-search.service';
import { Observable, Subscription } from 'rxjs';
import { PostListConfig } from 'src/app/core/config/post-list.config';

@Component({
    selector: 'app-posts-list',
    templateUrl: './posts-list.component.html',
    styleUrls: ['./posts-list.component.scss']
})

export class PostsListComponent  {

    @Input()
    public posts: Array<PostModel>;
    @Input()
    public collectionSize: number;
    @Input()
    public page: number;
    @Input()
    public pageSize: number;
    @Input()
    public postQueryModel: PostQueryModel;

}

