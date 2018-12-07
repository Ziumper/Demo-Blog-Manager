import { BaseQueryModel } from 'src/app/core/models/base-query.model';
import { HttpParams } from '@angular/common/http';


export class PostQueryModel extends BaseQueryModel {
    public tagsIds: Array<number>;
    public blogId: number;
    public categoryId: number;

    constructor(
        page: number,
        size: number,
        filter: number,
        order: boolean,
        searchQuery: string,
        tagsId: Array<number>,
        blogId: number,
        categoryId: number,
    ) {
        super(page, size, filter, order, searchQuery);
        this.blogId = blogId;
        this.tagsIds = tagsId;
        this.categoryId = categoryId;
    }

    public getParams(): HttpParams {
        return super.getParams()
        .set('tagsIds', this.tagsIds.toString())
        .set('blogId', this.blogId.toString())
        .set('categoryId', this.categoryId.toString());
    }

}
