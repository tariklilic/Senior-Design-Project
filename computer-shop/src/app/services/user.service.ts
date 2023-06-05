import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserRegister } from '../models/UserRegister.model';
import { UserLogin } from '../models/UserLogin.model';
import { PurchaseHistory } from '../models/PurchaseHistory.model';
import { CartItemPrice } from '../models/CartItemPrice.model';
import { CartService } from './cart.service';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  public loggedUser = new BehaviorSubject<boolean>(false);
  public userRole = new BehaviorSubject<any>({});
  public loggedUserId = new BehaviorSubject<any>({});
  public purchaseHistory = new BehaviorSubject<PurchaseHistory>(new PurchaseHistory([], 0));

  constructor(private http: HttpClient, private cartService: CartService) { }

  register(user: UserRegister) {
    const requestOptions: Object = {
      headers: new HttpHeaders().append('Content-Type', 'application/json')
    }
    this.http.post('https://localhost:7153/Auth/register', user).subscribe({
      next: () => {
        console.log("You have successfully registered!");
      },
      error: (err) => {
        console.log(err.message);
      }
    });
  }

  login(user: UserLogin) {
    const requestOptions: Object = {
      headers: new HttpHeaders().append('Content-Type', 'application/json'),
      responseType: 'text'
    }

    this.http.post('https://localhost:7153/Auth/login', user, requestOptions).subscribe({
      next: (token) => {
        localStorage.setItem("token", "bearer " + JSON.parse(token.toString()).token);
        console.log("Successfully logged in");
        this.loggedUser.next(true);
        this.getLoggedUserId();
        this.getLoggedUserRole();
      },
      error: (err) => {
        console.log(err.message);
      }
    });
  }

  logout() {
    localStorage.removeItem("token");
    this.loggedUser.next(false);
    this.loggedUserId.next(0);
    this.userRole.next(1);
  }

  getTokenData() {
    var token = localStorage.getItem("token");
    return JSON.parse(atob(token!.split('.')[1]));
  }

  getLoggedUserId() {
    var token = this.getTokenData();
    this.loggedUserId.next(Object.values(token)[1]);
  }

  getLoggedUserRole() {
    var token = this.getTokenData();
    this.userRole.next(Object.values(token)[2]);
    console.log(this.userRole.getValue())
  }

  getPurchaseHistory() {
    const requestOptions: Object = {
      headers: new HttpHeaders().append('Authorization', localStorage.getItem('token')!)
    }
    this.http.get<PurchaseHistory>('https://localhost:7153/History?id=' + this.loggedUserId.getValue(), requestOptions).subscribe(result => {
      console.log(result);
      this.purchaseHistory.next(result);
    })
  }

  purchaseProducts() {
    const requestOptions: Object = {
      headers: new HttpHeaders().append('Authorization', localStorage.getItem('token')!)
    }
    this.http.post('https://localhost:7153/History?id=' + this.loggedUserId.getValue(), requestOptions).subscribe({
      next: () => {
        this.cartService.getCartProducts(this.loggedUserId.getValue());
      },
      error: (err) => {
        console.log(err.message);
      }
    })
  }


}