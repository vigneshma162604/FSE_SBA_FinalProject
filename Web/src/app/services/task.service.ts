import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ApiService } from './api.service';
import { Task } from '../models/task.model';

@Injectable()
export class TaskService {
  constructor(private apiService: ApiService) { }

  getAll(): Observable<any> {
    return this.apiService.get("Task/GetTaskDetails");
  }
  
  getById(taskId: number): Observable<any> {
    return this.apiService.get("Task/GetTaskById", new HttpParams().set("id", taskId.toString()));
  }

  create(task: Task): Observable<any> {
    return this.apiService.post("AddTask", task);
  }

  update(task: Task): Observable<any> {
    return this.apiService.put("UpdateTask", task);
  }

  end(taskId: number): Observable<any> {
    return this.apiService.delete("DeleteTask", new HttpParams().set("id", taskId.toString()));
  }

  getParentTasks(): Observable<any> {
    return this.apiService.get("Task/GetParentTasks");
  }

  getByProjectId(projectId): Observable<any> {
    return this.apiService.get("Task/GetByProjectId", new HttpParams().set("projectId", projectId));
  }
  
}
