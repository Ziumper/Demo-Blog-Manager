import { NgModule } from '@angular/core';
import { CoreModule } from '../core/core.module';
import { CommonModule } from '@angular/common';
import { TagService } from './tag.service';
import { FormsModule } from '@angular/forms';
import { TagFormComponent } from './tag-form/tag-form.component';
import { RouterModule } from '@angular/router';
import { PostModule } from '../post/post.module';
import { CategoryModule } from '../category/category.module';
import { TagComponent } from './tag.component';
import { TagsListComponent } from './tags-list/tags-list.component';
import { TagPostsListComponent } from './tag-posts-list/tag-posts-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    declarations: [
        TagsListComponent,
        TagFormComponent,
        TagComponent,
        TagPostsListComponent,
    ],
    exports: [
        TagsListComponent,
        TagFormComponent,
        TagComponent,
        TagPostsListComponent
    ],

    imports: [
        CoreModule,
        CommonModule,
        FormsModule,
        RouterModule,
        NgbModule,
    ],
    providers: [
        TagService
    ]
})
export class TagModule {
}
