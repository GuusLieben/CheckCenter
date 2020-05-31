import { Injectable } from '@angular/core';
import {environment as env} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {HttpResult, HttpResultBuilder} from "./HttpResult";

@Injectable({
  providedIn: 'root'
})
export class EventCudService {
  private api: string = env.api_url.endsWith('/') ? env.api_url.substr(0, env.api_url.length - 1) : env.api_url;

  constructor(private http: HttpClient) { }


  // CUD methods
  public addComment(eventId: any, content: any, user: any, callback: (r: any) => void) {
    this.post(`${this.api}/checks/${eventId}/comments`, {
      UserEmail: user,
      Content: content
    }, callback);
  }

  public deleteEvent(eventId: any, content: any, callback: (r: any) => void) {
    if (content && content !== '')
      this.deleteWithBody(`${this.api}/checks/${eventId}`, content, callback);
    else this.delete(`${this.api}/checks/${eventId}`, callback);
  }

  public resolveEvent(eventId: any, content: any, callback: (r: any) => void) {
    if (content && content !== '')
      this.deleteWithBody(`${this.api}/checks/${eventId}?finished=true`, content, callback);
    else this.delete(`${this.api}/checks/${eventId}`, callback);
  }

  // Common methods
  options: any = {
    observe: 'response', headers: new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Authorization': 'authkey',
      'userid': '1'
    })
  };

  private post(url: string, body: any, callback: (r: HttpResult) => void) {
    this.http.post(url, body, this.options).subscribe(r => EventCudService.handleResponse(r, callback));
  }


  private put(url: string, body: any, callback: (r: HttpResult) => void) {
    this.http.put(url, body, this.options).subscribe(r => EventCudService.handleResponse(r, callback));
  }

  private delete(url: string, callback: (r: HttpResult) => void) {
    this.http.delete(url, this.options).subscribe(r => EventCudService.handleResponse(r, callback));
  }

  private deleteWithBody(url: string, conclusion: string, callback: (r: HttpResult) => void) {
    this.http.request('delete', url, { body: { conclusion: conclusion }}).subscribe(r => EventCudService.handleResponse(r, callback));
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

  public updateStateFor(eventId: any, stateId: any, callback: (r: any) => void) {
    this.put(`${this.api}/checks/${eventId}?userEmail=${localStorage.getItem('loggedEmail')}`, { State: { Id: stateId } }, callback);
  }

  deleteComment(commentId: any, eventId: any, callback: (r) => void) {
    this.delete(`${this.api}/checks/${eventId}/comments/${commentId}`, callback);
  }
}
