import { Component } from '@angular/core';
import { Item } from '../models/item.model';
import { RouterOutlet } from '@angular/router';
import { DisplayComponent } from '../display/display.component';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterOutlet, DisplayComponent, SidebarComponent, HeaderComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  title: string = 'bci-web-app';
  item?: Item;

  constructor() { }

  fetchItem(currItem: Item) : void {
    this.item = currItem;
  }
}
