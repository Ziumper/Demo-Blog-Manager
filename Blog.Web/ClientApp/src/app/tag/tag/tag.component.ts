import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseQueryModel } from 'src/app/core/models/base-query.model';

@Component({
    selector: 'app-tag',
    templateUrl: './tag.component.html',
    styleUrls: ['./tag.component.scss']
})
export class TagComponent implements OnInit {

    public postQuery: BaseQueryModel;

    constructor(private route: ActivatedRoute) {
        this.postQuery = new BaseQueryModel(1, 10, 1, true, '');
    }

    public ngOnInit(): void {

     }
}
