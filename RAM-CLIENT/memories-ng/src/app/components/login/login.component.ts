import { Component, OnInit, Inject } from '@angular/core';
import { NOTIFICATION_SERV_TOKEN, INotificationService, AuthenticationService } from '@ram/services';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { LoginModel } from '@ram/models';
import { PostAuthenticationService } from 'app/services/post-authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  hide = true;

  constructor(
    @Inject(NOTIFICATION_SERV_TOKEN) private notifier: INotificationService,
    private authService: AuthenticationService,
    private fb: FormBuilder,
    private dialog: MatDialog,
    private postAuthService: PostAuthenticationService
  ) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm() {
    this.loginForm = this.fb.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.min(6)]]
    });
  }

  loginUser() {
    const user = new LoginModel();
    user.userName = this.loginForm.get('userName').value;
    user.password = this.loginForm.get('password').value;
    this.authService.loginUser(user).subscribe(res => {
      this.postAuthService.setUser(res);
      this.notifier.openSuccessNotification(`Enjoy the Memories`);
    }, err => {
      this.notifier.openErrorNotification(`An error occured`);
    });
    this.dialog.closeAll();
  }

  close() {
    this.dialog.closeAll();
  }

}
