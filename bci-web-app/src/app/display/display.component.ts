import { Component, Input } from '@angular/core';
import { Item } from '../models/item.model';

@Component({
  selector: 'app-display',
  standalone: true,
  imports: [],
  templateUrl: './display.component.html',
  styleUrl: './display.component.css'
})
export class DisplayComponent {
  @Input() currItem?: Item;

  
}