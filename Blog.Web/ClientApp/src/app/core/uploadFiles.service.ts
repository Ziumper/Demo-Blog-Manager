import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ImageModel } from './models/image.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class UploadFilesService {

    constructor(private http: HttpClient) {
    }

    private imageUploadUrl = 'api/Image';

    postImage(imageToUpload: File): Observable<ImageModel> {
        const headers = new HttpHeaders().set('Content-Type', 'multipart/form-data');
        return this.http.post<ImageModel>(this.imageUploadUrl, imageToUpload, {headers: headers});
    }
}
