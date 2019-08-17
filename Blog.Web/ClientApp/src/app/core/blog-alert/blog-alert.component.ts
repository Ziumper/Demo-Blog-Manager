
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AlertService } from '../services/alert.service';


@Component({
    selector: 'app-blog-alert',
    templateUrl: 'blog-alert.component.html',
    styleUrls: ['blog-alert.component.scss']
})

export class BlogAlertComponent implements OnInit, OnDestroy {
    private subscription: Subscription;
    message: any;

    constructor(private alertService: AlertService) { }

    ngOnInit() {
        this.subscription = this.alertService.getMessage().subscribe(message => {
            this.message = message;
        });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    public closeAlert() {
        this.message = undefined;
    }
}
