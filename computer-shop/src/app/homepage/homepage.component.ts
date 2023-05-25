import { Component, OnInit } from '@angular/core';
import { Product } from '../models/Product.model';
import { ProductsService } from '../services/products.service';
import { ComponentsService } from '../services/components.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  appItems: any[] = Array(10).fill({});

  products: Product[] = [];


  constructor(private productService: ProductsService) {

  }

  ngOnInit(): void {
    this.productService.getSearchedProducts();
    this.productService.products.subscribe(result => {
      this.products = result;
    })
  }

  setActiveItem(product: Product) {
    this.productService.activeProduct.next([product]);
  }

}
