import { Paramsable } from 'src/app/core/models/paramsable.interface';
import { HttpParams } from '@angular/common/http';

export class CommentsQuery implements Paramsable {

    public skip: number;
    public postId: number;
    public take: number;

    public constructor(skip: number, postId: number, take: number) {
        this.postId = postId;
        this.skip = skip;
        this.take = take;
    }

    public getParams(): HttpParams {
        const params = new HttpParams()
        .set('skip', this.skip.toString())
        .set('postId', this.postId.toString())
        .set('take', this.take.toString());
        return params;
    }

}
