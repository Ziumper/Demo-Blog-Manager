import { CategoryModel } from './category.model';
import { PostModel } from 'src/app/post/models/post.model';

export class CategoryWithPostModel extends CategoryModel {
    public posts: Array<PostModel>;
}
