import { BlogModel } from './blog.model';

export class BlogPagedModel {
    public blogs: Array<BlogModel>;
    public page: number;
    public count: number;
    public size: number;
}
