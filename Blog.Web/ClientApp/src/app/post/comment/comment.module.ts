import { NgModule } from '@angular/core';
import { CommentComponent } from './comment.component';
import { CommentFormComponent } from './comment-form/comment-form.component';
import { CommentService } from './comment.service';
import { FormsModule } from '@angular/forms';
import { CommentsListComponent } from './comments-list/comments-list.component';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [
        CommentComponent,
        CommentFormComponent,
        CommentsListComponent
    ],
    imports: [
        FormsModule,
        CommonModule
    ],
    exports: [
        CommentFormComponent,
        CommentComponent,
        CommentsListComponent
    ],
    providers: [
        CommentService
    ],
})
export class CommentModule {}
