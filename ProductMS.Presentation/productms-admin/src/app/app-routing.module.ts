import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsComponent } from './components/products/products.component';
import { ProductDetailComponent } from './components/products/productdetail.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

const routes: Routes = [
	{ path : 'products', component: ProductsComponent },
	{ path : 'products/:id', component: ProductDetailComponent },
	{ path : 'dashboard', component: DashboardComponent },
	{ path : '', redirectTo: '/dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
