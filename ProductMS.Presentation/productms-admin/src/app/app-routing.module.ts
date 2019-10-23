import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Guard } from './inteceptors/guard.canactivate';
import { ProductsComponent } from './components/products/products.component';
import { ProductDetailComponent } from './components/products/productdetail.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ProductEditFormComponent } from './components/products/editform.component';
import { LoginComponent } from './components/authentication/login.component';
import { RegisterComponent } from './components/authentication/register.component';
import { LayoutComponent } from './components/layouts/layout.component';

const routes: Routes = [
	{ path : 'login', component: LoginComponent },
	{ path : 'register', component: RegisterComponent },
	{ 
		path : '',
		canActivate : [Guard],
		component : LayoutComponent,
		children : [
			{ path : '', component: DashboardComponent, pathMatch: 'full' },
			{ path : 'products', component: ProductsComponent },
			{ path : 'products/:id', component: ProductDetailComponent },
			{ path : 'insertProduct', component: ProductEditFormComponent },
			{ path : 'updateProduct/:id', component: ProductEditFormComponent },
			{ path : 'dashboard', component: DashboardComponent }
		]
	}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
