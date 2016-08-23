
 
 

 

/// <reference path="Enums.ts" />

declare module Models {
	interface List {
		Count: number;
		CountEnded: number;
		Id: number;
		Name: string;
		Tasks: Models.Task[];
	}
	interface Task {
		Ended: boolean;
		Id: number;
		ListId: number;
		Name: string;
	}
}
declare module Models.ViewModel {
	interface JSONReturnVM<T> {
		element: T;
		errormessage: string;
		haserror: boolean;
	}
}


