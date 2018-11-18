import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { CategoryService } from './category.service';

@NgModule({
    declarations: [CategoriesListComponent],
    imports: [ CommonModule, CoreModule ],
    exports: [CategoriesListComponent],
    providers: [CategoryService],
})
export class CategoryModule {
}
