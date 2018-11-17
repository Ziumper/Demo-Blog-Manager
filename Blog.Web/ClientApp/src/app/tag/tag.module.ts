import { NgModule } from '@angular/core';
import { CoreModule } from '../core/core.module';
import { CommonModule } from '@angular/common';
import { TagsListComponent } from './tags-list/tags-list.component';

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
    ]
})
export class TagModule {
}
