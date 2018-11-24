import { NgModule } from '@angular/core';
import { CommentComponent } from './comment.component';
import { CommentsListComponent } from './comments-list/comments-list.component';

@NgModule({
    declarations: [
        CommentComponent,
        CommentsListComponent
    ],
    imports: [],
    exports: [
        CommentComponent,
        CommentsListComponent
    ],
    providers: [],
})
export class CommentModule {}
