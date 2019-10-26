import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { FormGroup, FormBuilder, Validators, FormControl, AbstractControl, ValidatorFn } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AlertService } from 'src/app/core/services/alert.service';

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
        private formBuilder: FormBuilder) {
        this.passwordPattern = '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*(),.?":{}|<>])[a-zA-Z0-9!@#$%^&*(),.?":{}|<>]+$';
    }

    public ngOnInit(): void {
        const passwordControl = new FormControl('', [
            Validators.required,
            Validators.minLength(6),
            Validators.pattern(this.passwordPattern)
        ]);

        const repeatedPasswordControl = new FormControl('', [Validators.required, this.repeatedValidatorFn(passwordControl)]);

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

    /**
      * It is custom validator for checking password repeating
      * @param control FormControl
    */
    private repeatedValidatorFn(control: FormControl): ValidatorFn {
        return (c: AbstractControl): { [key: string]: boolean } | null => {
            const originalPassword = control.value;
            const isNotSame = c.value !== originalPassword;

            if (isNotSame) {
                return { 'repeated': true };
            }

            return null;
        };
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
