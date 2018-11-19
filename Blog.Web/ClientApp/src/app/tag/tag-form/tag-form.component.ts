import { Component, OnInit } from '@angular/core';
import { TagModel } from '../models/tag.model';
import { ActivatedRoute } from '@angular/router';
import { TagService } from '../tag.service';

@Component({
    selector: 'app-tag-form',
    templateUrl: './tag-form.component.html',
    styleUrls: ['./tag-form.component.scss']
})
export class TagFormComponent implements OnInit {

    public model: TagModel;

    constructor(private route: ActivatedRoute, private tagService: TagService) { }

    ngOnInit(): void { }
}
