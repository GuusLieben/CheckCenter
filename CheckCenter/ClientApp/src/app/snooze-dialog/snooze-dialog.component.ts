import {Component, ElementRef, ViewChild} from '@angular/core';
import {DialogBase, DialogService} from '../services/dialog.service';
import {EventCudService} from "../services/event.cud.service"
import {HomeComponent} from "../home/home.component"


@Component({
  selector: 'app-snooze-dialog',
  templateUrl: './snooze-dialog.component.html',
  styleUrls: ['./snooze-dialog.component.css']
})
export class SnoozeDialogComponent extends DialogBase<IInput, IOutput> {
  public bodyText: Array<any> = [];
  private home: HomeComponent = HomeComponent.homeComponent;
  public static bulk: boolean;

  @ViewChild('timeSelect', {static: false}) timeSelect: ElementRef;

  constructor(dialogService: DialogService, private service: EventCudService) {
    super(dialogService);

  }

  setModal(data: IInput) {
    this.bodyText = data.bodyText;
  }

  public okModal() {
    const value = this.timeSelect.nativeElement.value;
    let until = Date.now();
    switch (value) {

      case '15m':
        until += (60000 * 15)
        break;

      case '1h':
        until += (60000 * 60)
        break;

      case '8h':
        until += (60000 * 60 * 8)
        break;

      case '1d':
        until += (60000 * 60 * 24)
        break;
    }

    if (SnoozeDialogComponent.bulk == true) {

      for (let i = 0; i < this.home.helper.selectedEvents.length; i++) {
        this.home.helper.setSnoozed(this.home.helper.selectedEvents[i], new Date(until).toUTCString());
      }
    } else {
      this.home.helper.setSnoozed(DialogService.eventId, new Date(until).toUTCString());
    }
    super.confirm({
      successful: true,
      extraData: "example"
    });

    /*
    this.home.helper.toggleEventSnooze(DialogService.eventId, !this.home.helper.isSnoozed(DialogService.eventId))
    */
    this.home.window.AddSuccessNotification("Snoozed succesfully");
    /*
      this.service.addFeedback(DialogService.eventId, "extradata: example", "", (r) => {
        if (r.error) {
          this.home.window.AddFailureNotification("Post failed. Errorcode "+r.error)
        }
        this.home.window.AddSuccessNotification("Posted succesfully");
      });*/
  }

  public cancel() {
    super.cancel();
  }
}

interface IInput {
  bodyText?: Array<any>;
  confirmText?: string;
}

interface IOutput {
  successful: boolean;
  extraData: string;
}
