import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TagModel } from './models/tag.model';
import { HttpService } from '../core/http.service';

@Injectable()
export class TagService {
    private readonly tagApiUrl: string;

    constructor(private http: HttpService) {
        this.tagApiUrl = 'api/tags';
    }

    public getAllTags(): Observable<Array<TagModel>> {
        return this.http.get<Array<TagModel>>(this.tagApiUrl);
    }
}
