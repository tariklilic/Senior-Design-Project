import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/models/Product.model';
import { CartService } from 'src/app/services/cart.service';
import { ProductsService } from 'src/app/services/products.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  @Input() product!: Product;

  constructor(private userService: UserService, private cartService: CartService, private productService: ProductsService) { }

  ngOnInit(): void {

  }

  addToCart() {
    var userId = this.userService.loggedUserId.getValue();
    this.cartService.addToCart(userId, this.product.id, 1);
  }

  viewProduct() {
    this.productService.getProductById(this.product.id);
  }
}
