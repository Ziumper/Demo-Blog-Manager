import { NgModule } from '@angular/core';
import { PostsListsComponent } from './posts-list/posts-list.component';
import { PostComponent } from './post.component';
import { CoreModule } from '../core/core.module';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PostFormComponent } from './post-form/post-form.component';
import { FormsModule } from '@angular/forms';
import { AddPostComponent } from './add-post/add-post.component';
import { EditPostComponent } from './edit-post/edit-post.component';

@NgModule({
    declarations: [
        PostsListsComponent,
        PostComponent,
        PostFormComponent,
        AddPostComponent,
        EditPostComponent
    ],
    exports: [
        PostsListsComponent,
        PostComponent,
        PostFormComponent,
        AddPostComponent,
        EditPostComponent
    ],
    imports: [
        CoreModule,
        FormsModule,
        CommonModule,
        NgbModule
    ]
})
export class PostModule {}
