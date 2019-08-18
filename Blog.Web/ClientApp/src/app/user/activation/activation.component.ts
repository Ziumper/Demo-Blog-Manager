import { Component, OnInit } from '@angular/core';
import { ActivationModel } from '../models/activation.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../services/user.service';
import { AlertService } from 'src/app/core/services/alert.service';

@Component({
    selector: 'app-activation',
    templateUrl: './activation.component.html',
    styleUrls: ['./activation.component.scss']
})
export class ActivationComponent implements OnInit {
    private activationModel: ActivationModel;
    private userId: number;
    private acitviationCode: string;

    constructor(private formBuilder: FormBuilder,
        private router: Router,
        private userService: UserService,
        private alertService: AlertService,
        private activatedRoute: ActivatedRoute) {
        this.userId = 0;
        this.activationModel = new ActivationModel();
    }


    ngOnInit(): void {
        this.userId = this.activatedRoute.snapshot.params['userId'];
        this.acitviationCode = this.activatedRoute.snapshot.params['code'];
        this.activateAccount();
    }


    private activateAccount() {
        this.activationModel.code = this.acitviationCode;
        this.activationModel.id = this.userId;
        this.userService.activate(this.activationModel)
            .subscribe(
                data => {
                    this.alertService.success('Your account is active, you can login', true);
                    this.router.navigate(['/login']);
                },
                error => {
                    this.alertService.error(error.error.message);
                });
    }
}
