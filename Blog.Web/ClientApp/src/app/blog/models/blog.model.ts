import { CategoryModel } from 'src/app/category/models/category.model';

export class BlogModel {
    public id: number;
    public title: string;
    public creationDate: Date;
    public modificationDate: Date;
    public category: CategoryModel;
}
