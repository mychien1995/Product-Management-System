import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/products/product.service';
import { Product } from '../../models/products/product';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor(private _productService : ProductService) { }

  products : Product[];
  
  ngOnInit() {
  	this._productService.getProducts().subscribe(products => this.products = products);
  }

}
