import {HomeComponent} from "./home.component";
import {AppComponent} from "../app.component";
import {CheckCardComponent} from "../check-card/check-card.component";

export class EventHelper {

  static hideSnoozed: boolean = true;
  static hideActive: boolean = false;
  static hideArchived: boolean = true;

  // Unfiltered version of events, used as backend copy to filter
  private storedEvents: Array<any> = [];

  // Time in ticks the last realtime update was performed
  lastFetched: number = 0;

  // Quick-access ID storage of all stored events
  storedIds: Array<number> = [];

  // Pinned events, contains only IDs
  pinnedEvents: Array<any> = [];

  // Snoozed events, contains IDs and end-time
  snoozedEvents: Array<any> = [];

  // Empty event to prevent undefined errors on ticketCard
  emptyEvent = {
    source: {
      states: [],
      checkType: {}
    },
    state: {},
    comments: [],
    feedback: [],
    additionalInfo: [],
    actionLogs: []
  };

  defaultStates = ['Finished', 'Removed', 'Snoozed'];

  selectedEvents: Array<any> = [];

  public searchInput = '';
  public sortInput = 'priority';

    private home: HomeComponent = HomeComponent.homeComponent;

  constructor() {
    this.home.selectedEvents[0] = this.emptyEvent;
    this.home.selectedEvents[1] = this.emptyEvent;
  }

  public toggleEvent(id: any, index: number = -1) {
    if (this.home.selectedEvent.id === id && index === -1) {
      // If the selected event is the event we are selecting, close the ticket card and clear the selected event
      this.home.ticketListGroup.nativeElement.className = 'list-group check-column';
      this.home.ticketCard.nativeElement.className = 'invisible';
      this.home.selectedEvent = this.emptyEvent;

    } else {
      // If we are opening the ticket card, request all information about it
      CheckCardComponent.checkCardComponent.parent.nativeElement.scrollTo(0,0);
      this.home.readService.getCheck(id, r => {
        if (r.result) this.handleToggle(r.result, id, index);
        else {
          this.home.readService.getArchivedCheck(id, r => {
            if (r.result) this.handleToggle(r.result, id, index);
            else if (r.error) this.home.postError(r.error);
          })
        }
      })
    }
  }

  handleToggle(event: any, id: any, index: number) {
    // Display the ticket card, hide the no ticket illustration
    this.home.ticketListGroup.nativeElement.className = 'list-group col-4';
    this.home.ticketCard.nativeElement.className = 'card-container';

    // Set the extra information of the event in the stored lists
    for (let i = 0; i < this.storedEvents.length; i++) {
      if (this.storedEvents[i].id == id) {

        let permittedStateTitles = [];
        for (let i = 0; i < event.source.states.length; i++) {
          permittedStateTitles.push(event.source.states[i].title);
        }
        event.source.stateTitles = permittedStateTitles.join(', ');
        event.source.defaultStateTitles = this.defaultStates.join(', ');
        event.totalSeverity = event.eventSeverity + event.source.sourceSeverity;

        if (EventHelper.isArchived(event) == false) {
          // Cached events, filters and sorters will affect home.events
          this.storedEvents[i] = event;
          // ID-only storage for quick comparison
          this.storedIds[id] = id;
        }
        this.home.selectedEvent = event;
        if (index !== -1) this.home.selectedEvents[index] = event;
      }
    }
  }

  // Handle collected events properly, handles both realtime updates and initial collection
  public eventsCollected(newEvents: Array<any>) {
    // Plus ticks between 01/01/0001 12:00 and 01/01/1970 12:00
    this.lastFetched = ((Date.now() * 10000) + 621355968000000000);

    // Go through all new events
    for (let i = 0; i < newEvents.length; i++) {
      const newEvent = newEvents[i];

      if (!EventHelper.isArchived(newEvent)) {
        let permittedStateTitles = [];
        for (let i = 0; i < newEvent.source.states.length; i++) {
          permittedStateTitles.push(newEvent.source.states[i].title);
        }
        newEvent.source.stateTitles = permittedStateTitles.join(', ');
        newEvent.source.defaultStateTitles = this.defaultStates.join(', ');
        newEvent.totalSeverity = newEvent.eventSeverity + newEvent.source.sourceSeverity;
        if (!AppComponent.sourceIds.includes(newEvent.source.id)) {
          AppComponent.sources.push(newEvent.source);
          AppComponent.sourceIds.push(newEvent.source.id);
          AppComponent.activeSources.push(newEvent.source.id);
        }
      } else {
        newEvent.source = {};
        newEvent.source.checkType = {};
        newEvent.source.checkType.title = 'Archived';
        newEvent.source.id = -1;

        newEvent.state = {};
        newEvent.state.title = 'Archived';
      }
      // If an object is new this will remain false, on update/delete this will be true
      let updatedDupl = false;

      // Compare new events to currently stored events
      for (let j = 0; j < this.storedEvents.length; j++) {
        const storedEvent = this.storedEvents[j];

        // Compare by ID (Key), don't compare complete object due to potential updated child
        if (newEvent.id === storedEvent.id) {

          if (newEvent.removed || newEvent.finished) {
            // Removal update
            this.storedEvents.splice(j, 1)
            updatedDupl = true;
          } else {
            // Content update
            this.storedEvents[j] = newEvent;
            updatedDupl = true;
            // Also update the selected event if it is currently selected
            if (this.home.selectedEvent.id == newEvent.id) {
              this.home.selectedEvent = newEvent;
              if (this.selectedEvents.includes(newEvent.id)) {
                if (this.home.selectedEvents[0].id == newEvent.id) {
                  this.home.selectedEvents[0] = newEvent;
                } else if (this.home.selectedEvents[1].id == newEvent.id) {
                  this.home.selectedEvents[1] = newEvent;
                }
              }
            }
          }
        }
      }

      // Creation update
      if (updatedDupl === false) {
        this.storedEvents.push(newEvent);
      }
    }

    // Updates events
    this.home.events = [...this.storedEvents];
    this.filterEvents(this.searchInput);
    this.sortEventsBy(this.sortInput);

    // Schedule realtime update
    setTimeout(() => {
      // Only gets events changed after the last fetch
      this.home.readService.getUpdatedChecks(this.lastFetched, r => {
        if (r.result) {
          this.eventsCollected(r.result);
        } else {
          this.home.postError('Realtime update failed and were automatically stopped, please contact your administrator');
        }
      })
    }, 15000); // Get updates every 15s
  }

