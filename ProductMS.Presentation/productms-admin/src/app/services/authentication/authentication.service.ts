import { Injectable } from '@angular/core';
import { LoginModel } from '../../models/authentication/login.model';
import { MessageModel } from '../../models/shared/message.model';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { APP_CONFIG } from '../../providers/config.provider';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { LocalStorageService } from 'angular-2-local-storage';
import { RegisterModel } from '../../models/authentication/register.model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private BaseApiUrl : string;
  private TokenStorageKey : string;

  constructor(private _httpClient : HttpClient, private _localStorageService : LocalStorageService) { 
  	this.TokenStorageKey = 'app-token';
  }

  login(user : LoginModel) : Observable<MessageModel>{
  	var url = `${APP_CONFIG.BaseApiUrl}/authentication/token`;
  	var requestOptions : Object = {
	    responseType: 'text'
	};
  	return this._httpClient.post<string>(url, user, requestOptions)
  	.pipe(
  		map(data => { return this.loginSuccess(data)}),
  		catchError(error => { return this.loginError(error) })
  	 );
  }

  register(user : RegisterModel) : Observable<MessageModel>{
  	var url = `${this.BaseApiUrl}/authentication/register`;
  	var requestOptions : Object = {
	    responseType: 'text'
	};
  	return this._httpClient.post(url, user, requestOptions)
  	.pipe(
		map(data => { return this.registerSuccess(data); }),
  		catchError(error => { return of(new MessageModel(error.error, false)); })
  	 );
  }

  getToken() : string{
  	return this._localStorageService.get(this.TokenStorageKey);
  }

  private loginError(error: HttpErrorResponse) {
	  console.log(
	      `Backend returned code ${error.status}, ` +
	      `body was: ${error.error}`);
	  var message = "Username or password incorrect";
	  var isSuccess = false;
	  var result : MessageModel = {
	  	Message : message,
	  	IsSuccess : isSuccess
	  };
	  return of(result);
  };

  private loginSuccess(data: Object) {
	  this._localStorageService.set(this.TokenStorageKey, data);
	  var result : MessageModel = {
	  	Message : "Login successfully",
	  	IsSuccess : true
	  };
	  return result;
  };

  private registerSuccess(data: Object) {
	  this._localStorageService.set(this.TokenStorageKey, data);
	  var result : MessageModel = {
	  	Message : "Register successfully",
	  	IsSuccess : true
	  };
	  return result;
  };



}
