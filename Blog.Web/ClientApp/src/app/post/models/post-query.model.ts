import { BaseQueryModel } from '../../models/base-query.model';
import { HttpParams } from '@angular/common/http';

export class PostQueryModel extends BaseQueryModel {
    public title: string;
    public content: string;
    public blogId: number;

    public getParams(): HttpParams {
        return super.getParams()
        .set('title', this.title)
        .set('content', this.content)
        .set('blogId', this.blogId.toString());
    }



}
