import { TagModel } from '../../tag/models/tag.model';

export class PostModel {
    public id: number;
    public title: string;
    public creationDate: Date;
    public modificationDate: Date;
    public content: string;
    public shortDescription: string;
    public postTags: Array<TagModel>;
    public blogId: number;
}
