import { BaseQueryModel } from 'src/app/core/models/base-query.model';
import { HttpParams } from '@angular/common/http';


export class PostQueryModel extends BaseQueryModel {
    public tagId: Array<number>;
    public blogId: number;

    constructor(
        page: number,
        size: number,
        filter: number,
        order: boolean,
        searchQuery: string,
        tagId: Array<number>,
        blogId: number
    ) {
        super(page, size, filter, order, searchQuery);
        this.blogId = blogId;
        this.tagId = tagId;
    }

    public getParams(): HttpParams {
        return super.getParams()
        .set('tagId', this.tagId.toString())
        .set('blogId', this.blogId.toString());
    }

}
