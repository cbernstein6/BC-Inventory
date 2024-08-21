import { Component, Input } from '@angular/core';
import { Item } from '../models/item.model';
import { CommonModule } from '@angular/common';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-display',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './display.component.html',
  styleUrl: './display.component.css'
})
export class DisplayComponent {
  apiService: ApiService;
  @Input() currItem?: Item;

  constructor(apiService: ApiService) {
    this.apiService = apiService;
  }

  decrementQuantity() {
    if(this.currItem){
      this.currItem.quantity--;
    }
    this.saveQuantity();
  }
  incrementQuantity() {
    if(this.currItem){
      this.currItem.quantity++;
    }
    this.saveQuantity();
  }

  saveQuantity(){
    this.apiService.updateItem(this.currItem!).subscribe();
  }
}