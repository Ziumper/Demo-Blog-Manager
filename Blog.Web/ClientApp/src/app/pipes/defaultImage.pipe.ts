import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'defaultImage'})
export class DefaultImagePipe implements PipeTransform {
    transform(value: any): string {
        const defaultImageSrc = 'defaultImage.png';
        if (value == null) {
            return defaultImageSrc;
        }
        if (value.length <= 0) {
            return defaultImageSrc;
        }

        return value;
    }
}
