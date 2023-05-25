import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { CarouselItem } from '../models/CarouselItem.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ComponentsService {

  public components = new BehaviorSubject<CarouselItem[]>([]);

  constructor(private http: HttpClient) {
  }

  getComponents() {
    return this.http.get<CarouselItem[]>('/assets/components/components.json').subscribe(result => {
      this.components.next(result);
    })
  }

}
