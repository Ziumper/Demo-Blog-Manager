import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-edit-profile',
    templateUrl: './edit-profile.component.html',
    styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {

    public userForm: FormGroup;

    constructor(private formBuilder: FormBuilder,
        private userSerivce: UserService,
        private activatedRoute: ActivatedRoute) { }

    ngOnInit(): void {
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
}

