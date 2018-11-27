import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { PostSearchService } from './post-search.service';

@Component({
    selector: 'app-post-search',
    templateUrl: './post-search.component.html',
    styleUrls: ['./post-search.component.scss']
})
export class PostSearchComponent implements OnInit {
    public searchTerm: Subject<string>;

    constructor() {
        this.searchTerm = new Subject<string>();
     }

    public ngOnInit(): void {
        this.onSearch(this.searchTerm).subscribe();
    }

    private onSearch(searchTerm: Observable<string>): Observable<any> {
        return searchTerm.pipe(
            debounceTime(400),
            distinctUntilChanged(),
            switchMap((query: string) => {
                return new Observable<any>();
            })
        );
    }


}
