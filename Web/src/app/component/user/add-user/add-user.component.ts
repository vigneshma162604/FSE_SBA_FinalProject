import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { UserService } from '../../../services/user.service';
import { IfStmt } from '@angular/compiler';

@Component({
    selector: 'app-add-user',
    templateUrl: './add-user.component.html',
    styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
    userForm;
    isUpdate = false;
    submitted = false;

    @Output()
    userSubmit = new EventEmitter();

    @Input()
    set user(user) {
        if (user != null) {
            this.isUpdate = true;
            this.userForm.patchValue(user);
        }
    }

    get firstName() {
        return this.userForm.get("firstName");
    }

    get lastName() {
        return this.userForm.get("lastName");
    }

    get employeeId() {
        return this.userForm.get("employeeId");
    }

    constructor(private fb: FormBuilder,
        private userService: UserService) {
    }

    ngOnInit() {
        this.userForm = this.fb.group({
            userId: 0,
            employeeId: [null, Validators.required],
            firstName: [null, Validators.required],
            lastName: [null, Validators.required]            
        });
    }

    submitUser() {
        this.submitted = true;

        if (this.userForm.invalid) {
            return;
        }

        if (!this.isUpdate) {
            this.userService.create(this.userForm.value)
                .subscribe(() => {
                    this.resetForm();
                    this.userSubmit.emit();
                    alert("User successfully created");
                });
        }
        else {
            this.userService.update(this.userForm.value)
                .subscribe(() => {
                    this.resetForm();
                    this.userSubmit.emit();
                    this.isUpdate = false;
                    alert("User successfully updated");
                });
        }
    }

    cancelEdit() {
        this.isUpdate = false;
        this.resetForm();
    }

    resetForm() {
        this.submitted = false;
        this.userForm.reset({ id: 0 });
    }
}
