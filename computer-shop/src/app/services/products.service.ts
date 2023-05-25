import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { BehaviorSubject, Observable, map } from 'rxjs';
import { Product } from '../models/Product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  public activeProduct = new BehaviorSubject<Product[]>([]);
  public products = new BehaviorSubject<Product[]>([]);
  public activeComponent = new BehaviorSubject<string>("Type");
  searchParam: string = '';
  sortByName: string = '';
  sortByRating: string = '';
  orderBy: string = 'name';
  orderDirection: string = 'ASC';
  minPrice: number = 0;
  maxPrice: number = 0;
  itemsPerPage = new BehaviorSubject<number>(10);
  currentPage = new BehaviorSubject<number>(1);
  totalItems = new BehaviorSubject<number>(0);

  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<Product[]>('/assets/products/products.json').subscribe(result => {
      this.products.next(result);
    })
  }

  getSearchedProducts() {
    this.http.get<Product[]>('/assets/products/products.json').subscribe(result => {
      const searchParamLower = this.searchParam.toLowerCase();
      const filteredProducts = result.filter(product => {
        const isNameMatch = product.name.toLowerCase().includes(searchParamLower);
        const isTypeMatch = this.activeComponent.value === 'Type' || product.type === this.activeComponent.value;
        const isPriceValid = (this.minPrice === 0 || product.price >= this.minPrice) &&
          (this.maxPrice === 0 || product.price <= this.maxPrice);
        return isNameMatch && isTypeMatch && isPriceValid;
      });

      const sortedProducts = this.orderProducts(filteredProducts, this.orderBy, this.orderDirection);
      this.totalItems.next(sortedProducts.length);

      const startIndex = (this.currentPage.getValue() - 1) * this.itemsPerPage.getValue();
      const endIndex = startIndex + this.itemsPerPage.getValue();
      const paginatedProducts = sortedProducts.slice(startIndex, endIndex);

      this.products.next(paginatedProducts);
    });
  }

  getTotalNumberOfItems() {
    var searchProducts: Product[] = [];
    this.http.get<Product[]>('/assets/products/products.json').subscribe(result => {
      for (var i = 0; i < result.length; i++) {
        if (result[i].name.toLowerCase().includes(this.searchParam.toLowerCase())) {
          if (this.activeComponent.value !== "Type" && result[i].type !== this.activeComponent.value) {
            continue;
          }
          searchProducts.push(result[i]);
        }
      }

      searchProducts = this.orderProducts(searchProducts, this.orderBy, this.orderDirection);

      var filteredProducts: Product[] = [];
      for (var j = 0; j < searchProducts.length; j++) {
        var product = searchProducts[j];
        var isMinPriceValid = this.minPrice !== 0 && product.price >= this.minPrice;
        var isMaxPriceValid = this.maxPrice !== 0 && product.price <= this.maxPrice;

        if ((this.minPrice === 0 || isMinPriceValid) && (this.maxPrice === 0 || isMaxPriceValid)) {
          filteredProducts.push(product);
        }
      }

      this.totalItems.next(filteredProducts.length);
    });
  }



  orderProducts(products: Product[], orderBy: string, orderDirection: string): Product[] {
    return products.sort((a, b) => {
      let aValue, bValue;

      if (orderBy === 'rating') {
        aValue = a.rating;
        bValue = b.rating;
      } else if (orderBy === 'price') {
        aValue = a.price;
        bValue = b.price;
      } else {
        aValue = a.name;
        bValue = b.name;
      }

      if (aValue < bValue) {
        return orderDirection === 'ASC' ? -1 : 1;
      } else if (aValue > bValue) {
        return orderDirection === 'ASC' ? 1 : -1;
      } else {
        return 0;
      }
    });
  }

  getProductByName(productName: string): Observable<Product | undefined> {
    return this.http.get<Product[]>('/assets/products/products.json').pipe(
      map(products => products.find(product => product.name === productName))
    );
  }

}
