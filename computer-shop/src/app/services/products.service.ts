import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { BehaviorSubject } from 'rxjs';
import { PaginatedProduct } from '../models/PaginatedProduct.model';
import { Product } from '../models/Product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  public products = new BehaviorSubject<Product[]>([]);
  public currentPage = new BehaviorSubject<number>(1);
  public pages = new BehaviorSubject<number>(1);
  public componentId = new BehaviorSubject<number>(0);
  public searchParam = '';
  public sort = '';
  public priceLowest = 0;
  public priceHighest = 10000;

  constructor(private http: HttpClient) { }

  getAllProducts() {
    this.http.get<PaginatedProduct>('https://localhost:7153/api/Product/' + this.currentPage.getValue()).subscribe(result => {
      this.products.next(result.products);
      this.pages.next(result.pages);
    })
  }

  getSortedProducts() {
    this.http.get<PaginatedProduct>('https://localhost:7153/api/Product/GetSorted/' + this.currentPage.getValue() + '?componentId= ' + this.componentId.getValue() + '&searchName=' + this.searchParam + '&sort=' + this.sort + '&priceLowest=' + this.priceLowest + '&priceHighest=' + this.priceHighest).subscribe(result => {
      this.products.next(result.products);
      this.pages.next(result.pages);
    })
  }
}
