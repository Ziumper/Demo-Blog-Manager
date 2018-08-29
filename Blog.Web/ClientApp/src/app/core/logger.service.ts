import { Injectable } from '@angular/core';


@Injectable()
export class LoggerService {

    public info(message : any): void{
        console.info(message);
    }

    public error(message: any): void {
        console.error(message);
    }

    

}