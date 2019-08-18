import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-edit-profile',
    templateUrl: './edit-profile.component.html',
    styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {

    userForm: FormGroup;

    get firstName() { return this.userForm.get('firstName'); }
    get lastName() { return this.userForm.get('lastName'); }
    get email() { return this.userForm.get('email'); }
    get username() { return this.userForm.get('username'); }

    constructor(private formBuilder: FormBuilder) { }

    ngOnInit(): void {
        this.userForm = this.formBuilder.group({
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
    }
}

