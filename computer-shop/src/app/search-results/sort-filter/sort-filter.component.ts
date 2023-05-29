import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-sort-filter',
  templateUrl: './sort-filter.component.html',
  styleUrls: ['./sort-filter.component.css']
})
export class SortFilterComponent implements OnInit {

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


}
