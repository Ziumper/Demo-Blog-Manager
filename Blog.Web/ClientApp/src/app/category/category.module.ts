import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';
import { CategoriesListComponent } from './categories-list/categories-list.component';

@NgModule({
    declarations: [CategoriesListComponent],
    imports: [ CommonModule, CoreModule ],
    exports: [CategoriesListComponent],
    providers: [],
})
export class CategoryModule {
}
