import { Tag } from '../../tag/models/tag.model';

export class PostModel {
    public id: number;
    public title: string;
    public creationDate: Date;
    public modificationDate: Date;
    public content: string;
    public postTags: Array<Tag>;
}
