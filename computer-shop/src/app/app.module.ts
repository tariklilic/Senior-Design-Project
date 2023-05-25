import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { RegisterComponent } from './auth/register/register.component';
import { LoginComponent } from './auth/login/login.component';
import { RouterModule } from '@angular/router';
import { AboutusComponent } from './aboutus/aboutus.component';
import { FaqComponent } from './faq/faq.component';
import { HomepageComponent } from './homepage/homepage.component';
import { CarouselItemComponent } from './homepage/carousel-item/carousel-item.component';
import { HttpClientModule } from '@angular/common/http';
import { ResponsiveCarouselComponent } from './homepage/responsive-carousel/responsive-carousel.component';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { ItemComponent } from './items/item/item.component';
import { PaginationComponent } from './pagination/pagination.component';
import { SearchResultsComponent } from './search-results/search-results.component';
import { SortFilterComponent } from './search-results/sort-filter/sort-filter.component';
import { CartComponent } from './cart/cart.component';
import { CartItemComponent } from './items/cart-item/cart-item.component';
import { FormsModule } from '@angular/forms';
import { ProfileComponent } from './profile/profile.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProfileItemComponent } from './items/profile-item/profile-item.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    RegisterComponent,
    LoginComponent,
    AboutusComponent,
    FaqComponent,
    HomepageComponent,
    CarouselItemComponent,
    ResponsiveCarouselComponent,
    ItemComponent,
    PaginationComponent,
    SearchResultsComponent,
    SortFilterComponent,
    CartComponent,
    CartItemComponent,
    ProfileComponent,
    ProductDetailsComponent,
    ProfileItemComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    SlickCarouselModule,
    FormsModule,
    BrowserAnimationsModule,
    MatPaginatorModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
