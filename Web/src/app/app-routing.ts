import { NgModule } from '@angular/core';
import { ModalModule } from 'ngx-bootstrap';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './component/user/user.component';
import { ProjectComponent } from './component/project/project.component';
import { AddTaskComponent } from './component/task/add-task/add-task.component';
import { ViewTaskComponent } from './component/task/view-task/view-task.component';


const appRoutes: Routes = [
    { path: '', redirectTo: "/user", pathMatch: "full" },
    { path: 'user', component: UserComponent },
    { path: 'project', component: ProjectComponent },
    { path: 'addtask', component: AddTaskComponent },
    { path: 'updatetask/:id', component: AddTaskComponent },
    { path: 'viewtask', component: ViewTaskComponent }  ,
    { path: 'viewtask/:id', component: ViewTaskComponent }  
  ]

@NgModule(
    {
        imports: [
            RouterModule.forRoot(appRoutes),
            ModalModule.forRoot()],
        exports: [RouterModule]
    }
)
export class AppRoutingModule {

}