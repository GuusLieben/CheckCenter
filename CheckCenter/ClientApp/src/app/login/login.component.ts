import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {Router} from "@angular/router";
import {AppComponent} from "../app.component";
import { AuthService } from "../services/auth.service";
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @ViewChild('email', { static: false }) email: ElementRef;
  @ViewChild('password', { static: false }) password: ElementRef;

  private window: any;

  constructor(private service: AuthService, private router: Router, private app: AppComponent, private cookieService: CookieService) {
    this.window = window;
  }

  loginInvalid: boolean = false;
  getLoading: boolean = false;

  ngOnInit() {

  }

  login() {
    this.getLoading = true;
    const email = this.email.nativeElement.value;
    const password = this.password.nativeElement.value;
    this.service.verifyLogin(email, password, (r) => {
      if (r.result == null) {
        this.loginInvalid = true;
        this.getLoading = false; 
        }
      else {
        this.cookieService.set('token', r.result.token);
        this.app.toggleDarkmode();
        this.service.sessionCheckin(email);
        localStorage.setItem("loggedEmail", email);
        this.router.navigateByUrl('/home');
        this.getLoading = false; 
        return;
      }
    });
  }
}
