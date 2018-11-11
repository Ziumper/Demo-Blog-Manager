import { NgModule } from '@angular/core';
import { PostsListsComponent } from './posts-list/posts-list.component';
import { PostComponent } from './post.component';
import { CoreModule } from '../core/core.module';
import { CommonModule } from '@angular/common';

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
    ]
})
export class PostModule {}
