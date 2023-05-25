import { Component, OnInit } from '@angular/core';
import { Product } from '../models/Product.model';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css']
})
export class SearchResultsComponent implements OnInit {

  appItems: any[] = Array(10).fill({});

  products: Product[] = [];

  constructor(private productService: ProductsService) { }

  ngOnInit(): void {
    this.productService.products.subscribe(result => {
      this.products = result;
    })
  }

  setActiveItem(product: Product) {
    this.productService.activeProduct.next([product]);
  }

}
