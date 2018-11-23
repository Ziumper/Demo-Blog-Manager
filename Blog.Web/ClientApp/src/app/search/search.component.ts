import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

@Component({
    selector: 'app-search',
    templateUrl: './app-search.component.html',
    styleUrls: ['./app-search.component.scss']
})
export class SearchComponent {
    public searchTerm: Subject<string>;
    @Output() searchEmit: EventEmitter<string>;

    constructor() {
        this.searchTerm = new Subject<string>();
     }

    private search(searchTerm: Observable<string>): void {
         searchTerm.pipe(
            debounceTime(400),
            distinctUntilChanged(),
            switchMap((query: string) => {
                this.searchEmit.emit(query);
                return null;
            })
        );

    }
}
