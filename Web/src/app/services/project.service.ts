import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Project } from '../models/project.model';
import { ApiService } from './api.service';
import * as _ from 'lodash';

@Injectable()
export class ProjectService {

  constructor(private apiService: ApiService) { }


  getAll(): Observable<any> {
    return this.apiService.get("Project/GetProjectDetails")
      .pipe(map((Projects: Array<any>) => Projects.map(Project => this.mapProject(Project))));
  }

  getById(id: number): Observable<any> {
    return this.apiService.get("Project/GetProjectById", new HttpParams().set("id", id.toString()))
      .pipe(map(Project => this.mapProject(Project)));
  }
  
  search(searchText): Observable<any> {
    return this.apiService.get("Project/Search", new HttpParams().set("searchText", searchText))
      .pipe(map((Projects: Array<any>) => Projects.map(Project => this.mapProject(Project))));
  }

  create(Project: Project): Observable<any> {
    return this.apiService.post("Project/AddProject", Project);
  }

  update(Project: Project): Observable<any> {
    return this.apiService.put("Project/UpdateProject", Project);
  }

  delete(id: number) {
    return this.apiService.delete("Project/DeleteProject", new HttpParams().set("id", id.toString()));
  }

  private mapProject(project): Project {
    project.tasksCompleted = _.filter(project.tasks, (m) => m.isCompleted).length;
    return project;
  }

}
