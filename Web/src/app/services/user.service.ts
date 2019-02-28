import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';

import { User } from '../models/user.model';
import { ApiService } from './api.service';

@Injectable()
export class UserService {

  constructor(private apiService: ApiService) { }
  
  getAll(): Observable<any> {
    return this.apiService.get("User/GetUserDetails");
  }

  getById(id: number): Observable<any> {
    return this.apiService.get("User/GetUserById", new HttpParams().set("id", id.toString()));
  }

  create(user: User): Observable<any> {
    return this.apiService.post("User/AddUser", user);
  }

  update(user: User): Observable<any> {    
    return this.apiService.put("User/UpdateUser", user);
  }

  search(searchText): Observable<any> {
    return this.apiService.get("User/SearchUsers", new HttpParams().set("searchText", searchText));
  }

  delete(id: number) {    
    return this.apiService.delete("User/DeleteUser", new HttpParams().set("id", id.toString()));
  }
}
