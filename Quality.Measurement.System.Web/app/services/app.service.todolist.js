"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
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
var http_1 = require('@angular/http');
var HttpHelpers_1 = require('../utils/HttpHelpers');
require('rxjs/Rx');
var AppServiceTodoList = (function (_super) {
    __extends(AppServiceTodoList, _super);
    function AppServiceTodoList(http) {
        var _this = this;
        _super.call(this, http);
        this.http = http;
        this._getTodoListUrl = 'Home/GetTodoList';
        this._getListAddUrl = 'Home/AddList';
        this._getListUpdateUrl = 'Home/UpdateList';
        this._getListDeleteUrl = 'Home/DeleteList';
        this._getTaskAddUrl = 'Home/AddTask';
        this._getTaskUpdateUrl = 'Home/UpdateTask';
        this._getTaskDeleteUrl = 'Home/DeleteTask';
        this.getaction(this._getTodoListUrl).subscribe(function (result) {
            _this._todolist = result;
            if (_this._todolist.length > 0) {
                _this.SelectedList = _this._todolist[0];
            }
        }, function (error) { return _this.errormsg = error; });
    }
    Object.defineProperty(AppServiceTodoList.prototype, "todolist", {
        get: function () {
            if (this._todolist) {
                this._todolist.map(function (m) {
                    if (m.Tasks) {
                        m.Count = m.Tasks.length;
                        m.CountEnded = m.Tasks.filter(function (f) { return f.Ended; }).length;
                    }
                });
            }
            return this._todolist;
        },
        enumerable: true,
        configurable: true
    });
    AppServiceTodoList.prototype.AddList = function (list) {
        var _this = this;
        this.postaction(list, this._getListAddUrl).subscribe(function (result) {
            if (!result.haserror) {
                result.element.Tasks = new Array();
                _this._todolist.push(result.element);
            }
        }, function (error) { return _this.errormsg = error; });
    };
    AppServiceTodoList.prototype.UpdateList = function (list) {
        var _this = this;
        this.postaction(list, this._getListUpdateUrl).subscribe(function (result) { return result; }, function (error) { return _this.errormsg = error; });
    };
    AppServiceTodoList.prototype.DeleteList = function (list) {
        var _this = this;
        this.postaction(list, this._getListDeleteUrl).subscribe(function (result) {
            if (!result.haserror) {
                var index = _this._todolist.indexOf(list, 0);
                if (index > -1) {
                    _this._todolist.splice(index, 1);
                }
            }
        }, function (error) { return _this.errormsg = error; });
    };
    AppServiceTodoList.prototype.AddTask = function (task) {
        var _this = this;
        this.postaction(task, this._getTaskAddUrl).subscribe(function (result) {
            if (!result.haserror) {
                _this.SelectedList.Tasks.push(result.element);
            }
        }, function (error) { return _this.errormsg = error; });
    };
    AppServiceTodoList.prototype.UpdateTask = function (task) {
        var _this = this;
        this.postaction(task, this._getTaskUpdateUrl).subscribe(function (result) { return result; }, function (error) { return _this.errormsg = error; });
    };
    AppServiceTodoList.prototype.DeleteTask = function (task) {
        var _this = this;
        this.postaction(task, this._getTaskDeleteUrl).subscribe(function (result) {
            if (!result.haserror) {
                var index = _this.SelectedList.Tasks.indexOf(task, 0);
                if (index > -1) {
                    _this.SelectedList.Tasks.splice(index, 1);
                }
            }
        }, function (error) { return _this.errormsg = error; });
    };
    AppServiceTodoList = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], AppServiceTodoList);
    return AppServiceTodoList;
}(HttpHelpers_1.HttpHelpers));
exports.AppServiceTodoList = AppServiceTodoList;
//# sourceMappingURL=app.service.todolist.js.map