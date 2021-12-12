import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/helpers/authentication.service';
import { User } from 'src/models/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'lobsterweb';
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
      complete: () => console.info('complete app'),
    });
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }
}