  // Filter events based on input string, filters:
  // ?priority=x, only show events with priority x
  // ?type=x, only show events with checkType x (case sensitive)
  // Else search for containing title, description or shorthand
  public filterEvents(input: any) {
    this.searchInput = input;

    if (EventHelper.hideSnoozed == true && EventHelper.hideActive == true && EventHelper.hideArchived == true) {
      this.home.events = []
    } else {
      if (input === '') {
        this.home.events = this.storedEvents;
        //this.home.events = this.home.events.filter(e => !this.isSnoozed(e.id));
      } else {
        // Equal events to a filtered variant of storedEvents (doesn't affect storedEvents)
        this.home.events = [...this.storedEvents.filter(e => {
            // Split string at spaces, will still work for titles (etc) containing parts
            const inputParts = input.split(' ');

            // Perform check for each partial input
            for (let i = 0; i < inputParts.length; i++) {

              // If the part matches any rule, this will become true
              let partMatchesRule = false;
              const inputPart = inputParts[i];

              if (EventHelper.isArchived(e)) {
                if (EventHelper.contains(e.title, inputPart)
                  || EventHelper.contains(e.description, inputPart)
                  || EventHelper.contains(e.shorthand, inputPart)) {
                  partMatchesRule = true;
                }
              } else {
                if (EventHelper.contains(e.title, inputPart)
                  || EventHelper.contains(e.description, inputPart)
                  || EventHelper.contains(e.shorthand, inputPart)
                  || EventHelper.contains(e.checkType.title, inputPart)) {
                  partMatchesRule = true;
                }
              }

              // Make sure it equals false, if directly comparing partMatchesRule this will always be true as the object is not undefined
              if (partMatchesRule === false) return false;
            }

            // If no partial returned false, all rules matched
            return true;
          }
        )];
      }

      this.home.events = [...this.home.events.filter(e => {
        const filterSnooze = (this.isSnoozed(e.id) && EventHelper.hideSnoozed);
        return !filterSnooze;
      })];

      this.home.events = [...this.home.events.filter(e => {
        const archiveSnooze = (EventHelper.isArchived(e) && EventHelper.hideArchived);
        return !archiveSnooze;
      })]

      this.home.events = [...this.home.events.filter(e => {
        const hideActive = (this.isActive(e) && EventHelper.hideActive);
        return !hideActive;
      })]

      this.home.events = [...this.home.events.filter(e => {
        const showSource = AppComponent.activeSources.includes(e.source.id) || e.source.id == -1;
        return showSource;
      })]
    }

  }

  isActive(event: any): boolean {
    return !EventHelper.isArchived(event) && !this.isSnoozed(event.id);
  }

  static isArchived(event: any): boolean {
    return (event.finished || event.removed);
  }

  private static contains(left: string, right: string): boolean {
    return (left.toLowerCase().includes(right.toLowerCase()));
  }

  // Mark an event as pinned by storing the ID, or delete it from the array
  public toggleEventPin(id, pin: boolean = false) {
    pin ?
      this.pinnedEvents[id] = true
      : delete this.pinnedEvents[id];
    localStorage.setItem('pins', JSON.stringify(this.pinnedEvents));
    this.sortEventsBy(this.sortInput);
  }

  // Check if an event is pinned
  public isPinned(id): boolean {
    return this.pinnedEvents[id] === true;
  }

