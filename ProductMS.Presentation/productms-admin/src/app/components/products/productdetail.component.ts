import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ProductService } from '../../services/products/product.service';
import { Product } from '../../models/products/product';

@Component({
  selector: 'app-productdetail',
  templateUrl: './productdetail.component.html',
  styleUrls: ['./productdetail.component.css']
})
export class ProductDetailComponent implements OnInit {

  _productService : ProductService;
  _route : ActivatedRoute;
  _product : Product;

  constructor(productService : ProductService, route : ActivatedRoute) {
  	this._productService = productService;
  	this._route = route;
   }


  ngOnInit() {
  	this.getProduct();
  }

  getProduct() : void{
  	var id = this._route.snapshot.paramMap.get('id');
  	this._productService.getProduct(id).subscribe( x => this._product = x);
  }

}
