import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShippingModule } from './modules';
import { AppRoutingModule } from './modules/app-routing.module';
import { NotificationService, NOTIFICATION_SERV_TOKEN } from './services';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ShippingModule,
    AppRoutingModule
  ],
  providers: [
    { provide: NOTIFICATION_SERV_TOKEN, useClass: NotificationService },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
