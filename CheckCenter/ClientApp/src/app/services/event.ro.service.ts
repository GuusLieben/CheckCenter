import { Injectable } from '@angular/core';
import {environment as env} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {HttpResult, HttpResultBuilder} from "./HttpResult";

@Injectable({
  providedIn: 'root'
})
export class EventRoService {

  private api: string = env.api_url.endsWith('/') ? env.api_url.substr(0, env.api_url.length - 1) : env.api_url;

  constructor(private http: HttpClient) { }

  public getUpdatedChecks(lastFetched: number, callback: (r: any) => void) {
    this.get(`${this.api}/checks?since=${lastFetched}`, callback);
  }

  public getActiveChecks(callback: (r: any) => void) {
    this.get(`${this.api}/checks?active=true`, callback);
  }

  public getAllChecks(callback: (r: any) => void) {
    this.get(`${this.api}/checks?active=false`, callback);
  }

  public getCheck(id: any, callback: (r: any) => void) {
    this.get(`${this.api}/checks/${id}`, callback);
  }

  public getCommentsForCheck(id: any, callback: (r: any) => void) {
    this.get(`${this.api}/checks/${id}/comments`, callback);
  }

  public getFeedbackForCheck(id: any, callback: (r: any) => void) {
    this.get(`${this.api}/checks/${id}/feedback`, callback);
  }

  public getInfoForCheck(id: any, callback: (r: any) => void) {
    this.get(`${this.api}/checks/${id}/info`, callback);
  }

  public getLogsForCheck(id: any, callback: (r: any) => void) {
    this.get(`${this.api}/checks/${id}/actionlogs`, callback);
  }

  public getSourceForCheck(id: any, callback: (r: any) => void) {
    this.get(`${this.api}/checks/${id}/source`, callback);
  }

  public getState(id: any, callback: (r: any) => void) {
    this.get(`${this.api}/states/${id}`, callback);
  }

  public getStateForCheck(id: any, callback: (r: any) => void) {
    this.get(`${this.api}/checks/${id}/state`, callback);
  }

  public getSource(id: any, callback: (r: any) => void) {
    this.get(`${this.api}/sources/${id}`, callback);
  }

  public getTypesForSource(id: any, callback: (r: any) => void) {
    this.get(`${this.api}/sources/${id}/checktypes`, callback);
  }

  getAllArchivedChecks(callback: (r) => void) {
    this.get(`${this.api}/checks?active=false`, callback);
  }

  getArchivedCheck(id: any, callback: (r) => void) {
    this.get(`${this.api}/checks/${id}?active=false`, callback);
  }

  // Common methods
  options: any = {
    observe: 'response', headers: new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Authorization': 'authkey',
      'userid': '1'
    })
  };

  private get(url: string, callback: (r: HttpResult) => void) {
      this.http.get(url, this.options).subscribe(
        data => EventRoService.handleResponse(data, callback),
        error => EventRoService.handleResponse(error, callback));
  }

  private static handleResponse(r: any, callback: (r: HttpResult) => void) {
    const builder = new HttpResultBuilder();
    if (r.status == 200) {
      builder.setResult(r.body);
    } else {
      builder.setError(r.body);
    }
    callback(builder.build());
  }
}
