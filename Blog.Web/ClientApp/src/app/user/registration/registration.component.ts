import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { FormGroup, FormBuilder, Validators, FormControl, AbstractControl, ValidatorFn } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AlertService } from 'src/app/core/services/alert.service';
import { PasswordValidatorService } from '../services/password-validator';

/**
 * Custom validator example
 */

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
    registerForm: FormGroup;
    loading = false;
    submitted = false;

    get firstName() { return this.registerForm.get('firstName'); }
    get lastName() { return this.registerForm.get('lastName'); }
    get email() { return this.registerForm.get('email'); }
    get username() { return this.registerForm.get('username'); }
    get password() { return this.registerForm.get('password'); }
    get repeatedPassword() { return this.registerForm.get('repeatedPassword'); }

    private passwordPattern: string;

    constructor(private userService: UserService,
        private router: Router,
        private alertService: AlertService,
        private formBuilder: FormBuilder,
        private passwordValidatorSerivce: PasswordValidatorService) {
    }

    public ngOnInit(): void {
        const passwordControl = this.passwordValidatorSerivce.createPasswordControl();

        const repeatedPasswordControl = this.passwordValidatorSerivce.createRepeatedPasswordControl(passwordControl);

        this.registerForm = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            username: ['',
                [
                    Validators.minLength(3),
                    Validators.required
                ]
            ],
            password: passwordControl,
            repeatedPassword: repeatedPasswordControl
        });

    }

    public onSubmit() {
        this.submitted = true;

        // stop here if form is invalid
        if (this.registerForm.invalid) {
            return;
        }

        this.loading = true;
        this.userService.register(this.registerForm.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Registration successful, you can login now', true);
                    this.router.navigate(['/login']);
                },
                errorData => {
                    // TODO fix this to be one error
                    this.alertService.error(errorData.error.message);
                    this.loading = false;
                });
    }
}
