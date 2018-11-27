import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable()
export class PostSearchService {

    private subject: Subject<string>;

    constructor() {
        this.subject = new Subject<string>();
    }

    public sendMessage(message: string): void {
        this.subject.next(message);
    }

    public clearMessage(): void {
        this.subject.next();
    }

    public getMessage(): Observable<string> {
        return this.subject.asObservable();
    }
}
