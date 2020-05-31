import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from "@angular/router/router";
import { Observable } from "rxjs";
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})

// This service is responsible for handling login security with cookies

export class AuthGuardService implements CanActivate {

  constructor(private router: Router, private cookieService: CookieService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> |
    Promise<boolean | UrlTree> |
    boolean |
    UrlTree {
    const token = this.cookieService.get('token');
    if (token) {
      return true;
    } else {
      this.router.navigate(['login']);
      return false;
    }
  }
}
