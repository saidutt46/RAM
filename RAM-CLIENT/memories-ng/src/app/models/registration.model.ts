export class RegistrationModel {
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  password: string;
}

export class RegistrationResponse {
  success: boolean;
  id: string;
  errors?: string[];
}
