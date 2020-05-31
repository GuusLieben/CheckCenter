import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {HttpResult, HttpResultBuilder} from "./HttpResult";
import {environment as env} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private api: string = env.api_url.endsWith('/') ? env.api_url.substr(0, env.api_url.length - 1) : env.api_url;

  constructor(private http: HttpClient) { }

  public sessionCheckin(user: string) {
    this.post(`${this.api}/session?user=${user}`, {}, () => {});
  }

  public sessionCheckout(user: string) {
    this.delete(`${this.api}/session?user=${user}`, () => {});
  }

  public getActiveUsers(callback: (r: any) => void) {
    this.get(`${this.api}/session`, callback);
  }

  public verifyLogin(user: string, password: string, callback: (r: any) => void) {
    this.post(`${this.api}/session/auth`, {UserEmail: user, Password: password}, callback);
  }

  private get(url: string, callback: (r: HttpResult) => void) {
    this.http.get(url).subscribe(r => AuthService.handleResponse(r, callback));
  }

  private post(url: string, body: any, callback: (r: HttpResult) => void) {
    this.http.post(url, body).subscribe(r => AuthService.handleResponse(r, callback));
  }

  private put(url: string, body: any, callback: (r: HttpResult) => void) {
    this.http.put(url, body).subscribe(r => AuthService.handleResponse(r, callback));
  }

  private delete(url: string, callback: (r: HttpResult) => void) {
    this.http.delete(url).subscribe(r => AuthService.handleResponse(r, callback));
  }

  private static handleResponse(r: any, callback: (r: HttpResult) => void) {
    const builder = new HttpResultBuilder();
    builder.setResult(r);
    callback(builder.build());
  }
}
