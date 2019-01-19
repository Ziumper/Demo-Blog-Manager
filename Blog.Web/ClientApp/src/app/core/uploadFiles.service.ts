import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ImageModel } from './models/image.model';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UploadFilesService {

    constructor(private http: HttpClient) {
    }

    private imageUploadUrl = 'api/Image/upload';

    postImage(imageToUpload: File): Observable<ImageModel> {
        return this.http.post<ImageModel>(this.imageUploadUrl, imageToUpload);
    }
}
