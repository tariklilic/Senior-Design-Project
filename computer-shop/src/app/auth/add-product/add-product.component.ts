import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  public id = 0;
  public name = '';
  public manufacturer = '';
  public shortDesc = '';
  public longDesc = '';
  public quantity = 0;
  public price = 0;
  public rating = 0;
  public componentId = 0;
  public cover = '';
  public image1 = '';
  public image2 = '';
  public image3 = '';
  public image4 = '';

  constructor(private productService: ProductsService) { }

  ngOnInit(): void {
  }

  addProduct() {
    var product = { id: this.id, name: this.name, manufacturer: this.manufacturer, shortDesc: this.shortDesc, longDesc: this.longDesc, quantity: this.quantity, price: this.price, rating: this.rating, componentId: this.componentId, cover: this.cover, images: { image1: this.image1, image2: this.image2, image3: this.image3, image4: this.image4 } };
    this.productService.addProduct(product);
  }

}
