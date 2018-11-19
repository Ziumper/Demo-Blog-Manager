import { NgModule } from '@angular/core';
import { CoreModule } from '../core/core.module';
import { CommonModule } from '@angular/common';
import { TagsListComponent } from './tags-list/tags-list.component';
import { TagService } from './tag.service';

@NgModule({
    declarations: [
        TagsListComponent
    ],
    exports: [
        TagsListComponent
    ],

    imports: [
        CoreModule,
        CommonModule,
    ],
    providers: [
        TagService
    ]
})
export class TagModule {
}
