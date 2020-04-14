import { BaseModel } from 'src/app/core/models/base.model';

export class PostModel extends BaseModel {
    public title: string;
    public content: string;
    public shortDescription: string;
    public blogId: number;
    public author: string;
    public blogTitle: string;
}
