import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from '../models/user.model';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from '../services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { AlertService } from 'src/app/core/services/alert.service';

@Component({
    selector: 'app-profile-preview',
    templateUrl: './profile-preview.component.html',
    styleUrls: ['./profile-preview.component.scss']
})
export class ProfilePreviewComponent implements OnInit {

    private closeResult: string;
    private userId;
    private loginSubscription: Subscription;

    public user: User;
    public showEditFunctions: boolean;
    public modal: NgbModalRef;

    constructor( private userSerivce: UserService,
        private activatedRoute: ActivatedRoute,
        private authenticationService: AuthenticationService,
        private modalService: NgbModal,
        private alertService: AlertService,
        private router: Router) {
            this.user = new User();
            this.userId = this.getUserIdFromParams();
            this.showEditFunctions = false;
        }

    public ngOnInit(): void {
        this.userSerivce.getById(this.userId).subscribe( (data: User) => {
                this.user = data;
                this.user.id = this.userId;
            }
        );

        this.loginSubscription = this.authenticationService.getLoginStatus()
        .subscribe(loginStatus => {
            this.handleLogin(loginStatus);
        });

        // call function to call all subscribers
        this.authenticationService.isLogged();
     }

    public handleLogin(loginStatus: boolean) {
        const user = this.authenticationService.getUserFromLocalStorage();
        this.showEditFunctions = this.isTheSameUserAsLoggedIn(user);

    }

    public getUserIdFromParams(): number {
        let userId = this.activatedRoute.snapshot.params['userId'];
        userId = Number(userId);
        return userId;
     }

     private isTheSameUserAsLoggedIn(user: any) {
        if (user.id) {
            const userId = Number(user.id);
            return this.userId === userId;
        }

        return false;
     }

 public open(content) {
    this.modal = this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  public closeModal() {
      this.modal.close();
  }

    public deleteAccount() {
        const userId = Number(this.activatedRoute.snapshot.params['userId']);
        console.log('test');
        this.userSerivce.delete(userId).subscribe(
            data => {
                this.alertService.success('Account deleted succesfully', true);
                this.authenticationService.logout();
            },
            errorData => {
                // TODO fix this to be one error
                this.alertService.error(errorData.error.message);
            });
     }
}
