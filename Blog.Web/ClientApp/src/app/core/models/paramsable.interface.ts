import { HttpParams } from '@angular/common/http';

export interface Paramsable {
    getParams(): HttpParams;
}
