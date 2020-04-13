import { NgModule } from '@angular/core';
import { CommentComponent } from './comment.component';
import { CommentFormComponent } from './comment-form/comment-form.component';
import { CommentService } from './comment.service';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        CommentComponent,
        CommentFormComponent
    ],
    imports: [
        FormsModule
    ],
    exports: [
        CommentFormComponent,
        CommentComponent,
    ],
    providers: [
        CommentService
    ],
})
export class CommentModule {}
