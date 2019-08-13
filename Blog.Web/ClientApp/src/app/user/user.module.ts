import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { ActivationComponent } from './activation/activation.component';

@NgModule({
    declarations: [
        RegistrationComponent,
        LoginComponent,
        ProfileComponent,
        ActivationComponent
    ],
    imports: [CommonModule],
    exports: [
        RegistrationComponent,
        LoginComponent,
        ProfileComponent,
        ActivationComponent
    ],
    providers: [],
})
export class UserModule {
}
