export class BlogModel {
    public blogEntityId: number;
    public title: string;

    constructor(blogEntityId: number, title: string ) {
        this.blogEntityId = blogEntityId;
        this.title = title;
    }
}
