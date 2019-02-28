import { Project } from "./project.model";
import { Task } from "./task.model";

export interface User{
    userId: number;
    employeeId: string;
    firstName: string;
    lastName: string;   
    
    project?: Project;
    task?: Task;
}