import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, CanLoad } from '@angular/router';
import { AuthenticationService } from 'src/helpers/authentication.service';
import { User } from 'src/models/user.model';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate, CanLoad {
    currentUser: User;
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) { 
        this.authenticationService.currentUser.subscribe({
            next: (result) => {
              this.currentUser = result;
            },
            error: (err) => console.error(err),
            complete: () => console.info('complete auth'),
          });
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.canDoSomething();
    }

    canLoad() {
        return this.canDoSomething();
    }

    canDoSomething() {
        //const currentUser = this.authenticationService.currentUserValue;
        if (this.currentUser && this.currentUser.Id !== 0) {
            // logged in so return true
            return true;
        }

        // not logged in so redirect to login page
        this.router.navigate(['login']);
        return false;
    }
}