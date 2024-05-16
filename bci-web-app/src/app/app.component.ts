import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DisplayComponent } from "./display/display.component";
import { SidebarComponent } from "./sidebar/sidebar.component";
import { ApiService } from './api.service';
import { HttpClientModule } from '@angular/common/http';
import { Item } from './models/item.model';
import { HeaderComponent } from "./header/header.component";
import { AppRoutingModule } from './app-routing.module';


@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    providers: [ApiService],
    imports: [RouterOutlet, DisplayComponent, SidebarComponent, HeaderComponent, HttpClientModule]
})

export class AppComponent {
  

}
