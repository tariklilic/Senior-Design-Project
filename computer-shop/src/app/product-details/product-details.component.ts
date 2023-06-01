import { Component, OnInit } from '@angular/core';
import { Product } from '../models/Product.model';
import { ProductsService } from '../services/products.service';
import { UserService } from '../services/user.service';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  appItems: any[] = Array(4).fill({});
  product!: Product;

  constructor(private productService: ProductsService, private userService: UserService, private cartService: CartService) { }

  ngOnInit(): void {
    this.productService.product.subscribe(result => {
      this.product = result;
    })
  }

  addToCart() {
    var userId = this.userService.loggedUserId.getValue();
    this.cartService.addToCart(userId, this.product.id, 1);
  }

}
