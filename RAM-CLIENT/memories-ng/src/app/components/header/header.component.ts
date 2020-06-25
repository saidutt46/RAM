import { Component, OnInit, Inject } from '@angular/core';
import { INotificationService, NOTIFICATION_SERV_TOKEN, AuthenticationService } from '@ram/services';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component';
import { RegistrationComponent } from '../registration/registration.component';
import { PostAuthenticationService } from 'app/services/post-authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(
    @Inject(NOTIFICATION_SERV_TOKEN) private notifier: INotificationService,
    private authService: AuthenticationService,
    private dialog: MatDialog,
    private postAuthService: PostAuthenticationService
  ) { }

  ngOnInit(): void {
  }

  loginUser() {
    this.dialog.open(LoginComponent, {
      width: '30%',
      panelClass: 'pop-up-dialog'
    });
  }

  registerUser() {
    this.dialog.open(RegistrationComponent, {
      width: '30%',
      panelClass: 'pop-up-dialog'
    });
  }

  logOut() {
    this.postAuthService.logOut();
  }

  isLoggedIn(): boolean {
    const token = localStorage.getItem('token');
    return token ? true : false;
  }

}
