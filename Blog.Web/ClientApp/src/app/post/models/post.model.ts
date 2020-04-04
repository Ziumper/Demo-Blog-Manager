import { TagModel } from '../../tag/models/tag.model';
import { PostTagModel } from './post-tag.model';
import { ImageModel } from 'src/app/core/models/image.model';
import { BaseModel } from 'src/app/core/models/base.model';

export class PostModel extends BaseModel {
    public title: string;
    public content: string;
    public shortDescription: string;
    public blogId: number;
}
