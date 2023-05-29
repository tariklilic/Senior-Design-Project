import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  appItems: any[] = Array(10).fill({});

  constructor(private userService: UserService) { }

  ngOnInit(): void {

  }

}
