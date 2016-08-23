import {Component} from '@angular/core';
import {UserService} from '../../services/app.service.user';


@Component({
    selector: 'user',
    template: '<h1>Hey Hello</h1>'
    
})

export class UserComponent
{
    title = "Hey Hello user !!!";
    user;
    constructor() {
        new UserService();
    }
}