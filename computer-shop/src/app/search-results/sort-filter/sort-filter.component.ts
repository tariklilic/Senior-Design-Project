import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-sort-filter',
  templateUrl: './sort-filter.component.html',
  styleUrls: ['./sort-filter.component.css']
})
export class SortFilterComponent implements OnInit {
  priceLowest!: number;
  priceHighest!: number;

  constructor(private productsService: ProductsService, private router: Router) { }

  ngOnInit(): void {
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

  setSort(sort: string) {
    this.productsService.sort = sort;
    this.productsService.getSortedProducts();
  }

  setPriceLowest() {
    if (this.priceLowest !== null) {
      this.productsService.priceLowest = this.priceLowest;
    } else {
      this.productsService.priceLowest = 0;
    }
    this.productsService.getSortedProducts();
  }

  setPriceHighest() {
    if (this.priceHighest !== null) {
      this.productsService.priceHighest = this.priceHighest;
    } else {
      this.productsService.priceHighest = 10000;
    }
    this.productsService.getSortedProducts();
  }

  setComponent(componentId: number) {
    this.productsService.componentId.next(componentId);
    this.productsService.getSortedProducts();
  }


}
