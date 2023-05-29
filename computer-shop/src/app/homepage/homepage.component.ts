import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';
import { Product } from '../models/Product.model';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {
  allProduct: Product[] = []

  constructor(private productService: ProductsService) {
  }

  ngOnInit(): void {
    this.productService.getAllProducts();
    this.productService.products.subscribe(result => {
      this.allProduct = result;
    })
  }

}
