import { PostModel } from './post.model';
import { CommentModel } from '../comment/models/comment.model';

export class PostWithComments extends PostModel {
    comments: Array<CommentModel>;
}
