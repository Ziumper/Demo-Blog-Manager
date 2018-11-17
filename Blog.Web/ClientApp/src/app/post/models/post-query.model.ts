import { BaseQueryModel } from '../../core/models/base-query.model';
import { HttpParams } from '@angular/common/http';

export class PostQueryModel extends BaseQueryModel {
    public title: string;
    public content: string;
    public blogId: number;

    public getParams(): HttpParams {
        const params = super.getParams();
        if (this.blogId) {
            params.set('blogId', this.blogId.toString());
        }
        if (this.title) {
           params.set('title', this.title.toString());
        }
        if (this.content) {
            params.set('content', this.content.toString());
        }
        return params;
    }



}
