import { Subject, Observable } from 'rxjs';
import { Injectable } from '@angular/core';


@Injectable()
export class LoaderService {

    private isLoading: Subject<boolean>;

    constructor() {
        this.isLoading = new Subject<boolean>();
    }

    public activateLoading(): void {
        this.isLoading.next(true);
    }

    public deactivateLoading(): void {
        this.isLoading.next(false);
    }

    public getLoaderObservable(): Observable<boolean> {
        const result = this.isLoading.asObservable();
        return result;
    }
}
