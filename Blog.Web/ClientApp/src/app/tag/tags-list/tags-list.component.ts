import { Component, OnInit } from '@angular/core';
import { Tag } from '../models/tag.model';

@Component({
    selector: 'app-tags-list',
    templateUrl: './tags-list.component.html',
    styleUrls: ['./tags-list.component.scss']
})
export class TagsListComponent implements OnInit {
    public tags: Array<Tag>;

    constructor() {
        this.tags = new Array<Tag>();
    }

    public ngOnInit(): void { }
}


