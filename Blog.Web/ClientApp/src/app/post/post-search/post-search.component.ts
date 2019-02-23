import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { Subject, Observable, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { PostSearchService } from './post-search.service';
import { PostService } from '../post.service';
import { PostListConfig } from 'src/app/core/config/post-list.config';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-post-search',
    templateUrl: './post-search.component.html',
    styleUrls: ['./post-search.component.scss']
})
export class PostSearchComponent extends PostListConfig implements OnInit {

    constructor(private searchPostService: PostService,
        private searchActivatedService: ActivatedRoute ) {
        super(searchActivatedService, searchPostService);

     }

    public ngOnInit() {
        const searchQuery = this.searchActivatedService.snapshot.params['searchQuery'];
        if (searchQuery) {
            this.postQueryModel.searchQuery = searchQuery;
        }
        super.ngOnInit();
    }
}
