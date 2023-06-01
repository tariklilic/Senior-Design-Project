import { Component, Input, OnInit } from '@angular/core';
import { CartItem } from 'src/app/models/CartItem.model';
import { CartService } from 'src/app/services/cart.service';
import { ProductsService } from 'src/app/services/products.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {
  @Input() product!: CartItem;
  quantity!: number;

  constructor(private cartService: CartService, private productService: ProductsService) { }

  ngOnInit(): void {
    this.quantity = this.product.quantity;
  }

  increment() {
    if (this.quantity + 1 <= this.product.product.quantity) {
      this.quantity++;
      this.updateQuantity();
    } else {
      return;
    }
  }

  decrement() {
    if (this.quantity - 1 >= 1) {
      this.quantity--;
      this.updateQuantity();
    } else {
      return;
    }
  }

  updateQuantity() {
    if (this.quantity > this.product.product.quantity) {
      this.quantity = this.product.product.quantity
    } else if (this.quantity < 1) {
      this.quantity = 1
    }
    this.cartService.updateProductQuantity(this.product.id, this.quantity);
  }

  removeFromCart() {
    this.cartService.removeFromCart(this.product.id);
  }

  viewProduct() {
    this.productService.getProductById(this.product.product.id);
  }
}
