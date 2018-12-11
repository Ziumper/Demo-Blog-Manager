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
import { PostsListManagerComponent } from './posts-manager/posts-list-manager/posts-list-manager.component';


@NgModule({
    declarations: [
        PostsListComponent,
        PostComponent,
        PostFormComponent,
        PostSearchComponent,
        PostsManagerComponent,
        PostsListManagerComponent,
    ],
    exports: [
        PostsListComponent,
        PostComponent,
        PostFormComponent,
        PostSearchComponent,
        PostsManagerComponent,
        PostsListManagerComponent
    ],
    imports: [
        FormsModule,
        CommonModule,
        NgbModule,
        RouterModule
    ],
    providers: [
        PostSearchService
    ]
})
export class PostModule {}
