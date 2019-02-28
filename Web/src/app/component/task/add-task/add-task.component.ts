import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { TaskService } from '../../../services/task.service';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalService } from 'ngx-bootstrap';
import { switchMap } from 'rxjs/operators';
import * as moment from 'moment';
import { DateValidators } from '../../../shared/date-validators/date-compare.validator';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {
  taskForm;
  submitted = false;
  isUpdate = false;
  bsModalRef;

  get projectId() {
    return this.taskForm.get('projectId').value
  }

  constructor(private fb: FormBuilder,
    private taskService: TaskService,
    private router: Router,
    private route: ActivatedRoute,
    private modalService: BsModalService) {
  }

  ngOnInit() {
    this.taskForm = this.fb.group({
      taskId: 0,
      projectId: [null, Validators.required],
      projectName: null,
      taskName: [null, Validators.required],
      priority: [0],
      isParentTask: false,
      parentId: null,
      parentTaskName: null,
      startDate: null,
      endDate: null,
      userId: null,
      userName: null
    }, {
        validator: Validators.compose([
          DateValidators.dateLessThan('startDate', 'endDate', { 'startDate': true })])
      });

    if (this.route.snapshot.params['id'] != null) {
      this.isUpdate = true;
      this.route.params
        .pipe(switchMap(params =>
          this.taskService.getById(params["id"])
        ))
        .subscribe(task => this.patchTaskForm(task));
    }
  }

  patchTaskForm(task) {
    this.taskForm.patchValue({
      ...task,
      startDate: task.startDate != null ? moment(task.startDate).format("YYYY-MM-DD") : null,
      endDate: task.endDate != null ? moment(task.endDate).format("YYYY-MM-DD") : null,
      projectId: task.project != null ? task.project.projectId : null,
      projectName: task.project != null ? task.project.projectName : null,
      userId: task.user != null ? task.user.userId : null,
      userName: task.user != null ? task.user.firstName : null,
      parentTaskName: task.parent != null ? task.parent.taskName : null
    });
  }

  addTask() {
    console.log(this.taskForm.value);
    this.submitted = true;
    if (this.taskForm.invalid) {
      return;
    }

    if (!this.isUpdate) {
      this.taskService.create(this.taskForm.value)
        .subscribe(() => {
          alert("Task successfully created");
          this.router.navigate(["/viewtask", this.projectId]);
        });
    }
    else {
      this.taskService.update(this.taskForm.value)
        .subscribe(() => {
          alert("Task successfully updated");
          this.router.navigate(["/viewtask", this.projectId]);
        });
    }
  }

  disableTaskFields(isChecked) {
    if (!isChecked) {
      this.taskForm.controls["priority"].enable();
      this.taskForm.controls["startDate"].enable();
      this.taskForm.controls["endDate"].enable();
    }
    else {
      this.taskForm.patchValue({
        userId: null, userName: null,
        parentId: null, parentTaskName: null
      });
      this.taskForm.controls["priority"].enable();
      this.taskForm.controls["startDate"].enable();
      this.taskForm.controls["endDate"].enable();
    }
  }

  resetForm() {
    this.submitted = false;
  }

  viewTaskForm() {
    this.router.navigate(["/viewtask", this.projectId]);
  }

  openModal(template: TemplateRef<any>) {
    this.bsModalRef = this.modalService.show(template);
  }

  updateUserSelected(lookup) {
    this.closeModal();
    this.taskForm.patchValue({ userId: lookup.id, userName: lookup.value });
  }

  updateParentTaskSelected(lookup) {
    this.closeModal();
    this.taskForm.patchValue({ parentId: lookup.id, parentTaskName: lookup.value });
  }

  updateProjectSelected(lookup) {
    this.closeModal();
    this.taskForm.patchValue({ projectId: lookup.id, projectName: lookup.value });
  }

  closeModal() {
    this.bsModalRef.hide();
  }
}
