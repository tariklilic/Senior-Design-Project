import { Component, OnInit } from '@angular/core';
import { Product } from '../models/Product.model';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  images: string[] = [
    'https://static.nicehash.com/marketing%2Frtx-4090-specs-and-mining-hashrate2.png',
    'https://a-power.com/app/uploads/2022/10/102155661_2564994988.png',
    'https://www.gigabyte.com/FileUpload/Global/KeyFeature/2179/innergigabyteimages/kf-img.png',
    'https://static.nicehash.com/marketing%2Frtx-4090-specs-and-mining-hashrate2.png'
  ];

  selectedImage: string = this.images[0];

  activeItem: Product[] = [];

  showImage(image: string) {
    this.selectedImage = image;
  }

  constructor(private productsService: ProductsService) { }

  ngOnInit(): void {
    this.productsService.activeProduct.subscribe(result => {
      this.activeItem[0] = result[0];
    })
  }

}
