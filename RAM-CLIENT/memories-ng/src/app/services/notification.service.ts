import { Injectable, InjectionToken } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

export let NOTIFICATION_SERV_TOKEN = new InjectionToken('NotificationServiceImpl');

export interface INotificationService {
    openSuccessNotification(msg?: any, action?: string, config?: any): void;
    openWarningNotification(msg?: any, action?: string, config?: any): void;
    openErrorNotification(msg?: any, action?: string, config?: any): void;
    openInformationNotification(msg?: any, action?: string, config?: any): MatSnackBar;
}

@Injectable({
    providedIn: 'root'
})
export class NotificationService implements INotificationService {
    static defaultDuration = 5000;
    static errorDuration = 10000;
    theme = 'default-theme';

    constructor(public snack: MatSnackBar) { }

    // TODO - update to accept configuration to match interface.  also need to update callers.  separate PBI
    public openSuccessNotification(message: string, action?: string) {
        const snackBarConfig: MatSnackBarConfig = {
            duration: NotificationService.defaultDuration,
            panelClass: ['success-notification']
        };
        return this.snack.open(message, action, snackBarConfig);
    }

    public openErrorNotification(message: string, action?: string) {
        const snackBarConfig: MatSnackBarConfig = {
            duration: NotificationService.errorDuration,
            panelClass: ['error-notification']
        };
        return this.snack.open(message, action, snackBarConfig);
    }

    public openWarningNotification(message: string, action?: string) {
        const snackBarConfig: MatSnackBarConfig = {
            duration: NotificationService.defaultDuration,
            panelClass: ['warning-notification']
        };
        return this.snack.open(message, action, snackBarConfig);
    }

    public openInformationNotification(message: string, action?: string) {
        const snackBarConfig: MatSnackBarConfig = {
            panelClass: ['info-notification']
        };
        this.snack.open(message, action, snackBarConfig);
        return this.snack;
    }
}
