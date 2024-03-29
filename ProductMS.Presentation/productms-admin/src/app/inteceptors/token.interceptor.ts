import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { AuthenticationService } from '../services/authentication/authentication.service';
import { Observable, of } from 'rxjs';

@Injectable()

export class TokenInterceptor implements HttpInterceptor{
	constructor(private _authService : AuthenticationService){

	}

	intercept(request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>>{
		request = request.clone({
			setHeaders:{
				'Authorization' : `Bearer ${this._authService.getToken()}`
			}
		});
		return next.handle(request);
	}
}