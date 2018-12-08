import { PostModel } from 'src/app/post/models/post.model';
import { PostQueryModel } from 'src/app/post/models/post-query.model';

export class PostListConfig {
    public posts: Array<PostModel>;
    public collectionSize: number;
    public page: number;
    public pageSize: number;

    protected postQueryModel: PostQueryModel;

    constructor() {
        this.posts = new Array<PostModel>();
        this.collectionSize = 0;
        this.page = 1;
        this.pageSize = 5;
        this.postQueryModel = new PostQueryModel(this.page, 5, 1, true, '', [0], 0, 0);
    }

}
