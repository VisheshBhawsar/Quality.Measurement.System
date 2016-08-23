"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var app_service_todolist_1 = require('../../services/app.service.todolist');
var TodoListComponent = (function () {
    function TodoListComponent(_appService) {
        this._appService = _appService;
        this.showendedtask = true;
    }
    Object.defineProperty(TodoListComponent.prototype, "todolist", {
        get: function () {
            return this._appService.todolist;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TodoListComponent.prototype, "SelectedList", {
        get: function () {
            return this._appService.SelectedList;
        },
        set: function (value) {
            this._appService.SelectedList = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TodoListComponent.prototype, "selectedtasks", {
        get: function () {
            var _this = this;
            if (this.SelectedList && this.SelectedList.Tasks) {
                return this.SelectedList.Tasks.filter(function (f) { return !f.Ended && !_this.showendedtask || _this.showendedtask; });
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TodoListComponent.prototype, "haserror", {
        get: function () {
            return this._appService.haserror;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TodoListComponent.prototype, "errormsg", {
        get: function () {
            return this._appService.errormsg;
        },
        enumerable: true,
        configurable: true
    });
    TodoListComponent.prototype.hideerror = function () {
        this._appService.errormsg = null;
    };
    TodoListComponent.prototype.checktask = function (task) {
        task.Ended = !task.Ended;
        this._appService.UpdateTask(task);
    };
    TodoListComponent.prototype.addlist = function (item) {
        if (item.valid) {
            this._appService.AddList({
                Id: 0,
                Name: this.newlist,
            });
            this.newlist = "";
        }
    };
    TodoListComponent.prototype.removelist = function (list) {
        if (confirm("Are you sure to remove selected list ?")) {
            this._appService.DeleteList(list);
            this.SelectedList = null;
        }
    };
    TodoListComponent.prototype.addtask = function (item) {
        if (item.valid) {
            this._appService.AddTask({
                Id: 0,
                Name: this.newtask,
                Ended: false,
                ListId: this.SelectedList.Id
            });
            this.newtask = "";
        }
    };
    TodoListComponent.prototype.removetask = function (task) {
        //if (confirm("Are you sure to remove selected task ?")) {
        this._appService.DeleteTask(task);
        //}
    };
    TodoListComponent = __decorate([
        core_1.Component({
            selector: 'todolist',
            templateUrl: './app/components/todolist/todolist.component.html',
            styleUrls: ['./app/components/todolist/todolist.component.css']
        }), 
        __metadata('design:paramtypes', [app_service_todolist_1.AppServiceTodoList])
    ], TodoListComponent);
    return TodoListComponent;
}());
exports.TodoListComponent = TodoListComponent;
//# sourceMappingURL=todolist.component.js.map