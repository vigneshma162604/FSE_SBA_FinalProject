import { Task } from "./task.model";
import { User } from "./user.model";

export interface Project {
    projectId: number;
    projectName: string;
    priority: number;
    startDate: Date;
    endDate: Date;    

    manager: User;
    tasks: Task[];
    tasksCompleted: number;
}