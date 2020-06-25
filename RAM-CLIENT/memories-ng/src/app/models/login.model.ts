export class LoginModel {
  userName: string;
  password: string;
}

export class LoginResponse {
  accessToken: AccessToken;
  refreshToken: string;
  success: boolean;
  errors?: string[];
}

export class AccessToken {
  token: string;
  expiresIn: number;
}
