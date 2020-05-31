import {Component, OnInit, ElementRef, ViewChild, Input} from '@angular/core';
import {HomeComponent} from "../home/home.component";
import {EventCudService} from "../services/event.cud.service";
import {environment as env} from "../../environments/environment";

@Component({
  selector: 'app-check-card',
  templateUrl: './check-card.component.html',
  styleUrls: ['../home/home.component.css']
})
export class CheckCardComponent implements OnInit {

  private wiki: string = env.wiki_url.endsWith('/') ? env.wiki_url.substr(0, env.wiki_url.length - 1) : env.wiki_url;

  public static checkCardComponent: CheckCardComponent;

  @ViewChild('parent', {static: false}) parent: ElementRef;
  @ViewChild('CommentForm', {static: false}) commentInput: ElementRef;
  @ViewChild('CommentBubble', {static: false}) commentBubble: ElementRef;

  local = {
    commentMessage: ''
  };

  constructor() {
    CheckCardComponent.checkCardComponent = this;
  }

  @Input()
  selectedEvent: any;

  home = HomeComponent.homeComponent;
  helper = this.home.helper;
  public cudService: EventCudService;

  diff(input: any) {
    return this.home.diff(input);
  }

  sendComment(eventId: any) {
    const comment = this.commentInput.nativeElement.value;
    this.commentInput.nativeElement.value = '';
    this.home.helper.sendComment(eventId, comment);
    this.selectedEvent.comments.push({
      userEmail: localStorage.getItem('loggedEmail'),
      content: comment,
      created: new Date().toISOString()
    });
  }

  toDateString(input: any) {
    return new Date(input).toUTCString();
  }

  ngOnInit() {
  }

  deleteComment(id: any) {
    this.home.cudService.deleteComment(id, this.selectedEvent.id, (r) => {

    });
    for (let i=0; i<this.selectedEvent.comments.length; i++) {
      if (this.selectedEvent.comments[i].id == id) {
        this.selectedEvent.comments.splice(i, 1);
      }
    }
  }
}
