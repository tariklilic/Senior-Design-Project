import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/models/Product.model';
import { ProductsService } from 'src/app/services/products.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {

  @Input() products: Product | undefined;

  constructor(private userService: UserService) { }

  ngOnInit(): void {

  }

  addToCart(productName: string) {
    this.userService.addItemToCart(productName);
  }



}
