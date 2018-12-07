import { CategoryModel } from 'src/app/category/models/category.model';

export class BlogModel {
    public id: number;
    public title: string;
    public creationDate: Date;
    public modificationDate: Date;
    public category: CategoryModel;

    constructor
    (
        id: number,
        title: string,
        creationDate: Date,
        modificationDate: Date,
        category: CategoryModel
    ) {
        this.id = id;
        this.title = title;
        this.creationDate = creationDate;
        this.modificationDate = modificationDate;
        this.category = category;
    }
}
