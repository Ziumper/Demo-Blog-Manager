import { Injectable } from '@angular/core';
import { Validators, FormControl, ValidatorFn, AbstractControl } from '@angular/forms';

@Injectable()
export class PasswordValidatorService {

    private passwordPattern: string;

    constructor() {
        this.passwordPattern = '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*(),.?":{}|<>])[a-zA-Z0-9!@#$%^&*(),.?":{}|<>]+$';
    }

    public createPasswordControl() {
        const passwordControl = new FormControl('', [
            Validators.required,
            Validators.minLength(6),
            Validators.pattern(this.passwordPattern)
        ]);
        return passwordControl;
    }

    public createRepeatedPasswordControl(passwordControl: FormControl) {
       const repeatedPasswordControl = new FormControl('',
       [
           Validators.required,
           this.repeatedValidatorFn(passwordControl)
        ]);

        return repeatedPasswordControl;
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




}
