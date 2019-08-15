import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { ActivationComponent } from './activation/activation.component';
import { UserService } from './user.service';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from '../core/core.module';

@NgModule({
    declarations: [
        RegistrationComponent,
        LoginComponent,
        ProfileComponent,
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
        ProfileComponent,
        ActivationComponent
    ],
    providers: [UserService],
})
export class UserModule {
}
