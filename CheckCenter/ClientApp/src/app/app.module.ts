import {NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {HomeComponent} from './home/home.component';
import {AppComponent} from './app.component';
import {ResolveDialogComponent} from './resolve-dialog/resolve-dialog.component';
import {DialogService} from './services/dialog.service';
import {LoginComponent} from './login/login.component';
import {CookieService} from 'ngx-cookie-service';
import { ClipboardModule } from 'ngx-clipboard';
import { CheckCardComponent } from './check-card/check-card.component';
import {SnoozeDialogComponent} from './snooze-dialog/snooze-dialog.component';
import { AuthGuardService } from './auth-guard.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ResolveDialogComponent,
    SnoozeDialogComponent,
    LoginComponent,
    CheckCardComponent
  ],
  providers: [
    DialogService,
    CookieService
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    ClipboardModule,
    RouterModule.forRoot([
      {path: 'home', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuardService]},
      {path: 'login', component: LoginComponent, pathMatch: 'full'},
      {path: '', redirectTo: '/login', pathMatch: 'full'}
    ])
  ],
  entryComponents: [
    ResolveDialogComponent,
    SnoozeDialogComponent
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
}
