import { NgModule, ModuleWithProviders } from '@angular/core';
import { LoaderComponent } from './loader/loader.component';
import { SmallLoaderComponent } from './loader/small-loader/small-loader.component';
import { HttpService } from './http.service';
import { LoggerService } from './logger.service';
import { ToastService } from './toast.service';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { LoaderService } from './loader/loader.service';

@NgModule({
    declarations: [
        LoaderComponent,
        SmallLoaderComponent
    ],
    exports: [
        LoaderComponent,
        SmallLoaderComponent
    ],
    imports: [
        AngularFontAwesomeModule,
    ],
    providers: [
        HttpService,
        LoggerService,
        ToastService,
        LoaderService,
    ]
})
export class CoreModule {
}
