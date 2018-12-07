import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';
import { CategoryService } from './category.service';
import { CategoryFormComponent } from './category-form/category-form.component';
import { FormsModule } from '@angular/forms';
import { CategoryComponent } from './category.component';

@NgModule({
    declarations: [
        CategoryFormComponent,
        CategoryComponent
    ],
    imports: [
        CommonModule,
        CoreModule,
        FormsModule
    ],
    exports: [
        CategoryFormComponent,
        CategoryComponent
    ],
    providers: [CategoryService],
})
export class CategoryModule {
}
