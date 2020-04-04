import { NgModule } from '@angular/core';
import { BlogFormComponent } from './blog-form/blog-form.component';
import { BlogComponent } from './blog.component';
import { CoreModule } from '../core/core.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { BlogService } from './blog.service';
import { PostModule } from '../post/post.module';
import { RouterModule } from '@angular/router';
import { BlogManagerComponent } from './blog-manager/blog-manager.component';

@NgModule({
    declarations : [
        BlogFormComponent,
        BlogComponent,
        BlogManagerComponent
    ],
    exports: [
        BlogFormComponent,
        BlogComponent,
        BlogManagerComponent,
    ],
    imports: [
        CommonModule,
        CoreModule,
        FormsModule,
        ReactiveFormsModule,
        AngularFontAwesomeModule,
        NgbModule,
        PostModule,
        RouterModule,
    ],
    providers: [
        BlogService
    ]
})
export class BlogModule {}
