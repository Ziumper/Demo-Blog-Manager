import { BaseQueryModel } from 'src/app/core/models/base-query.model';
import { HttpParams } from '@angular/common/http';


export class PostQueryModel extends BaseQueryModel {
    public blogId: number;

    constructor() {
        super();
        this.blogId = 0;
    }

    public getParams(): HttpParams {
        let params = super.getParams();
        if (this.blogId) {
            params = params.set('blogId', this.blogId.toString());
        }
        return params;
    }

}
