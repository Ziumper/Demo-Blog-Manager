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
  public userBlogId: number;
  public userId: number;

  constructor(private authenticationService: AuthenticationService,
    private router: Router) {
    this.isCollapsed = true;
    this.isLogged = false;
    this.userBlogId = 0;
    this.userId = 0;
  }

  public logout(): void {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
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
      this.handleLogin(loginStatus);
    });
  }


  /**
   * Good practice to unsubscribe if component
   * is destroyed.
   */
  public ngOnDestroy(): void {
    this.loginSubscription.unsubscribe();
  }

  private handleLogin(loginStatus: boolean): void {
    this.isLogged = loginStatus;
    if (loginStatus) {
      const user = this.authenticationService.getUserFromLocalStorage();
      if (user.blogId) {
        this.userBlogId = user.blogId;
      }

      if (user.id) {
        this.userId = user.id;
      }
    }
  }

}







