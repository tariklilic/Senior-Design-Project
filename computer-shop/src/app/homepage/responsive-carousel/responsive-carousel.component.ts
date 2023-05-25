import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { SlickCarouselComponent } from 'ngx-slick-carousel';
import { CarouselItem } from 'src/app/models/CarouselItem.model';
import { ComponentsService } from 'src/app/services/components.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-responsive-carousel',
  templateUrl: './responsive-carousel.component.html',
  styleUrls: ['./responsive-carousel.component.css']
})
export class ResponsiveCarouselComponent implements OnInit {
  @ViewChild('slickModal', { static: true }) slickModal!: SlickCarouselComponent;

  slideConfig = {
    "slidesToShow": 6,
    "slidesToScroll": 1,
    "arrows": false,
    "dots": false,
    "infinite": true,
    "responsive": [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 4
        }
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2
        }
      }
    ]
  };

  constructor(private componentsService: ComponentsService, private productsService: ProductsService, private router: Router) {

  }

  ngOnInit(): void {
    this.componentsService.getComponents();
    this.componentsService.components.subscribe(result => {
      this.carouselItems = result;
    })
  }

  carouselItems: CarouselItem[] = [];

  prevSlide() {
    this.slickModal.slickPrev();
  }

  nextSlide() {
    this.slickModal.slickNext();
  }

  getComponent(component: string) {
    this.productsService.currentPage.next(1);
    this.productsService.activeComponent.next(component);
    this.productsService.getSearchedProducts();
    this.router.navigate(['/search']);

  }
}