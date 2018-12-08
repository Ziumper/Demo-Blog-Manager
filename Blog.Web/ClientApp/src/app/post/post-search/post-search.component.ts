import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { Subject, Observable, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { PostSearchService } from './post-search.service';

@Component({
    selector: 'app-post-search',
    templateUrl: './post-search.component.html',
    styleUrls: ['./post-search.component.scss']
})
export class PostSearchComponent implements OnInit, OnDestroy {
    public searchTerm: Subject<string>;

    private search: Subscription;

    constructor(private postSearchService: PostSearchService) {
        this.searchTerm = new Subject<string>();
     }

    public ngOnInit(): void {
        this.search = this.onSearch(this.searchTerm).subscribe();
    }

    public ngOnDestroy(): void {
        this.search.unsubscribe();
    }

    private onSearch(searchTerm: Observable<string>): Observable<any> {
        return searchTerm.pipe(
            debounceTime(400),
            distinctUntilChanged(),
            switchMap((query: string) => {
                this.postSearchService.sendMessage(query);
                return new Observable<any>();
            })
        );
    }


}
