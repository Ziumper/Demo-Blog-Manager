import { Component, OnInit } from '@angular/core';
import { PostsListComponent } from '../../posts-list/posts-list.component';
import { PostService } from '../../post.service';
import { PostSearchService } from '../../post-search/post-search.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-posts-list-manager',
    templateUrl: './posts-list-manager.component.html',
    styleUrls: ['./posts-list-manager.component.scss']
})
export class PostsListManagerComponent extends PostsListComponent implements OnInit {

    constructor(private managerPostService: PostService,
        private managerPostSearchService: PostSearchService,
        private managerActivatedRoute: ActivatedRoute,
          ) {
        super(managerPostService, managerPostSearchService, managerActivatedRoute);
    }

}
