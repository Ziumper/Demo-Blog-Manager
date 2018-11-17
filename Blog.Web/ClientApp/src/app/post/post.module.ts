import { NgModule } from '@angular/core';
import { PostsListsComponent } from './posts-list/posts-list.component';
import { PostComponent } from './post.component';
import { CoreModule } from '../core/core.module';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    declarations: [
        PostsListsComponent,
        PostComponent
    ],
    exports: [
        PostsListsComponent,
        PostComponent
    ],
    imports: [
        CoreModule,
        CommonModule,
        NgbModule
    ]
})
export class PostModule {}
