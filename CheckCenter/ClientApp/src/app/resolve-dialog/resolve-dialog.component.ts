import {Component, ViewChild, ElementRef} from '@angular/core';
import {DialogBase, DialogService} from '../services/dialog.service';
import {EventCudService} from "../services/event.cud.service"
import {HomeComponent} from "../home/home.component"


@Component({
  selector: 'app-resolve-dialog',
  templateUrl: './resolve-dialog.component.html',
  styleUrls: ['./resolve-dialog.component.css']
})
export class ResolveDialogComponent extends DialogBase<IInput, IOutput> {
  public bodyText: Array<any> = [];
  public confirmText: string;
  private home: HomeComponent = HomeComponent.homeComponent;
  public static bulk: boolean;
  public static conclusionReq: boolean = false;


  @ViewChild('conclusion', {static: false}) conclusion: ElementRef;
  @ViewChild('timeSelect', {static: false}) timeSelect: ElementRef;

  constructor(dialogService: DialogService, private service: EventCudService) {
    super(dialogService);

  }

  setModal(data: IInput) {
    this.bodyText = data.bodyText;
    this.confirmText = data.confirmText;
  }

  public okModal() {
    super.confirm({
      successful: true
    });

    if (ResolveDialogComponent.bulk == true) {
      for (let i = 0; i < this.home.helper.selectedEvents.length; i++) {
        if (this.timeSelect.nativeElement.value == 'resolve') {
          this.service.resolveEvent(this.home.helper.selectedEvents[i], this.conclusion.nativeElement.value, (r) => {
            if (r.error) {
              this.home.window.AddFailureNotification("Event not resolved. Errorcode " + r.error)
            } else if (r.result) {
              this.home.helper.removeEvent(this.home.helper.selectedEvents[i]);
              this.home.window.AddSuccessNotification("Event resolved succesfully");
            }

          });

        } else if (this.timeSelect.nativeElement.value == 'remove') {
          this.service.deleteEvent(this.home.helper.selectedEvents[i], this.conclusion.nativeElement.value, (r) => {
            if (r.error) {
              this.home.window.AddFailureNotification("Event not removed. Errorcode " + r.error)
            } else if (r.result) {
              this.home.helper.removeEvent(this.home.helper.selectedEvents[i]);
              this.home.window.AddSuccessNotification("Event removed succesfully");
            }
          });
        }
      }
    } else {
      if (this.timeSelect.nativeElement.value == 'resolve') {
        this.service.resolveEvent(DialogService.eventId, this.conclusion.nativeElement.value, (r) => {
          if (r.error) {
            this.home.window.AddFailureNotification("Event not resolved. Errorcode " + r.error)
          } else {
            this.home.helper.removeEvent(DialogService.eventId);
            this.home.window.AddSuccessNotification("Event resolved succesfully");
          }
        });

      } else if (this.timeSelect.nativeElement.value == 'remove') {
        this.service.deleteEvent(DialogService.eventId, this.conclusion.nativeElement.value, (r) => {
          if (r.error) {
            this.home.window.AddFailureNotification("Event not removed. Errorcode " + r.error)
          } else {
            this.home.helper.removeEvent(DialogService.eventId);
            this.home.window.AddSuccessNotification("Event removed succesfully");
          }
        });
      }
    }
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
}
