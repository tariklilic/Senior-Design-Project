import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {
  totalPages: number = 1;
  paginationArray: number[] = [];

  appItems: any[] = Array(10).fill({});

  constructor(private productService: ProductsService, private router: Router) { }

  ngOnInit(): void {
    this.productService.pages.subscribe(result => {
      this.totalPages = result;
      this.createNumberArray(result);
    })
  }

  createNumberArray(num: number) {
    this.paginationArray = Array.from({ length: num }, (_, index) => index + 1);
  }

  setPageNumber(num: number) {
    this.productService.currentPage.next(num);
    var url = this.router.url;
    if (url === '/search') {
      this.productService.getSortedProducts();
    } else {
      this.productService.getAllProducts();
    }
  }

}
