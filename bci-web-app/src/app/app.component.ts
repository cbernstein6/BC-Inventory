import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DisplayComponent } from "./display/display.component";
import { SidebarComponent } from "./sidebar/sidebar.component";
import { ApiService } from './api.service';
import { HttpClientModule } from '@angular/common/http';
import { Item } from './models/item.model';


@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet, DisplayComponent, SidebarComponent],
    providers: [ApiService]
})
export class AppComponent {
  
  title: string = 'bci-web-app';
  item?: Item;

  constructor() { }

  fetchItem(currItem: Item) : void {
    this.item = currItem;
    console.log(this.item.category);
  }

}
