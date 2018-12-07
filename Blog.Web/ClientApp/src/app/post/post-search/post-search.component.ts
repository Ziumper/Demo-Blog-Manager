import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

@Component({
    selector: 'app-post-search',
    templateUrl: './post-search.component.html',
    styleUrls: ['./post-search.component.scss']
})
export class PostSearchComponent implements OnInit {

    @Output()
    public searched: EventEmitter<string>;
    public searchTerm: Subject<string>;

    constructor() {
        this.searchTerm = new Subject<string>();
        this.searched = new EventEmitter<string>();
     }

    public ngOnInit(): void {
        this.onSearch(this.searchTerm).subscribe();
    }

    private onSearch(searchTerm: Observable<string>): Observable<any> {
        return searchTerm.pipe(
            debounceTime(400),
            distinctUntilChanged(),
            switchMap((query: string) => {
                this.searched.emit(query);
                return new Observable<any>();
            })
        );
    }


}
