import { Injectable } from '@angular/core';

@Injectable()
export class LocationService {

    public getHostingUrl(): string {
        const url = window.location.protocol + '//' + window.location.hostname + ':' + window.location.port;
        return url;
    }
}
