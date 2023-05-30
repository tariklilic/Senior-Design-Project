import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  searchParam: string = '';

  constructor(private productsService: ProductsService, private router: Router) { }

  ngOnInit(): void {
  }

  searchProducts() {
    this.productsService.searchParam = this.searchParam;
    this.productsService.getSortedProducts();
    this.router.navigate(['/search']);
  }

}
