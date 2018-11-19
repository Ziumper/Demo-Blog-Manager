import { NgModule } from '@angular/core';
import { CoreModule } from '../core/core.module';
import { CommonModule } from '@angular/common';
import { TagsListComponent } from './tags-list/tags-list.component';
import { TagService } from './tag.service';
import { FormsModule } from '@angular/forms';
import { TagFormComponent } from './tag-form/tag-form.component';

@NgModule({
    declarations: [
        TagsListComponent,
        TagFormComponent,
    ],
    exports: [
        TagsListComponent,
        TagFormComponent
    ],

    imports: [
        CoreModule,
        CommonModule,
        FormsModule,
    ],
    providers: [
        TagService
    ]
})
export class TagModule {
}
