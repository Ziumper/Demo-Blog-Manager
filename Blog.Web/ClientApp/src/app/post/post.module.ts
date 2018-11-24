import { NgModule } from '@angular/core';
import { PostsListComponent } from './posts-list/posts-list.component';
import { PostComponent } from './post.component';
import { CoreModule } from '../core/core.module';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PostFormComponent } from './post-form/post-form.component';
import { FormsModule } from '@angular/forms';
import { CommentComponent } from './comment/comment.component';
import { CommentsListComponent } from './comments-list/comments-list.component';

@NgModule({
    declarations: [
        PostsListComponent,
        PostComponent,
        PostFormComponent,
        CommentComponent,
        CommentsListComponent
    ],
    exports: [
        PostsListComponent,
        PostComponent,
        PostFormComponent,
        CommentComponent,
        CommentsListComponent
    ],
    imports: [
        CoreModule,
        FormsModule,
        CommonModule,
        NgbModule
    ]
})
export class PostModule {}
