import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {
  totalItems: number = 0;
  currentPage: number = 1;
  paginationArray: number[] = [];


  constructor(private productService: ProductsService) { }

  ngOnInit(): void {
    this.productService.totalItems.subscribe(result => {
      this.totalItems = result;
      this.createNumberArray(Math.ceil(result / 10));
    })
    this.productService.currentPage.subscribe(result => {
      this.currentPage = result;
    })

  }

  createNumberArray(num: number) {
    this.paginationArray = Array.from({ length: num }, (_, index) => index + 1);
  }

  setPageNumber(number: number) {
    this.productService.currentPage.next(number);
    this.productService.getSearchedProducts();
  }

}
