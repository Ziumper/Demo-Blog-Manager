import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';
import { ActivationModel } from '../models/activation.model';
import { Observable } from 'rxjs';
import { ChangePassword } from '../models/changePassword.model';


@Injectable()
export class UserService {

    private apiUrl: string;
    constructor(private http: HttpClient) {
        this.apiUrl = 'api/user';
    }

    getById(id: number): Observable<User> {
        return this.http.get<User>(this.apiUrl + '/' + id);
    }

    changePassword(changePassword: ChangePassword) {
        return this.http.post(this.apiUrl + '/changePassword', changePassword);
    }

    register(user: User) {
        return this.http.post( this.apiUrl +  '/register', user);
    }

    update(user: User) {
        return this.http.put(this.apiUrl + '/' + user.id, user);
    }

    delete(id: number) {
        return this.http.delete(this.apiUrl + '/' + id);
    }

    activate(activation: ActivationModel) {
        return this.http.put(this.apiUrl + '/activation', activation);
    }
}
