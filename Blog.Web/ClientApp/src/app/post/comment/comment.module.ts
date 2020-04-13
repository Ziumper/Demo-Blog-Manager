import { NgModule } from '@angular/core';
import { CommentComponent } from './comment.component';
import { CommentFormComponent } from './comment-form/comment-form.component';

@NgModule({
    declarations: [
        CommentComponent,
        CommentFormComponent
    ],
    imports: [],
    exports: [
        CommentFormComponent,
        CommentComponent,
    ],
    providers: [],
})
export class CommentModule {}
