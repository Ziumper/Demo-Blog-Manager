import { Component, OnInit } from '@angular/core';
import { PostListConfig } from '../core/config/post-list.config';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-tag',
    templateUrl: './tag.component.html',
    styleUrls: ['./tag.component.scss']
})
export class TagComponent {

    constructor(private route: ActivatedRoute) {
    }


}
