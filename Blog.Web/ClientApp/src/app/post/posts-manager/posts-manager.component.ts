import { Component, OnInit } from '@angular/core';
import { PostsListComponent } from '../posts-list/posts-list.component';
import { PostService } from '../post.service';
import { ActivatedRoute } from '@angular/router';
import { PostSearchService } from '../post-search/post-search.service';

@Component({
    selector: 'app-posts-manager',
    templateUrl: './posts-manager.component.html',
    styleUrls: ['./posts-manager.component.scss']
})
export class PostsManagerComponent extends PostsListComponent implements OnInit {
    constructor(private managerPostService: PostService,
        private managerPostSearchService: PostSearchService,
        private managerActivatedRoute: ActivatedRoute) {
        super(managerPostService, managerPostSearchService, managerActivatedRoute);
    }

}
