import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TagModel } from './models/tag.model';
import { HttpService } from '../core/services/http.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class TagService {
    private readonly tagApiUrl: string;

    constructor(private http: HttpClient) {
        this.tagApiUrl = 'api/tag';
    }

    public getAllTags(): Observable<Array<TagModel>> {
        return this.http.get<Array<TagModel>>(this.tagApiUrl);
    }

    public updateTag(tagModel: TagModel): Observable<TagModel> {
        return this.http.put<TagModel>(this.tagApiUrl, tagModel);
    }

    public addTag(tagModel: TagModel): Observable<TagModel> {
        return this.http.post<TagModel>(this.tagApiUrl, tagModel);
    }

    public getTagById(id: number): Observable<TagModel> {
        return this.http.get<TagModel>(this.tagApiUrl + '/' + id.toString());
    }

    public getTagsByName(name: string): Observable<Array<TagModel>> {
        return this.http.get<Array<TagModel>>(this.tagApiUrl + '/' + name);
    }
}
