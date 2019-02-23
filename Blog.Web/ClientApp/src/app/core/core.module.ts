import { NgModule, ModuleWithProviders } from '@angular/core';
import { LoaderComponent } from './loader/loader.component';
import { SmallLoaderComponent } from './loader/small-loader/small-loader.component';
import { HttpService } from './http.service';
import { LoggerService } from './logger.service';
import { ToastService } from './toast.service';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { LoaderService } from './loader/loader.service';
import { NavigationComponent } from './navigation/navigation.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UploadFilesService } from './uploadFiles.service';
import { LocationService } from './location.service';
import { DefaultImagePipe } from './pipes/defaultImage.pipe';


@NgModule({
    declarations: [
        LoaderComponent,
        SmallLoaderComponent,
        NavigationComponent,
        DefaultImagePipe
    ],
    exports: [
        LoaderComponent,
        SmallLoaderComponent,
        NavigationComponent,
        DefaultImagePipe
    ],
    imports: [
        AngularFontAwesomeModule,
        NgbModule,
        RouterModule,
        CommonModule
    ],
    providers: [
        HttpService,
        LoggerService,
        ToastService,
        LoaderService,
        UploadFilesService,
        LocationService,
    ]
})
export class CoreModule {
}
