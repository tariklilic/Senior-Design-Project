import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { CartItem } from '../models/CartItem.model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cart: CartItem[] = [];
  totalPrice = 0;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.cart.subscribe(result => {
      this.cart = result;
    })
    this.userService.totalPrice.subscribe(result => {
      this.totalPrice = result;
    })
  }

  checkout() {
    this.userService.Checkout();
  }

}
