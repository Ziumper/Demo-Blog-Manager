import { BaseQueryModel } from 'src/app/core/models/base-query.model';
import { HttpParams } from '@angular/common/http';


export class PostQueryModel extends BaseQueryModel {
    public tagsIds: Array<number>;
    public blogId: number;

    public getParams(): HttpParams {
        let params = super.getParams();

        if (this.tagsIds) {
            params = params.set('tagsIds', this.tagsIds.toString());
        }

        if (this.blogId) {
            params = params.set('blogId', this.blogId.toString());
        }
        return params;
    }

}
