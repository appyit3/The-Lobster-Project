import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/helpers/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  title = 'login';
  username: string;
  password: any;
  loading = false;
  submitted = false;
  error = '';

  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) {
    if (this.authService.currentUserValue) {
      this.router.navigate(['story']);
    }
  }

  ngOnInit() {
  }

  submitLogin() {
    this.submitted = true;

    this.loading = true;

    this.authService.login(this.username, this.password).subscribe({
      next: (result) => {
        console.log(result);
        this.router.navigate(['story']);
        
      },
      error: (err) => console.error(err),
      complete: () => console.info('complete'),
    });
  }
}
