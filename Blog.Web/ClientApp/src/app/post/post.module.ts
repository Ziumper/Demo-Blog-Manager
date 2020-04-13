import { NgModule } from '@angular/core';
import { PostComponent } from './post.component';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PostFormComponent } from './post-form/post-form.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PostSearchService } from './post-search/post-search.service';
import { PostSearchComponent } from './post-search/post-search.component';
import { PostsListComponent } from './posts-list/posts-list.component';
import { PostsManagerComponent } from './posts-manager/posts-manager.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgxEditorModule } from 'ngx-editor';
import { CoreModule } from '../core/core.module';
import { CommentModule } from './comment/comment.module';



@NgModule({
    declarations: [
        PostsListComponent,
        PostComponent,
        PostFormComponent,
        PostSearchComponent,
        PostsManagerComponent,
    ],
    exports: [
        PostsListComponent,
        PostComponent,
        PostFormComponent,
        PostSearchComponent,
        PostsManagerComponent,
    ],
    imports: [
        FormsModule,
        CommentModule,
        CommonModule,
        NgbModule,
        RouterModule,
        AngularFontAwesomeModule,
        NgxEditorModule,
        CoreModule
    ],
    providers: [
        PostSearchService
    ]
})
export class PostModule {}
