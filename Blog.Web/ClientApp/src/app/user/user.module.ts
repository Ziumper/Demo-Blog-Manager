import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';

@NgModule({
    declarations: [RegistrationComponent,
    LoginComponent],
    imports: [ CommonModule ],
    exports: [ RegistrationComponent,
    LoginComponent],
    providers: [],
})
export class UserModule {
}
