import { Injectable } from '@angular/core';


@Injectable()
export class LoggerService {

    public info(message: any): void {
        // tslint:disable-next-line:no-console
        console.info(message);
    }

    public error(message: any): void {
        console.error(message);
    }


}
