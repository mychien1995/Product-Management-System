import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../../models/authentication/login.model';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { RegisterModel } from '../../models/authentication/register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  private model : RegisterModel;
  constructor(private _authenticationService : AuthenticationService) { }

  ngOnInit() {
  	this.model = new RegisterModel();
  }

  register(){
  	this._authenticationService.register(this.model).subscribe(data => alert(data.Message));
  }

}
