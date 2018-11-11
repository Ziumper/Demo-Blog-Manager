import { HttpParams } from '@angular/common/http';
import { BaseQueryModel } from '../../models/base-query.model';

export class BlogQueryModel extends BaseQueryModel {
    public title: string;

    public getParams(): HttpParams {
        return super.getParams().set('title', this.title);
    }
}
