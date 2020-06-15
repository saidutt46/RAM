import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FlexLayoutModule} from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';
import { MaterialModule } from '../material.module';
import { AboutComponent } from 'app/components/about/about.component';
import { HeaderComponent } from 'app/components/header/header.component';
import { HomeComponent } from 'app/components/home/home.component';
import { LoginComponent } from 'app/components/login/login.component';
import { RegistrationComponent } from 'app/components/registration/registration.component';
import { AuthenticationService } from '@ram/services';



@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    FlexLayoutModule
  ],
  declarations: [
    AboutComponent,
    HomeComponent,
    HeaderComponent,
    LoginComponent,
    RegistrationComponent
  ],
  exports: [
    AboutComponent,
    HomeComponent,
    HeaderComponent,
    LoginComponent,
    RegistrationComponent
  ],
  entryComponents: [
    LoginComponent,
    RegistrationComponent
  ],
  providers: [AuthenticationService]
})
export class ShippingModule { }
