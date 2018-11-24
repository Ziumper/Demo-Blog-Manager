import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

@Component({
    selector: 'app-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

    public searchTerm: Subject<string>;
    @Output() search: EventEmitter<string>;

    constructor() {
        this.searchTerm = new Subject<string>();
        this.search = new EventEmitter<string>();
     }

    public ngOnInit(): void {
        this.onSearch(this.searchTerm).subscribe();
    }

    private onSearch(searchTerm: Observable<string>): Observable<any> {
        return searchTerm.pipe(
            debounceTime(400),
            distinctUntilChanged(),
            switchMap((query: string) => {
                this.search.emit(query);
                return new Observable<any>();
            })
        );

    }
}
