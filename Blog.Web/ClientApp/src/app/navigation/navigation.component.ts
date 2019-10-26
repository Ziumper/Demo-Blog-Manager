import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, Observable, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { PostService } from 'src/app/post/post.service';
import { PostModel } from 'src/app/post/models/post.model';
import { AuthenticationService } from '../user/services/authentication.service';

@Component({
  selector: 'app-blog-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit, OnDestroy {

  private loginSubscription: Subscription;

  public isCollapsed: boolean;
  public isLogged: boolean;

  constructor(private authenticationService: AuthenticationService) {
    this.isCollapsed = true;
    this.isLogged = false;
  }

  /**
   * When the component is init the
   * subscribiton is holded and
   * code is executed when login status will
   * change.
   */
  public ngOnInit(): void {
    this.loginSubscription = this.authenticationService.getLoginStatus()
    .subscribe(loginStatus => {
      this.isLogged = loginStatus;
    });
  }


  /**
   * Good practice to unsubscribe if component
   * is destroyed.
   */
  public ngOnDestroy(): void {
    this.loginSubscription.unsubscribe();
  }

}







