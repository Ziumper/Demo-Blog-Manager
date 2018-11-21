import { Component, OnInit } from '@angular/core';
import { BaseQueryModel } from '../core/models/base-query.model';

@Component({
    selector: 'app-category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

    public blogQuery: BaseQueryModel;

    constructor() { }

    public ngOnInit(): void { }
}
