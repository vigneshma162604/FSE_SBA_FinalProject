import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap';

import { AppComponent } from './app.component';
import { AddUserComponent } from './component/user/add-user/add-user.component';
import { TaskService } from './services/task.service';
import { ApiService } from './services/api.service';
import { ScrollTopDirective } from './shared/scrolltop.directive';
import { UserService } from './services/user.service';
import { UserComponent } from './component/user/user.component';
import { AddProjectComponent } from './component/project/add-project/add-project.component';
import { ProjectComponent } from './component/project/project.component';
import { ProjectService } from './services/project.service';
import { AddTaskComponent } from './component/task/add-task/add-task.component';
import { ViewTaskComponent } from './component/task/view-task/view-task.component';
import { ModalLookupComponent } from './shared/components/modal-lookup/modal-lookup.component';
import { AppRoutingModule } from './app-routing';

@NgModule({
  declarations: [
    AppComponent,
    AddUserComponent, UserComponent,
    ProjectComponent, AddProjectComponent,
    AddTaskComponent, ViewTaskComponent,
    ScrollTopDirective,    
    ModalLookupComponent
  ],
  imports: [
    BrowserModule,
     FormsModule, 
     ReactiveFormsModule, 
     HttpClientModule ,
     AppRoutingModule    
  ],
  entryComponents: [ModalLookupComponent],
  providers: [TaskService, UserService, ApiService, ProjectService],
  bootstrap: [AppComponent]
})
export class AppModule { }
