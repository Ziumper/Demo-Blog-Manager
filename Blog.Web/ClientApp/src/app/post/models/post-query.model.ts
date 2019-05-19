import { BaseQueryModel } from 'src/app/core/models/base-query.model';
import { HttpParams } from '@angular/common/http';


export class PostQueryModel extends BaseQueryModel {
    public tagsIds: Array<number>;
    public blogId: number;

    public getParams(): HttpParams {
        return super.getParams()
        .set('tagsIds', this.tagsIds.toString())
        .set('blogId', this.blogId.toString());
    }

}
