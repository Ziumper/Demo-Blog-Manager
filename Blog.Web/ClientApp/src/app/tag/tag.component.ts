import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostQueryModel } from 'src/app/post/models/post-query.model';

@Component({
    selector: 'app-tag',
    templateUrl: './tag.component.html',
    styleUrls: ['./tag.component.scss']
})
export class TagComponent implements OnInit {

    public postQuery: PostQueryModel;

    constructor(private route: ActivatedRoute) {
        this.initializePostQueryModel();
    }

    public ngOnInit(): void {

    }

    private initializePostQueryModel(): void {
        const tagId = this.route.snapshot.params['id'];
        this.postQuery = new PostQueryModel(1, 10, 1, true, '', [tagId], 0);
    }
}
