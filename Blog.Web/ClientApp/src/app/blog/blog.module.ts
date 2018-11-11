import { NgModule } from '@angular/core';
import { AddBlogComponent } from './add-blog/add-blog.component';
import { BlogFormComponent } from './blog-form/blog-form.component';
import { EditBlogComponent } from './eidt-blog/edit-blog.component';
import { BlogComponent } from './blog.component';
import { BlogsManagerComponent } from './blogs-manager/blogs-manager.component';
import { CoreModule } from '../core/core.module';
import { FormsModule } from '@angular/forms';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations : [
        AddBlogComponent,
        BlogFormComponent,
        EditBlogComponent,
        BlogComponent,
        BlogsManagerComponent
    ],
    exports: [
        AddBlogComponent,
        BlogFormComponent,
        EditBlogComponent,
        BlogComponent,
        BlogsManagerComponent
    ],
    imports: [
        CommonModule,
        CoreModule,
        FormsModule,
        AngularFontAwesomeModule,
        NgbModule,
    ]
})
export class BlogMoudle {}
