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

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    DashboardComponent,
    ProductDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    ConfigService,
    ConfigModule.init()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
