import { Component, Input, OnInit } from '@angular/core';
import { CartItem } from 'src/app/models/CartItem.model';
import { ProductsService } from 'src/app/services/products.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-profile-item',
  templateUrl: './profile-item.component.html',
  styleUrls: ['./profile-item.component.css']
})
export class ProfileItemComponent implements OnInit {
  @Input() product!: CartItem;

  constructor(private productService: ProductsService) { }

  ngOnInit(): void {
  }

  viewProduct() {
    this.productService.getProductById(this.product.product.id);
  }

}
