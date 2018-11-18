import { BaseQueryModel } from '../../core/models/base-query.model';
import { HttpParams } from '@angular/common/http';

export class PostQueryModel extends BaseQueryModel {
    public title: string;
    public content: string;
    public blogId: number;

    public getParams(): HttpParams {
        let params = super.getParams();
        if (this.blogId) {
           params = params.set('blogId', this.blogId.toString());
        }
        if (this.title) {
           params = params.set('title', this.title.toString());
        }
        if (this.content) {
            params = params.set('content', this.content.toString());
        }
        return params;
    }



}
