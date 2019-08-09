import { Injectable, Inject } from '@angular/core';
import { Product } from '../../models/products/product';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { APP_CONFIG } from '../../providers/config.provider';

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  BaseApiUrl : string;

  constructor(private _httpClient : HttpClient) {
  		this.BaseApiUrl = APP_CONFIG.BaseApiUrl;
   }

  getProducts() : Observable<Product[]>{
  	var url = `${this.BaseApiUrl}/products`;
  	return this._httpClient.get(url).pipe(map(data => data["Data"]));
  }

  getProduct(id : any) : Observable<Product>{
  	var url = `${this.BaseApiUrl}/products/${id}`;
  	return this._httpClient.get(url).pipe(map(data => data["Data"]));
  }

  insertProduct(product: Product) : Observable<any>{
  	var url = `${this.BaseApiUrl}/products/`;
  	return this._httpClient.post(url, product).pipe(map(data => data["Data"]));
  }

  updateProduct(product: Product) : Observable<any>{
    var url = `${this.BaseApiUrl}/products/${product.ProductId}`;
    return this._httpClient.put(url, product).pipe(map(data => data["Data"]));
  }
  
}
