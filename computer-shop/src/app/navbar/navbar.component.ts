import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  searchParam: string = '';
  userLoggedIn: boolean = false;

  constructor(private productsService: ProductsService, private router: Router, private userService: UserService) { }

  ngOnInit(): void {
    var token = localStorage.getItem("token");
    if (token) {
      this.userService.loggedUser.next(true);
      this.userService.getLoggedUserId();
    }
    this.userService.loggedUser.subscribe(result => {
      this.userLoggedIn = result;
    })
  }

  searchProducts() {
    this.productsService.searchParam = this.searchParam;
    this.productsService.currentPage.next(1);
    this.productsService.getSortedProducts();
    this.router.navigate(['/search']);
  }

  logout() {
    this.userService.logout();
  }

}
