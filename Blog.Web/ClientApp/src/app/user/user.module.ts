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
import { ProfileComponent } from './profile/profile.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { ProfilePreviewComponent } from './profile-preview/profile-preview.component';

@NgModule({
    declarations: [
        RegistrationComponent,
        LoginComponent,
        EditProfileComponent,
        ActivationComponent,
        ProfileComponent,
        ChangePasswordComponent,
        ProfilePreviewComponent
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
        ActivationComponent,
        ProfileComponent,
        ChangePasswordComponent,
    ],
    providers: [UserService, AuthenticationService, PasswordValidatorService],
})
export class UserModule {
}