  public sortEventsBy(input?: any) {
    this.sortInput = input;
    switch (input) {
      case 'priority':
        this.home.events.sort((left, right) => {
          if (left.totalSeverity < right.totalSeverity) {
            return 1;
          } else if (left.totalSeverity > right.totalSeverity) {
            return -1;
          }
          return 0;
        });
        break;

      case 'title':
        this.home.events.sort((left, right) => {
          if (left.title < right.title) {
            return -1;
          } else if (left.title > right.title) {
            return 1;
          }
          return 0;
        });
        break;
      case 'type':
        this.home.events.sort((left, right) => {
          if (left.checkType.title < right.checkType.title) {
            return -1;
          } else if (left.checkType.title > right.checkType.title) {
            return 1;
          }
          return 0;
        });
        break;
      case 'added':
        this.home.events.sort((left, right) => {
          if (Date.parse(left.added) < Date.parse(right.added)) {
            return 1;
          } else if (Date.parse(left.added) > Date.parse(right.added)) {
            return -1;
          }
          return 0;
        });
        break;
    }
    this.home.events.sort((left, right) => {
      if (this.isPinned(left.id)) {
        return -1;
      } else if (this.isPinned(right.id)) {
        return 1;
      }
      return 0;
    })
  }

  public sendFeedback(eventId: any) {

  }

  public sendComment(eventId: any, comment: any) {
    const user = localStorage.getItem('loggedEmail');
     this.home.cudService.addComment(eventId, comment, user, (r) => {
     });
  }

  public selectedEventCount(): number {
    let count = 0;
    for (let i = 0; i < this.selectedEvents.length; i++) {
      if (this.selectedEvents[i]) count++;
    }
    return count;
  }

  public selectEvent(eventId: any) {
    if (this.isSelected(eventId)) {
      // Uncheck event
      for (let i = 0; i < this.selectedEvents.length; i++) {
        if (this.selectedEvents[i] == eventId) {
          this.selectedEvents.splice(i, 1);
          if (!this.anyEventSelected() == true) {
            this.selectedEvents = [];
          }
          break;
        }
      }
    } else {
      // Check event
      this.selectedEvents.push(eventId);
      if (this.selectedEventCount() == 2) {
        this.toggleEvent(this.selectedEvents[0], 0);
        this.toggleEvent(this.selectedEvents[1], 1);
      }
    }

  }

  public anyEventSelected(): boolean {
    for (let i = 0; i < this.selectedEvents.length; i++) {
      if (this.selectedEvents[i]) return true;
    }
    return false;
  }

  public isSelected(eventId: any): boolean {
    for (let i = 0; i < this.selectedEvents.length; i++) {
      let e = this.selectedEvents[i];
      if (e === eventId) {
        return true;
      }
    }
    return false;
  }

  public pinSelected() {
    for (let i = 0; i < this.selectedEvents.length; i++) {
      // Can contain null values
      const id = this.selectedEvents[i];
      if (id) this.toggleEventPin(id, !this.isPinned(id));
    }
  }

  // Mark an event as pinned by storing the ID, or delete it from the array
  public toggleEventSnooze(id, snooze: boolean = false) {
    snooze ?
      this.snoozedEvents[id] = true
      : delete this.snoozedEvents[id];
    localStorage.setItem('snooze', JSON.stringify(this.snoozedEvents));
    this.sortEventsBy(this.sortInput);
  }

  public setSnoozed(eventId: any, until: any) {
    this.snoozedEvents[eventId] = Date.parse(until);
    this.filterEvents(this.searchInput);
    this.sortEventsBy(this.sortInput);
  }

  public isSnoozed(eventId: any): boolean {
    if (this.snoozedEvents[eventId]) {
      const snoozedUntil = this.snoozedEvents[eventId];
      if (Date.now() < snoozedUntil) {
        return Date.now() < snoozedUntil;
      } else {
        // Expired snooze
        delete this.snoozedEvents[eventId];
      }
    }
    return false;
  }

  public removeEvent(eventId: any) {
    //remove event from stored events
    for (let i = 0; i < this.storedEvents.length; i++) {
      if (this.storedEvents[i].id == eventId) {
        this.storedEvents.splice(i, 1);
        if (this.home.selectedEvent.id == eventId) {
          this.toggleEvent(eventId);
        }

        // TODO : Remove event if two selected
        if (this.home.selectedEvents[0].id == eventId || this.home.selectedEvents[1].id == eventId) {
          this.selectEvent(eventId);
        }
      }
    }
    //update events
    this.filterEvents(this.searchInput);
    this.sortEventsBy(this.sortInput);
  }

  updateState(state: any) {
    this.home.cudService.updateStateFor(this.home.selectedEvent.id, state.id, (r) => {
      if (r.result.result == true) {
        this.home.window.AddSuccessNotification('Updated state');
        this.home.selectedEvent.updated = new Date().toISOString();
        this.home.selectedEvent.state = state;
        this.home.events.forEach(e => {
          if (e.id == this.home.selectedEvent.id) {
            e.state = state;
          }
        })
      }
    })
  }
}

