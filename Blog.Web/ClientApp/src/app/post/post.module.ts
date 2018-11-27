import { NgModule } from '@angular/core';
import { PostsListComponent } from './posts-list/posts-list.component';
import { PostComponent } from './post.component';
import { CoreModule } from '../core/core.module';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PostFormComponent } from './post-form/post-form.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PostSearchService } from './post-search.service';


@NgModule({
    declarations: [
        PostsListComponent,
        PostComponent,
        PostFormComponent,
    ],
    exports: [
        PostsListComponent,
        PostComponent,
        PostFormComponent,
    ],
    imports: [
        CoreModule,
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
