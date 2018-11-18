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

    public getCategoryById(id: number): Observable<CategoryModel> {
        return this.http.get<CategoryModel>(this.categoryApiUrl + '/' + id.toString());
    }

    public updateCategory(category: CategoryModel): Observable<CategoryModel> {
        return this.http.put<CategoryModel>(this.categoryApiUrl, category);
    }

    public addCategory(category: CategoryModel): Observable<CategoryModel> {
        return this.http.post<CategoryModel>(this.categoryApiUrl, category);
    }
}
