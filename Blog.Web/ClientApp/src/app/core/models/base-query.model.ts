import { HttpParams } from '@angular/common/http';

export class BaseQueryModel {
    public page: number;
    public size: number;
    public filter: number;
    public order: boolean;
    public searchQuery: string;

    constructor() {
        this.page = 1;
        this.size = 10;
        this.filter = 0;
        this.order = false;
        this.searchQuery = '';
    }

    public getParams(): HttpParams {
        const params = new HttpParams()
        .set('page', this.page.toString())
        .set('size', this.size.toString())
        .set('filter', this.filter.toString())
        .set('order', this.order.toString())
        .set('searchQuery', this.searchQuery);
        return params;
    }


}


