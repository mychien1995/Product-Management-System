import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsComponent } from './components/products/products.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ProductDetailComponent } from './components/products/productdetail.component';
import { HttpClientModule }    from '@angular/common/http';
import { ConfigModule, ConfigService } from './services/shared/config.service';
import { APP_CONFIG, AppSetting } from './providers/config.provider';
import { ProductEditFormComponent } from './components/products/editform.component';
import { FormsModule } from "@angular/forms";
import { LoginComponent } from './components/authentication/login.component';
import { LocalStorageModule } from 'angular-2-local-storage';
import { RegisterComponent } from './components/authentication/register.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    DashboardComponent,
    ProductDetailComponent,
    ProductEditFormComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    LocalStorageModule.forRoot({
        prefix: 'my-app',
        storageType: 'localStorage'
    })
  ],
  providers: [
    ConfigService,
    ConfigModule.init()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
