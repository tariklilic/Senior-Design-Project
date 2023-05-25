import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-sort-filter',
  templateUrl: './sort-filter.component.html',
  styleUrls: ['./sort-filter.component.css']
})
export class SortFilterComponent implements OnInit {

  selectedOption: string = '';
  activeComponent: string = "Type";

  constructor(private productsService: ProductsService, private router: Router) { }

  ngOnInit(): void {
    this.productsService.activeComponent.subscribe(result => {
      this.activeComponent = result;
    })
  }

  isDropdownHiddenName: boolean = true;

  toggleDropdownName() {
    this.isDropdownHiddenName = !this.isDropdownHiddenName;
  }

  isDropdownHiddenRating: boolean = true;

  toggleDropdownRating() {
    this.isDropdownHiddenRating = !this.isDropdownHiddenRating;
  }

  isDropdownHiddenPrice: boolean = true;

  toggleDropdownPrice() {
    this.isDropdownHiddenPrice = !this.isDropdownHiddenPrice;
  }

  isDropdownHiddenType: boolean = true;

  toggleDropdownType() {
    this.isDropdownHiddenType = !this.isDropdownHiddenType;
  }

  orderByName(option: string) {
    this.productsService.orderBy = 'name'
    this.productsService.orderDirection = option;
    this.productsService.getSearchedProducts();
  }

  orderByRating(option: string) {
    this.productsService.orderBy = 'rating'
    this.productsService.orderDirection = option;
    this.productsService.getSearchedProducts();
  }

  orderByPrice(option: string) {
    this.productsService.orderBy = 'price'
    this.productsService.orderDirection = option;
    this.productsService.getSearchedProducts();
  }

  getComponent(component: string) {
    this.productsService.activeComponent.next(component);
    this.productsService.getSearchedProducts();
    this.router.navigate(['/search']);

  }

  updateMinPrice(event: Event) {
    if ((event.target as HTMLInputElement).value !== '') {
      this.productsService.minPrice = parseInt((event.target as HTMLInputElement).value);
    } else {
      this.productsService.minPrice = 0
    }
    this.productsService.getSearchedProducts();
  }

  updateMaxPrice(event: Event) {
    if ((event.target as HTMLInputElement).value !== '') {
      this.productsService.maxPrice = parseInt((event.target as HTMLInputElement).value);
    } else {
      this.productsService.maxPrice = 0
    }
    this.productsService.getSearchedProducts();
  }


}
