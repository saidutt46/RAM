import { Component, OnInit, Inject } from '@angular/core';
import { NOTIFICATION_SERV_TOKEN, INotificationService, AuthenticationService } from '@ram/services';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegistrationModel } from '@ram/models';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  registrationForm: FormGroup;
  userNameFocus: boolean;
  passwordFocus: boolean;
  hide = true;

  constructor(
    @Inject(NOTIFICATION_SERV_TOKEN) private notifier: INotificationService,
    private authService: AuthenticationService,
    private fb: FormBuilder,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm() {
    this.registrationForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', [Validators.required, Validators.min(6)]]
    });
  }

  registerUser() {
    const user = new RegistrationModel();
    user.email = this.registrationForm.get('email').value;
    user.firstName = this.registrationForm.get('firstName').value;
    user.lastName = this.registrationForm.get('lastName').value;
    user.userName = this.registrationForm.get('userName').value;
    user.password = this.registrationForm.get('password').value;

    this.authService.registerUser(user).subscribe(res => {
      console.warn(res);
      if (res.success) {
        this.notifier.openSuccessNotification(`Successfully created user ${user.userName}`);
      }
    }, (err: Error) => {
      this.notifier.openErrorNotification(`Error occured`);
    });
    this.dialog.closeAll();
  }

  close() {
    this.dialog.closeAll();
  }

}
