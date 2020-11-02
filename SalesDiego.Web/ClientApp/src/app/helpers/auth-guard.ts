import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AuthenticationService } from '../services/authentication.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.authenticationService.currentUserValue;console.log("authGuard");
        console.log(state.url)
        if (currentUser) {
            return true;
        }
        
        // if (state.url == 'admin'){
        //     this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        // }
        // else{
        //     this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        // }
        this.router.navigate(['/admin/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}