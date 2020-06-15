export class LoginModel {
  userName: string;
  password: string;
}

export class LoginResponse {
  accessToken: AccessToken;
  refreshToken: string;
  success: boolean;
}

export class AccessToken {
  token: string;
  expiresIn: number;
}
