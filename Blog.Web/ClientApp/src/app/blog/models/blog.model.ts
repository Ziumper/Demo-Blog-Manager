

export class BlogModel {
    public id: number;
    public title: string;
    public creationDate: Date;
    public modificationDate: Date;

    constructor
    (
        id: number,
        title: string,
        creationDate: Date,
        modificationDate: Date,

    ) {
        this.id = id;
        this.title = title;
        this.creationDate = creationDate;
        this.modificationDate = modificationDate;
    }
}
