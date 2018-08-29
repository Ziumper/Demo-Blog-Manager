import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { LoggerService } from './logger.service';
import { ResponseModel } from './models/ResponsModel';

@Injectable()
export class HttpService  {

    private isLoading: BehaviorSubject<boolean>;

    constructor(private http: HttpClient,private log: LoggerService){
        this.isLoading = new BehaviorSubject<boolean>(false);
    }

    public getLoader(): Observable<boolean>{
        return this.isLoading.asObservable();
    }

    public get<T>(url: string): Observable<T>{
        this.isLoading.next(true);

        let result =  this.http.get<T>(url);
        
        result.subscribe( response => {
            this.log.info(new ResponseModel('get',url,response));
        },error =>{
            this.log.error(error);
        },()=>{
            this.isLoading.next(false);
        });

        return result;
    }

    public post<T>(url: string,body: any): Observable<T>{
        this.isLoading.next(true);

        let result = this.http.post<T>(url,body);

        result.subscribe(response  => {
            this.log.info(new ResponseModel('post',url,response));
        }, error => {
            this.log.error(error)        
        },() => {
            this.isLoading.next(false);
        })

        return result;
    }

    public put<T>(url: string, body: any): Observable<T> {
        let result = this.http.put<T>(url,body);

        result.subscribe(response => {
            this.log.info(new ResponseModel('put',url,response));
        },error => {
            this.log.error(error);
        },() => {
            this.isLoading.next(false);
        })

        return result;
    }

    public delete<T>(url: string): Observable<T>{
        let result = this.http.delete<T>(url);
        
        result.subscribe( response => {
            this.log.info(new ResponseModel('delete',url,response));
        },error => {
            this.log.error(error);
        },()=>{
            this.isLoading.next(false);
        })

        return result;
    }

  
}