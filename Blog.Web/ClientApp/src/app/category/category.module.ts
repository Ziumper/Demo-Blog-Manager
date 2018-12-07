import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';
import { CategoryService } from './category.service';
import { CategoryFormComponent } from './category-form/category-form.component';
import { FormsModule } from '@angular/forms';
import { CategoryComponent } from './category.component';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PostModule } from '../post/post.module';
import { CategoriesListComponent } from './categories-list/categories-list.component';

@NgModule({
    declarations: [
        CategoriesListComponent,
        CategoryFormComponent,
        CategoryComponent
    ],
    imports: [
        CommonModule,
        CoreModule,
        FormsModule,
        RouterModule,
        NgbModule,
        PostModule
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
