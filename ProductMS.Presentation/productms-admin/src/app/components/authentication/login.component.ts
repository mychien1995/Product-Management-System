import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../../models/authentication/login.model';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private model : LoginModel;

  constructor(private _authenticationService : AuthenticationService, private _router : Router) { }

  ngOnInit() {
  	this.model = new LoginModel();
  }

  login(){
  	this._authenticationService.login(this.model).subscribe(data => { 
  		alert(data.Message);
  		if(data.IsSuccess){
  			this._router.navigate(['/products']);
  		}
  	});
  }

}

