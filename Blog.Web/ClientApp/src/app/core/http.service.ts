import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { LoggerService } from './logger.service';
import { ResponseModel } from './models/ResponsModel';
import { LoaderService } from './loader/loader.service';

@Injectable()
export class HttpService  {

    constructor(private http: HttpClient,private log: LoggerService,private loaderService: LoaderService){
        
    }


    public get<T>(url: string): Observable<T>{
        //this.loaderService.activateLoading();

        let result =  this.http.get<T>(url);
        
        result.subscribe( response => {
            this.log.info(new ResponseModel('get',url,response));
        },error =>{
            this.log.error(error);
        },()=>{
            this.loaderService.deactivateLoading();
        });

        
        let newObserwer = new Observable<T>(result.subscribe);
        return newObserwer;
    }

    public post<T>(url: string,body: any): Observable<T>{
        this.loaderService.activateLoading();

        let result = this.http.post<T>(url,body);

        result.subscribe(response  => {
            this.log.info(new ResponseModel('post',url,response));
        }, error => {
            this.log.error(error)        
        },() => {
            this.loaderService.deactivateLoading();
        })

        return result;
    }

    public put<T>(url: string, body: any): Observable<T> {

        this.loaderService.activateLoading();

        let result = this.http.put<T>(url,body);

        result.subscribe(response => {
            this.log.info(new ResponseModel('put',url,response));
        },error => {
            this.log.error(error);
        },() => {
            this.loaderService.deactivateLoading();
        })

        return result;
    }

    public delete<T>(url: string): Observable<T>{

        this.loaderService.activateLoading();

        let result = this.http.delete<T>(url);
        
        result.subscribe( response => {
            this.log.info(new ResponseModel('delete',url,response));
        },error => {
            this.log.error(error);
        },()=>{
            this.loaderService.deactivateLoading()
        })

        return result;
    }

  
}