import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { ActivatedRoute } from '@angular/router';
import { User } from '../models/user.model';

@Component({
    selector: 'app-user-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
    constructor( private userSerivce: UserService,
        private activatedRoute: ActivatedRoute) { }

    public userId;

    public user: User;
    ngOnInit(): void {

        this.user = new User();
        this.userId = this.getActiveUserId();

        this.userSerivce.getById(this.userId).subscribe( (data: User) => {
                this.user = data;
            }
        );
     }

     getActiveUserId(): number {
        let userId = this.activatedRoute.snapshot.params['userId'];
        userId = Number(userId);
        return userId;
     }
}
