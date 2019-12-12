import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';

import { ActivationComponent } from './activation/activation.component';
import { UserService } from './services/user.service';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from '../core/core.module';
import { AuthenticationService } from './services/authentication.service';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { PasswordValidatorService } from './services/password-validator';

@NgModule({
    declarations: [
        RegistrationComponent,
        LoginComponent,
        EditProfileComponent,
        ActivationComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        CoreModule
    ],
    exports: [
        RegistrationComponent,
        LoginComponent,
        EditProfileComponent,
        ActivationComponent
    ],
    providers: [UserService, AuthenticationService, PasswordValidatorService],
})
export class UserModule {
}
