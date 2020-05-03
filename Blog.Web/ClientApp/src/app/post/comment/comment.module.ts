import { NgModule } from '@angular/core';
import { CommentComponent } from './comment.component';
import { CommentFormComponent } from './comment-form/comment-form.component';
import { CommentService } from './comment.service';
import { FormsModule } from '@angular/forms';
import { CommentsListComponent } from './comments-list/comments-list.component';
import { CommonModule } from '@angular/common';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    declarations: [
        CommentComponent,
        CommentFormComponent,
        CommentsListComponent
    ],
    imports: [
        FormsModule,
        CommonModule,
        AngularFontAwesomeModule,
        NgbModule
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
