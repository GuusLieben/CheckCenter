import {Component, OnInit, ElementRef, ViewChild} from '@angular/core';
import {EventRoService} from '../services/event.ro.service';
import {EventCudService} from '../services/event.cud.service';
import {DialogService} from '../services/dialog.service';
import {ResolveDialogComponent} from '../resolve-dialog/resolve-dialog.component';
import * as hdate from 'human-date';
import {EventHelper} from './home.event.helper';
import {AppComponent} from '../app.component';
import {SnoozeDialogComponent} from "../snooze-dialog/snooze-dialog.component";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public static homeComponent: HomeComponent;
  public static isLoading: boolean;

  @ViewChild('container', {static: false}) container: ElementRef;

  // Global cards
  @ViewChild('ticketList', {static: false}) ticketListGroup: ElementRef;
  @ViewChild('ticketCard', {static: false}) ticketCard: ElementRef;

  // Ticket card specific content
  @ViewChild('CommentForm', {static: false}) commentInput: ElementRef;
  @ViewChild('FeedbackForm', {static: false}) feedbackInput: ElementRef;
  @ViewChild('CommentBubble', {static: false}) commentBubble: ElementRef;

  public helper: EventHelper;

  local = {
    commentMessage: ''
  };

  events: Array<any> = [];
  selectedEvent: any;
  selectedEvents: Array<any> = [];

  static globalFilters = ['active'];
  window: any;

  constructor(
    public cudService: EventCudService,
    public readService: EventRoService,
    public dialog: DialogService,
    private appComponent: AppComponent) {
    HomeComponent.homeComponent = this;
    this.helper = new EventHelper();
    this.window = window;
    this.selectedEvent = this.helper.emptyEvent;
  }

  ngOnInit(): void {
    // Sample pin
    const pinnedEvents = JSON.parse(localStorage.getItem('pins'));
    if (pinnedEvents) this.helper.pinnedEvents = pinnedEvents;

    this.helper.setSnoozed(6, '17 Jan 2020 17:15:00 UTC');

    // Fetch all active checks
    this.readService.getActiveChecks(r => {
      if (r.error) {
        // Check for errors and post if any
        this.postError(`Could not retrieve active checks : ${r.error}`);
      } else if (r.result) {
        // Handle collected events
        this.helper.eventsCollected(r.result);
      } else {
        // Either an invalid response or empty datasets
        this.postError('An unknown error occurred');
      }
    });
  }

  public openDialog(bulk: boolean = false) {

    ResolveDialogComponent.bulk = bulk;
    // Note, createDialogComponent returns promise, relevant?
    // Required : this.selectedEvent.source.logActionMandatory
    this.dialog.createDialogComponent(ResolveDialogComponent, {
      confirmText: 'Post',
      bodyText: []
    }, 'resolve', this.selectedEvent.id);
    ResolveDialogComponent.conclusionReq = this.selectedEvent.source.logActionMandatory;
  }

  public openSnooze(bulk: boolean = false) {
    // Note, createDialogComponent returns promise, relevant?
    SnoozeDialogComponent.bulk = bulk;
    this.dialog.createDialogComponent(SnoozeDialogComponent, {
      confirmText: 'Snooze',
      bodyText: []
    }, 'snooze', this.selectedEvent.id);
  }

  // Post an error message
  public postError(message: string) {
    // Include a timestamp for administrative usage
    const currentTicks = ((Date.now() * 10000) + 621356004000000000).toString();
    const stamp = 'ERR' + currentTicks.substring(3, 8);
    const errorMessage = `${message} (${stamp})`;
    this.window.AddErrorNotification(errorMessage);
  }

  public removeGlobalFilter(id: string) {
    if (HomeComponent.globalFilters.includes(id)) {
      const index: number = HomeComponent.globalFilters.indexOf(id);
      if (index !== -1) {
        this.appComponent.setFilterBoxActive(id);
        this.appComponent.filter(id);
      }
    }
  }

  // Convert a date string to relative time from now (e.g. 2 hours ago)
  public diff(date: string) {
    while (Date.parse(date) > Date.now()) {
      const currentDate = new Date(date);
      currentDate.setHours(currentDate.getHours() - 1);
      date = currentDate.toISOString();
    }
    let difference = hdate.relativeTime(date);
    if (difference.startsWith(' ago')) difference = 'just now';

    return difference;
  }

  public formatDate(date: number) {
    const tempDate = new Date(date);
    return tempDate.toDateString() + ' ' + tempDate.toTimeString();
  }

  public selectedEventCount(): number {
    let count = 0;
    for (let i = 0; i < this.selectedEvents.length; i++) {
      if (this.selectedEvents[i]) count++;
    }
    return count;
  }

  public getGlobalFilter() {
    return HomeComponent.globalFilters;
  }

  public capitalize(input: string) {
    return input.substring(0, 1).toUpperCase() + input.substring(1).toLowerCase();
  }

  public archived(event): boolean {
    return EventHelper.isArchived(event);
  }

  getLoading() {
    return HomeComponent.isLoading;
  }
}
