import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { PostService } from '../post.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-post-search',
    templateUrl: './post-search.component.html',
    styleUrls: ['./post-search.component.scss']
})
export class PostSearchComponent implements OnInit {

    constructor(private searchPostService: PostService,
        private searchActivatedService: ActivatedRoute ) {
     }

    public ngOnInit() {
    }
}
