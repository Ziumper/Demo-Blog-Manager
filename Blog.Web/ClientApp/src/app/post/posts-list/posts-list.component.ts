import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { PostService } from '../post.service';
import { PostModel } from '../models/post.model';
import { PostQueryModel } from '../models/post-query.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-posts-list',
    templateUrl: './posts-list.component.html',
    styleUrls: ['./posts-list.component.scss']
})
export class PostsListsComponent implements OnInit {

    @Input()
    public posts: Array<PostModel>;
    @Input()
    public collectionSize: Number;
    @Input()
    public page: Number;
    @Input()
    public pageSize: Number;
    @Output() pageChange: EventEmitter<Number>;


    constructor() {
        this.posts = new Array<PostModel>();
        this.pageChange = new EventEmitter<Number>();
        this.collectionSize = 0;
        this.page = 0;
        this.pageSize = 0;
    }

    public ngOnInit(): void {
    }

    public onPageChange(page: number): void {
        this.pageChange.emit(page);
    }
}
