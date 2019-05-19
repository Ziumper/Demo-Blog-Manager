import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ImageModel } from '../models/image.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class UploadFilesService {

    constructor(private http: HttpClient) {
    }

    private imageUploadUrl = 'api/Image';

    postImage(form: FormData): Observable<ImageModel> {
        return this.http.post<ImageModel>(this.imageUploadUrl, form);
    }
}
