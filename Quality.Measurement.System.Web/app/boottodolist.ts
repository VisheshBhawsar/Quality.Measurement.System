import {enableProdMode} from '@angular/core';
import {bootstrap}    from '@angular/platform-browser-dynamic'
import {HTTP_PROVIDERS} from '@angular/http';
import {UserComponent} from './components/todolist/user.component';
import {UserService} from './services/app.service.user';
import {AppServiceTodoList} from './services/app.service.todolist';
import {TodoListComponent} from './components/todolist/todolist.component';


//enableProdMode();
bootstrap(TodoListComponent, [HTTP_PROVIDERS, AppServiceTodoList]); 
bootstrap(UserComponent, [HTTP_PROVIDERS, UserService]); 