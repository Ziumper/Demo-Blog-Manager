export class ResponseModel{
    public url: string;
    public response: any;

    constructor(url: string, response: any){
        this.url = url;
        this.response = response;
    }

}