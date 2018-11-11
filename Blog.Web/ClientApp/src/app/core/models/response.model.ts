export class ResponseModel {
    public requestType: string;
    public url: string;
    public response: any;

    constructor(requestType: string, url: string, response: any) {
        this.requestType = requestType;
        this.url = url;
        this.response = response;
    }

}
