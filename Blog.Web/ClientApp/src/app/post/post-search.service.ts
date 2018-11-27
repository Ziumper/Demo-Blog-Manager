import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable()
export class PostSearchService {

    private subscription: Subject;

    constructor() {
        this.subscription = new Subject();
        
    }
    
}