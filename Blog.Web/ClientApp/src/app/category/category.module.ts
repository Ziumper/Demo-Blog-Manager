import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { CategoryService } from './category.service';
import { CategoryFormComponent } from './category-form/category-form.component';
import { FormsModule } from '@angular/forms';
import { CategoryComponent } from './category.component';

@NgModule({
    declarations: [
        CategoriesListComponent,
        CategoryFormComponent,
        CategoryComponent
    ],
    imports: [
        CommonModule,
        CoreModule,
        FormsModule
    ],
    exports: [
        CategoriesListComponent,
        CategoryFormComponent,
        CategoryComponent
    ],
    providers: [CategoryService],
})
export class CategoryModule {
}
