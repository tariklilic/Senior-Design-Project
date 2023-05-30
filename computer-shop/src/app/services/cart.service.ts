import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CartItem } from '../models/CartItem.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  public cart = new BehaviorSubject<CartItem[]>([]);

  constructor(private http: HttpClient) { }

  getCartProducts(userId: string) {
    const requestOptions: Object = {
      headers: new HttpHeaders().append('Authorization', localStorage.getItem('token')!)
    }
    this.http.get<CartItem[]>('https://localhost:7153/Cart?id=' + userId, requestOptions).subscribe(result => {
      this.cart.next(result);
    })
  }

  updateProductQuantity(cartItemId: number, quantity: number) {
    const requestOptions: Object = {
      headers: new HttpHeaders().append('Authorization', localStorage.getItem('token')!)
    }
    this.http.put('https://localhost:7153/Cart?cartItemId=' + cartItemId + '&quantity=' + quantity, null, requestOptions).subscribe({
      next: (result) => {
        console.log('Quantity updated');
      },
      error: (err) => {
        console.log(err.message);
      }
    })
  }

  addToCart(userId: string, productId: number, quantity: number) {
    const requestOptions: Object = {
      headers: new HttpHeaders().append('Authorization', localStorage.getItem('token')!)
    }
    var body = {
      userId: userId,
      productId: productId,
      quantity: quantity
    }
    this.http.post<CartItem[]>('https://localhost:7153/Cart', body, requestOptions).subscribe({
      next: (result) => {
        this.cart.next(result);
      },
      error: (err) => {
        console.log(err.message);
      }
    })
  }

  removeFromCart(cartItemId: number) {
    const requestOptions: Object = {
      headers: new HttpHeaders().append('Authorization', localStorage.getItem('token')!)
    }
    this.http.put<CartItem[]>('https://localhost:7153/Cart/RemoveFromCart?cartItemId=' + cartItemId, null, requestOptions).subscribe({
      next: (result) => {
        this.cart.next(result);
      },
      error: (err) => {
        console.log(err.message);
      }
    })
  }

}
