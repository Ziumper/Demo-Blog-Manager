import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostSearchService } from '../post/post-search/post-search.service';
import { PostService } from '../post/post.service';
import { PostQueryModel } from '../post/models/post-query.model';

@Component({
    selector: 'app-tag',
    templateUrl: './tag.component.html',
    styleUrls: ['./tag.component.scss']
})
export class TagComponent implements OnInit {

    public postQueryModel: PostQueryModel;

    constructor(private tagActivatedRoute: ActivatedRoute,
        private postServiceTag: PostService) {
            this.postQueryModel = new PostQueryModel();
    }

    public ngOnInit(): void {
    }


}
