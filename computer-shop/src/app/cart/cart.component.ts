import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { CartItem } from '../models/CartItem.model';
import { CartService } from '../services/cart.service';
import { CartItemPrice } from '../models/CartItemPrice.model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cart!: CartItemPrice;

  constructor(private cartService: CartService, private userService: UserService) { }

  ngOnInit(): void {
    console.log(this.userService.loggedUserId.getValue());
    var loggedUser = this.userService.loggedUserId.getValue();
    this.cartService.getCartProducts(loggedUser);

    this.cartService.cart.subscribe(result => {
      console.log(result);
      this.cart = result;
    })
  }

}
