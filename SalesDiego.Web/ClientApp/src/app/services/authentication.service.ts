import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LoggedInModel } from '../models/logged-in.model';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';

@Injectable()
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<LoggedInModel>;
    public currentUser: Observable<LoggedInModel>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<LoggedInModel>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): LoggedInModel {
        return this.currentUserSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<any>(`${environment.ApiUrl}/user/login`, { username, password })
            .pipe(map(user => {
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    logout() {
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}