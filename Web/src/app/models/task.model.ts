import { Project } from "./project.model";

export interface Task {
    taskId: number;
    taskName: string;
    priority: number;
    startDate?: Date;
    endDate?: Date;
    isParentTask: boolean;    
    isCompleted: boolean;
    
    parentId?: number;
    parentTask: Task;
    projectId: number;
    project: Project;
}
