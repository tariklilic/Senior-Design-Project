import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CartItem } from '../models/CartItem.model';
import { ProductsService } from './products.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public cart = new BehaviorSubject<CartItem[]>([]);
  public totalPrice = new BehaviorSubject<number>(0);
  public purchaseHistory = new BehaviorSubject<CartItem[]>([]);

  constructor(private productService: ProductsService) {

  }

  addItemToCart(productName: string) {
    var currentCart = this.cart.getValue();
    var itemInCart = currentCart.find(cartItem => cartItem.product.name === productName)
    if (itemInCart !== undefined) {
      this.updateQuantity(productName, itemInCart.quantity + 1);
    } else {
      this.productService.getProductByName(productName).subscribe(game => {
        if (game) {
          const cartItem = new CartItem(game, 1);
          const currentCart = this.cart.getValue();
          const updatedCart = [...currentCart, cartItem];
          this.cart.next(updatedCart);
          this.generateTotalPrice();
        }
      });
    }
  }

  updateQuantity(productName: string, quantity: number) {
    var currentCart = this.cart.getValue();
    const updatedCart = currentCart.map(cartItem => {
      if (cartItem.product.name === productName) {
        return new CartItem(cartItem.product, quantity);
      }
      return cartItem;
    });
    this.cart.next(updatedCart);
    this.generateTotalPrice();
  }

  generateTotalPrice() {
    let totalPrice = 0;
    var cart = this.cart.getValue();
    for (var i = 0; i < cart.length; i++) {
      totalPrice = totalPrice + (cart[i].quantity * cart[i].product.price);
      this.totalPrice.next(Number(totalPrice.toFixed(2)))
    }
    if (cart.length === 0) {
      this.totalPrice.next(0);
    }
  }

  Checkout() {
    var cart = this.cart.getValue();
    var purchaseHistory = this.purchaseHistory.getValue();
    for (var i = 0; i < cart.length; i++) {
      purchaseHistory.push(cart[i]);
    }
    this.purchaseHistory.next(purchaseHistory);
    this.cart.next([]);
    this.generateTotalPrice();
  }

}
