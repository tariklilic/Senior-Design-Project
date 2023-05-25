import { Component, Input, OnInit } from '@angular/core';
import { CartItem } from 'src/app/models/CartItem.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {

  @Input() Item!: CartItem;

  constructor(private userService: UserService) { }

  ngOnInit(): void {

  }

  @Input() value: number = 0;

  increment() {
    this.userService.updateQuantity(this.Item.product.name, this.Item.quantity + 1)
  }

  decrement() {
    if (this.Item.quantity > 1) {
      this.userService.updateQuantity(this.Item.product.name, this.Item.quantity - 1)
    }
  }

}
