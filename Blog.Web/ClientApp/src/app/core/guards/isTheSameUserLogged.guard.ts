import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from 'src/app/user/services/authentication.service';


@Injectable()
export class IsTheSameUserLoggedGuard implements CanActivate {

    constructor(private router: Router,
        private authenticationService: AuthenticationService) { }

    public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.authenticationService.isLogged()) {
            return this.isTheSameUserLogedIn(route);
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        return false;
    }

    private getUserIdFromLoggedUser(): Number {
       return this.authenticationService.getUserIdFromLocalStorage();
    }

    private isTheSameUserLogedIn(route: ActivatedRouteSnapshot): boolean {
        const userId = this.getUserIdFromLoggedUser();
        const userIdFromRoute = this.getUserFromParams(route);
        return userId === userIdFromRoute;
    }

    private getUserFromParams(route:  ActivatedRouteSnapshot): Number {
        const userId = route.paramMap.get('userId');
        const userIdNumber = Number(userId);
        return userIdNumber;
    }
}
