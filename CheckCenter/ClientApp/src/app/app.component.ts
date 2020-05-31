import {Component, OnInit, HostListener, ViewChild, ElementRef, Directive} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AuthService} from "./services/auth.service";
import {NavigationStart, Router} from "@angular/router";
import {HomeComponent} from "./home/home.component";
import {EventHelper} from "./home/home.event.helper";
import {CookieService} from 'ngx-cookie-service';
import {EventRoService} from "./services/event.ro.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']

})

export class AppComponent implements OnInit {
  @ViewChild('activeFilter', {static: false}) activeFilterElement: ElementRef;
  @ViewChild('snoozedFilter', {static: false}) snoozedFilterElement: ElementRef;
  @ViewChild('resolvedFilter', { static: false }) resolvedFilterElement: ElementRef;
  @ViewChild('toggle', { static: false }) toggle: ElementRef;

  title = 'app';
  homeComponent = HomeComponent.homeComponent;
  window: any;
  loggedInUsers: Array<any> = [];


  @ViewChild('menu', {static: false}) menu: ElementRef;
  public static sources: Array<any> = [];
  public static activeSources: Array<any> = [];
  public static sourceIds: Array<any> = [];

  constructor(private service: AuthService, private router: Router, private cookieService: CookieService, private readService: EventRoService) {
    this.window = window;
  }

  isLogin() {
    return this.router.url === '/login';
  }

  ngOnInit() {
    window.addEventListener('beforeunload',
      (event) => {
        const loggedInEmail = localStorage.getItem("loggedEmail");
        if (loggedInEmail) this.service.sessionCheckin(loggedInEmail);
      });

    setTimeout(() => {
      if (this.isLogin()) {
        let body = document.getElementsByTagName('body');
        for (let i = 0; i < body.length; i++)
          body[i].classList.remove('dark');
      }
    }, 100);

    this.collectActiveSessions();
  }

  toggleDarkmode() {
    let body = document.getElementsByTagName('body');

    for (let i = 0; i < body.length; i++) {
      body[i].classList.contains('dark') ? body[i].classList.remove('dark') : body[i].classList.add('dark');
    }
  }

  logout() {
    console.warn("logout called");
    this.cookieService.delete('token');
    console.warn("cookie deleted");
    this.toggleDarkmode();
    console.warn("toggled");
    this.router.navigateByUrl('/login');
    console.warn("redirect called");
  }

  collectActiveSessions() {
    this.service.getActiveUsers((r) => {
      if (r.result) this.loggedInUsers = r.result;
      setTimeout(() => this.collectActiveSessions(), 15000);
    })
  }

  updateSorter(input: any) {
    HomeComponent.homeComponent.helper.sortEventsBy(input);
  }

  getSessions() {
    return this.loggedInUsers;
  }

  public filter(id: string) {
    switch (id) {
      case 'active':
        if (!HomeComponent.globalFilters.includes(id)) {
          HomeComponent.globalFilters.push(id);
          this.toggleActiveFilter(true);
          this.window.AddSuccessNotification(`Filter added : ${id}`);
        } else {
          const index: number = HomeComponent.globalFilters.indexOf(id);
          if (index !== -1) {
            HomeComponent.globalFilters.splice(index, 1);
            this.toggleActiveFilter(false);
            this.window.AddSuccessNotification(`Filter removed : ${id}`);
          }
        }

        break;

      case 'snoozed':
        if (!HomeComponent.globalFilters.includes(id)) {
          HomeComponent.globalFilters.push(id);
          this.toggleSnoozeFilter(true);
          this.window.AddSuccessNotification(`Filter added : ${id}`);

        } else {
          const index: number = HomeComponent.globalFilters.indexOf(id);
          if (index !== -1) {
            HomeComponent.globalFilters.splice(index, 1);
            this.toggleSnoozeFilter(false);
            this.window.AddSuccessNotification(`Filter removed : ${id}`);
          }
        }
        break;

      case 'resolved':
        if (!HomeComponent.globalFilters.includes(id)) {
          HomeComponent.globalFilters.push(id);
          this.toggleArchiveFilter(true);
          this.window.AddSuccessNotification(`Filter added : ${id}`);
        } else {
          const index: number = HomeComponent.globalFilters.indexOf(id);
          if (index !== -1) {
            HomeComponent.globalFilters.splice(index, 1);
            this.toggleArchiveFilter(false);
            this.window.AddSuccessNotification(`Filter removed : ${id}`);
          }
        }
        break;
    }

    HomeComponent.homeComponent.helper.filterEvents(
      HomeComponent.homeComponent.helper.searchInput
    );
  }

  menuToggle(event) {
    let checkList = HomeComponent.homeComponent.container.nativeElement;
    event.srcElement.checked ?
      checkList.classList.add('blur')
      : checkList.classList.remove('blur');
  }

  closeMenu() {
    if (this.toggle.nativeElement.checked == true) {
      this.toggle.nativeElement.checked = false;
      this.menuToggle({srcElement: this.toggle.nativeElement})
    }
  }

  setFilterBoxActive(id: string) {
    if (HomeComponent.globalFilters.includes(id)) {
      switch (id) {
        case 'active':
          this.activeFilterElement.nativeElement.checked = true;
          break;

        case 'snoozed':
          this.snoozedFilterElement.nativeElement.checked = true;
          break;

        case 'resolved':
          this.resolvedFilterElement.nativeElement.checked = true;
          break;
      }
    } else {
      switch (id) {
        case 'active':
          this.activeFilterElement.nativeElement.checked = false;
          break;

        case 'snoozed':
          this.snoozedFilterElement.nativeElement.checked = false;
          break;

        case 'resolved':
          this.resolvedFilterElement.nativeElement.checked = false;
          break;
      }
    }
  }

  toggleActiveFilter(selected: any) {
    EventHelper.hideActive = !selected;
  }

  toggleSnoozeFilter(selected: any) {
    EventHelper.hideSnoozed = !selected;
  }

  toggleArchiveFilter(selected: any) {
    EventHelper.hideArchived = !selected;
    if (selected == true) {
      HomeComponent.isLoading = true;
      this.readService.getAllArchivedChecks((r) => {
        if (r.result) {
          HomeComponent.homeComponent.helper.eventsCollected(r.result);
          HomeComponent.isLoading = false;
        }
      })
    }
  }

  getSources() {
    return AppComponent.sources;
  }

  sourceFilter(id: any) {
    if (AppComponent.activeSources.includes(id)) {
      const index = AppComponent.activeSources.indexOf(id);
      AppComponent.activeSources.splice(index, 1);
    } else AppComponent.activeSources.push(id);
    HomeComponent.homeComponent.helper.filterEvents(HomeComponent.homeComponent.helper.searchInput);
  }

  getFilters() {
    return HomeComponent.homeComponent.getGlobalFilter();
  }
}
