import { Component, OnInit } from '@angular/core';
import { TagModel } from '../models/tag.model';
import { TagService } from '../tag.service';

@Component({
    selector: 'app-tags-list',
    templateUrl: './tags-list.component.html',
    styleUrls: ['./tags-list.component.scss']
})
export class TagsListComponent implements OnInit {
    public tags: Array<TagModel>;

    constructor(private tagService: TagService) {
        this.tags = new Array<TagModel>();
    }

    public ngOnInit(): void {
        this.tagService.getAllTags().subscribe(response => {
            this.tags = response;
        });
     }
}


