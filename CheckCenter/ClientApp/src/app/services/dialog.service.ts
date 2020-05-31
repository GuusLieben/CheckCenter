import { ApplicationRef, ComponentFactoryResolver, ComponentRef, EmbeddedViewRef, Injectable, Injector, Type } from "@angular/core";
import { Subject, Subscription } from "rxjs";

@Injectable()
export class DialogService {
    private componentRef: ComponentRef<DialogBase<unknown, unknown>>;
    private id: string;
    private cancelled: boolean;
    private emitDataSubject: Subject<DialogResult<unknown>>;
    public static eventId: any;


    constructor(
        private componentFactoryResolver: ComponentFactoryResolver,
        private appRef: ApplicationRef,
        private injector: Injector
    ) { }

    /**
    * Creates a new DialogComponent.
    * @param component Class name of a DialogComponent that inherits BaseDialogComponent.
    * @param data The data to be set.
    * @param id Unique id of a dialog component.
    */

    public async createDialogComponent<TRequest, TResult>(
        component: Type<DialogBase<TRequest, TResult>>,
        data: TRequest,
        id: string,
        eventId: any
    ): Promise<DialogResult<TResult>> {
        this.emitDataSubject = new Subject<DialogResult<TResult>>();
        this.id = id;
        DialogService.eventId = eventId;
        let dialog = document.getElementById(id) as DialogElement;

        // 1. Create a component reference from the component
        this.componentRef = this.componentFactoryResolver
            .resolveComponentFactory(component)
            .create(this.injector);

        // 2. Set data into DialogComponent.
        this.componentRef.instance.dialogInit(id, data);

        // 3. Attach component to the appRef so that it's inside the ng component tree
        this.appRef.attachView(this.componentRef.hostView);

        if (!dialog) {
            // 4. Get DOM element from component
            const domElem = (this.componentRef.hostView as EmbeddedViewRef<DialogBase<TRequest, TResult>>)
                .rootNodes[0] as HTMLElement;

            // 4. Append DOM element to the body
            document.body.appendChild(domElem);
            await new Promise(resolve => setTimeout(resolve, 10));

            dialog = document.getElementById(id) as DialogElement;
            const ctx = this;
            dialog.addEventListener(
                "cm-dialog-closed",
                function () {
                    ctx.removeComponent();
                },
                false
            );
        }

        this.cancelled = true;

        dialog.open();
        dialog.removeAttribute("isClosed");

        // For reasons unknown a Subject is not directly convertible to a promise
        // ref: https://github.com/Reactive-Extensions/RxJS/issues/1088
        return new Promise<DialogResult<TResult>>((resolve, reject) => {
            let subscription: Subscription;
            subscription = this.emitDataSubject.subscribe(result => {
                subscription.unsubscribe();
                resolve(<DialogResult<TResult>>result);
            });
        });
    }

    public removeComponent() {
        const dialog = document.getElementById(this.id) as DialogElement;
        if (!dialog.getAttribute("isClosed")) {
            dialog.setAttribute("isClosed", "true");
            dialog.close();
        } else {
            if (this.cancelled) {
                this.emitData(true, null);
            }
            this.appRef.detachView(this.componentRef.hostView);
            this.componentRef.destroy();
            document.body.removeChild(dialog);
        }
    }

    public set Cancelled(cancelled: boolean) {
        this.cancelled = cancelled;
    }

    public emitData(cancelled: boolean, data: unknown) {
        const result = {
            cancelled: cancelled,
            data: data
        };

        this.emitDataSubject.next(result);
  }


}

interface DialogElement extends HTMLElement {
    close(): void;
    open(): void;
}

export interface DialogResult<T> {
    cancelled: boolean;
    data: T;
}

export abstract class DialogBase<TRequest, TResult> {

  bulk: boolean;
    private _id: string;

    constructor(protected dialogService: DialogService) { }

    public dialogInit(id: string, data: TRequest) {
        this._id = id;
        this.setModal(data);
    }

    protected abstract setModal(data: TRequest): void;

    public get id() {
        return this._id;
    }

    public cancel() {
        this.dialogService.Cancelled = true;
        this.dialogService.removeComponent();
    }

  public confirm(data: TResult) {
        this.dialogService.Cancelled = false;
        this.dialogService.removeComponent();
        this.dialogService.emitData(false, data);
    }
}
