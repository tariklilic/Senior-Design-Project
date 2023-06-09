import { Component, OnInit } from '@angular/core';
import { Product } from '../models/Product.model';
import { ProductsService } from '../services/products.service';
import { UserService } from '../services/user.service';
import { CartService } from '../services/cart.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  appItems: any[] = Array(4).fill({});
  product!: Product;
  userAdmin: boolean = false;

  constructor(private productService: ProductsService, private userService: UserService, private cartService: CartService, private router: Router) { }

  ngOnInit(): void {
    this.userService.userRole.subscribe(result => {
      if (result === 'Admin') {
        this.userAdmin = true;
      } else {
        this.userAdmin = false;
      }
    })
    this.productService.product.subscribe(result => {
      this.product = result;
    })
  }

  addToCart() {
    var userId = this.userService.loggedUserId.getValue();
    this.cartService.addToCart(userId, this.product.id, 1);
  }

  deleteProduct() {
    this.productService.deleteProduct(this.product.id);
    this.productService.currentPage.next(1);
    this.router.navigate(['/homepage'])
  }

  changeCoverImage(imageUrl: string): void {
    this.product.cover = imageUrl;
  }

}
