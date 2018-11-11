import { Subject, Observable, BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';


@Injectable()
export class LoaderService {

    private isLoading: BehaviorSubject<boolean>;
    private isSmallLoading: BehaviorSubject<boolean>;

    constructor() {
        this.isLoading = new BehaviorSubject<boolean>(false);
        this.isSmallLoading = new BehaviorSubject<boolean>(false);
    }

    public activateLoading(): void {
        this.isLoading.next(true);

    }

    public acitvateSmallLoading(): void {
        this.isSmallLoading.next(true);
    }

    public deactivateLoading(): void {
        this.isLoading.next(false);
    }

    public deactivateSmallLoading(): void {
        this.isSmallLoading.next(false);
    }

    public getLoaderObservable(): Observable<boolean> {
        const result = this.isLoading.asObservable();
        return result;
    }

    public getSmallLoaderObservable(): Observable<boolean> {
        const result = this.isSmallLoading.asObservable();
        return result;
    }
}
