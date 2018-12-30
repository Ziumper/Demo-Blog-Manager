import { TagModel } from '../../tag/models/tag.model';
import { PostTagModel } from './post-tag.model';

export class PostModel {
    public id: number;
    public title: string;
    public creationDate: Date;
    public modificationDate: Date;
    public content: string;
    public shortDescription: string;
    public postTags: Array<PostTagModel>;
    public blogId: number;

    constructor() {
        this.postTags = new Array<PostTagModel>();
    }
}
