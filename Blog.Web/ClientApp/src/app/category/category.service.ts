import { Injectable } from '@angular/core';
import { HttpService } from '../core/http.service';
import { CategoryModel } from './models/category.model';
import { Observable } from 'rxjs';

@Injectable()
export class CategoryService {
    private categoryApiUrl: string;

    constructor(private http: HttpService) {
        this.categoryApiUrl = 'api/category';
    }

    public getAllCategories(): Observable<Array<CategoryModel>> {
       return this.http.get<Array<CategoryModel>>(this.categoryApiUrl);
    }
}
