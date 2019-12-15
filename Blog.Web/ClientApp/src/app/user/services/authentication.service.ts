import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Subject, Observable } from 'rxjs';

@Injectable()
export class AuthenticationService {
    private apiUrl: string;
    private loginSubject: Subject<boolean>;
    private currentUser: string;

    constructor(private http: HttpClient) {
        this.apiUrl = 'api/user/authenticate';
        this.loginSubject = new Subject<boolean> ();
        this.currentUser = 'currentUser';
     }


     /**
      * IsLogged() method is returning boolean and
      * also is emiting a bolean value for login subscription
      * It is usefull for checking is user is loged via,
      * subscription so it is easier to share login status
      */
    isLogged(): boolean {
        if (localStorage.getItem(this.currentUser)) {
            this.loginSubject.next(true);
            return true;
        }
        this.loginSubject.next(false);
        return false;
    }

    public getUserFromLocalStorage(): any {
        const currentUser = localStorage.getItem(this.currentUser);
        if (currentUser) {
            const user = JSON.parse(currentUser);
            return user;
        }
    }

    public getUserIdFromLocalStorage(): Number {
        const currentUser = this.getUserFromLocalStorage();
        if (currentUser) {
            if (currentUser.id) {
                const userId = Number(currentUser.id);
                return userId;
            }
        }

        return 0;
    }

    /**
     * Return of observable to where we can
     * subscribe and check is user are logged,
     * it will be automatically updated when we
     * will subscribe to this observable object.
     */
    getLoginStatus(): Observable<boolean> {
        return this.loginSubject.asObservable();
    }

    login(username: string, password: string) {
        return this.http.post<any>(this.apiUrl, { username: username, password: password })
            .pipe(map(user => {
                if (user && user.token) {
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }

               this.isLogged();

                return user;
            }));
    }

    logout() {
        localStorage.removeItem('currentUser');
        this.isLogged();
    }
}
