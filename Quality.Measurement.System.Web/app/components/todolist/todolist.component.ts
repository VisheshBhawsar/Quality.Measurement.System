import {Component} from '@angular/core';
import {NgControl} from '@angular/common';
import {AppServiceTodoList} from '../../services/app.service.todolist';

@Component({
    selector: 'todolist',
    templateUrl: './app/components/todolist/todolist.component.html',
    styleUrls: ['./app/components/todolist/todolist.component.css']
})
export class TodoListComponent {
    constructor(private _appService: AppServiceTodoList) {
    }

    get todolist(): Models.List[] {
        return this._appService.todolist;
    }

    get SelectedList(): Models.List {
        return this._appService.SelectedList;
    }

    set SelectedList(value: Models.List) {
        this._appService.SelectedList = value;
    }

    get selectedtasks(): Models.Task[] {
        if (this.SelectedList && this.SelectedList.Tasks) {
            return this.SelectedList.Tasks.filter(f => !f.Ended && !this.showendedtask || this.showendedtask);
        }
    }

    newtask: string;
    newlist: string;
    showendedtask: boolean = true;

    get haserror() {
        return this._appService.haserror;
    }

    get errormsg() {
        return this._appService.errormsg;
    }

    hideerror() {
        this._appService.errormsg = null;
    }

    checktask(task: Models.Task) {
        task.Ended = !task.Ended;

        this._appService.UpdateTask(task);
    }

    addlist(item: NgControl) {
        if (item.valid) {
            this._appService.AddList(<Models.List>{
                Id: 0,
                Name: this.newlist,
            });

            this.newlist = "";
        }
    }

    removelist(list: Models.List) {
        if (confirm("Are you sure to remove selected list ?")) {
            this._appService.DeleteList(list);
            this.SelectedList = null;
        }
    }

    addtask(item: NgControl) {
        if (item.valid) {
            this._appService.AddTask({
                Id: 0,
                Name: this.newtask,
                Ended: false,
                ListId: this.SelectedList.Id
            });

            this.newtask = "";
        }
    }

    removetask(task: Models.Task) {
        //if (confirm("Are you sure to remove selected task ?")) {
        this._appService.DeleteTask(task);
        //}
    }
}