import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Item } from './models/item.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get('http://localhost:5094/getitem');
  }
  
  removeItem(id: number) {
    console.log(id);
    return this.http.delete(`http://localhost:5094/deleteitem/${id}`);
  }

  addItem(item: Item) {
    return this.http.post('http://localhost:5094/additem', item);
  }
}
