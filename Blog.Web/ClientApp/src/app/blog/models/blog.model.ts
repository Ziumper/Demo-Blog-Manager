export class BlogModel {
    public blogEnitityId: number;
    public title: string;

    constructor(blogEntityId: number, title: string ) {
        this.blogEnitityId = blogEntityId;
        this.title = title;
    }
}
