import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { BehaviorSubject } from 'rxjs';
import { PaginatedProduct } from '../models/PaginatedProduct.model';
import { Product } from '../models/Product.model';
import { ProductImages } from '../models/ProductImages.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  public products = new BehaviorSubject<Product[]>([]);
  public currentPage = new BehaviorSubject<number>(1);
  public pages = new BehaviorSubject<number>(1);
  public componentId = new BehaviorSubject<number>(0);
  public product = new BehaviorSubject<Product>(new Product(0, '', '', '', 0, 0, 0, '', '', 0, new ProductImages('', '', '', '')));
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

  getProductById(productId: number) {
    this.http.get<any>('https://localhost:7153/api/Product/item/' + productId).subscribe(result => {
      this.product.next(result.data);
    })
  }

  addProduct(addProduct: Product) {
    const requestOptions: Object = {
      headers: new HttpHeaders().append('Content-Type', 'application/json').append('Authorization', localStorage.getItem('token')!)
    }
    this.http.post('https://localhost:7153/api/Product', JSON.stringify(addProduct), requestOptions).subscribe({
      next: () => {
        console.log("You have successfully added Product!");
      },
      error: (err) => {
        console.log(err.message);
      }
    });
  }

  deleteProduct(productId: number) {
    const requestOptions: Object = {
      headers: new HttpHeaders().append('Content-Type', 'application/json').append('Authorization', localStorage.getItem('token')!)
    }
    this.http.delete('https://localhost:7153/api/Product/' + productId, requestOptions).subscribe({
      next: () => {
        this.getAllProducts();
      },
      error: (err) => {
        console.log(err.message);
      }
    });
  }
}
