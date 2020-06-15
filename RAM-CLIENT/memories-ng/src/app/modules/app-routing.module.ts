import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from 'app/components/home/home.component';
import { RegistrationComponent } from 'app/components/registration/registration.component';
import { LoginComponent } from 'app/components/login/login.component';
import { HeaderComponent } from 'app/components/header/header.component';
import { AboutComponent } from 'app/components/about/about.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: '**', component: HomeComponent},
  {path: 'register', component: RegistrationComponent},
  {path: 'login', component: LoginComponent},
  {path: 'header', component: HeaderComponent},
  {path: 'about', component: AboutComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
