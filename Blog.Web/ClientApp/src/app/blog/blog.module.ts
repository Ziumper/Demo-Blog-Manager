import { NgModule } from '@angular/core';
import { BlogFormComponent } from './blog-form/blog-form.component';
import { BlogComponent } from './blog.component';
import { BlogsManagerComponent } from './blogs-manager/blogs-manager.component';
import { CoreModule } from '../core/core.module';
import { FormsModule } from '@angular/forms';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { BlogService } from './blog.service';
import { CategoryModule } from '../category/category.module';
import { PostModule } from '../post/post.module';
import { TagModule } from '../tag/tag.module';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations : [
        BlogFormComponent,
        BlogComponent,
        BlogsManagerComponent
    ],
    exports: [
        BlogFormComponent,
        BlogComponent,
        BlogsManagerComponent,
    ],
    imports: [
        CommonModule,
        CoreModule,
        FormsModule,
        AngularFontAwesomeModule,
        NgbModule,
        CategoryModule,
        PostModule,
        TagModule,
        RouterModule,
    ],
    providers: [
        BlogService
    ]
})
export class BlogModule {}
