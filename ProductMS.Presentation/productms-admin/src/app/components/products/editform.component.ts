import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/products/product.service';
import { Product } from '../../models/products/product';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-editform',
  templateUrl: './editform.component.html',
  styleUrls: ['./editform.component.css']
})
export class ProductEditFormComponent implements OnInit {

  private isEdit : boolean;
  private formTitle : string;
  private model : Product;
  private id : any;	

  constructor(private _productService : ProductService, private _route : ActivatedRoute, private _router : Router) {
  		this.id = _route.snapshot.paramMap.get('id');
  		this.isEdit = this.id != null;
  		if(this.isEdit){
  			_productService.getProduct(this.id).subscribe(data => {
  				this.model = data;
  			});
  		}
  		else{
  			this.model = new Product();
  		}
  		this.formTitle = this.isEdit ? 'Edit Product' : 'Add Product';
   }

  ngOnInit() {

  }

  save(){
  	if(this.isEdit) this.model.ProductId = this.id;
  	else this.model.ProductId = 0;
  	var observable = this.isEdit ? this._productService.updateProduct(this.model) : this._productService.insertProduct(this.model);
  	observable.subscribe(data => {
  		this._router.navigate(['/products']);
  	});
  }

}
