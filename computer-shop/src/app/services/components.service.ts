import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { CarouselItem } from '../models/CarouselItem.model';
import { BehaviorSubject } from 'rxjs';
import { CarouselItemArray } from '../models/CarouselItemArray.model';

@Injectable({
  providedIn: 'root'
})

export class ComponentsService {
  public components = new BehaviorSubject<CarouselItem[]>([]);

  constructor(private http: HttpClient) {
  }

  getAllComponents() {
    this.http.get<CarouselItemArray>('https://localhost:7153/api/Component').subscribe(result => {
      this.components.next(result.data);
    })
  }
}
