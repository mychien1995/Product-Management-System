import { Injectable } from '@angular/core';
import { Product } from '../../models/products/product';

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  constructor() { }

  getProducts(){
  	var products : Product[] = [
  		{ ProductId : 1, ProductName : 'a'}
  	];
  	return products;
  }

}
