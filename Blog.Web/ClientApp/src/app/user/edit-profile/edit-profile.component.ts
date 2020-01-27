import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';
import { AlertService } from 'src/app/core/services/alert.service';

//TODO write tests for checking validation messages and email , username validators 

@Component({
    selector: 'app-edit-profile',
    templateUrl: './edit-profile.component.html',
    styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {

    public userForm: FormGroup;
    public submitted: boolean;

    get firstName() { return this.userForm.get('firstName'); }
    get lastName() { return this.userForm.get('lastName'); }
    get email() { return this.userForm.get('email'); }
    get username() { return this.userForm.get('username'); }

    constructor(private formBuilder: FormBuilder,
        private userSerivce: UserService,
        private activatedRoute: ActivatedRoute,
        private alertService: AlertService) { }

    public ngOnInit(): void {
        this.submitted = false;
        const userId = this.activatedRoute.snapshot.params['userId'];
        this.userForm = this.formBuilder.group({
            id: [userId],
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            username: ['',
                [
                    Validators.minLength(3),
                    Validators.required
                ]
            ],
        });

        this.userSerivce.getById(userId).subscribe(data => {
            this.userForm.setValue(data);
        });
    }

    public onSubmit() {
        this.submitted = true;

         // stop here if form is invalid
         if (this.userForm.invalid) {
            return;
        }

        this.userSerivce.update(this.userForm.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Profile updated succesfully');
                },
                errorData => {
                    this.alertService.error(errorData.error.message);
                });
    }
}

