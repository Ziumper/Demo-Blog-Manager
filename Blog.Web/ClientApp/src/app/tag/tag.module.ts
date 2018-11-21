import { NgModule } from '@angular/core';
import { CoreModule } from '../core/core.module';
import { CommonModule } from '@angular/common';
import { TagsListComponent } from './tags-list/tags-list.component';
import { TagService } from './tag.service';
import { FormsModule } from '@angular/forms';
import { TagFormComponent } from './tag-form/tag-form.component';
import { RouterModule } from '@angular/router';
import { PostModule } from '../post/post.module';
import { CategoryModule } from '../category/category.module';
import { TagComponent } from './tag.component'; 

@NgModule({
    declarations: [
        TagsListComponent,
        TagFormComponent,
        TagComponent,
    ],
    exports: [
        TagsListComponent,
        TagFormComponent,
        TagComponent
    ],

    imports: [
        CoreModule,
        CommonModule,
        FormsModule,
        RouterModule,
        PostModule,
        CategoryModule
    ],
    providers: [
        TagService
    ]
})
export class TagModule {
}
