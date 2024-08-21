import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Item } from '../models/item.model';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../api.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})



export class SidebarComponent implements OnInit {
  inputText: string = "";
  addItem: boolean = false;
  removeItem: boolean = false;
  
  itemList: Item[] = [];
  numbers: number[] = [];

  @Output() itemEmitter = new EventEmitter<Item>();

  constructor(private http: ApiService){}
  


  ngOnInit(){
    this.refreshList();
    this.numbers = Array.from({ length: 20 }, (_, i) => i + 1);
  }
  


  displayItem(item: Item) {
    if(this.removeItem){
      this.itemList = this.itemList.filter(i => i.id !== item.id);
      this.http.removeItem(item.id).subscribe(data => {
        console.log(data);
      }, error => {
        console.log(error);
      });
    }else {
      this.itemEmitter.emit(item);
    }
  }

  showInput(){
    this.addItem = !this.addItem;
  }
  onClickRemoval(){
    this.removeItem = !this.removeItem;
  }

  addToList(item: string){
    const itemObj: Item = {id: -1, title: item, description: 'Description 1', category: "category 1", imageUrl: "image1", price: 10, quantity: 10 };
    this.http.addItem(itemObj).subscribe(data => {
      console.log(data);
      this.itemList.push(itemObj);
      this.refreshList();
    }, error => {
      console.log(error);
    });
  }

  emptyList(){
    return this.itemList.length === 0;
  }

  
  refreshList(){
    this.http.getItems().subscribe(data => {
      this.itemList = Object.values(data);
    },
    error => {
      console.log(error);
    }
  );
  }
}
