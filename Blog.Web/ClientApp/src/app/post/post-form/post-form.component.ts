import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { PostModel } from '../models/post.model';

@Component({
    selector: 'app-post-form',
    templateUrl: './post-form.component.html',
    styleUrls: ['./post-form.component.scss']
})
export class PostFormComponent implements OnInit {
    @Input()
    public model: PostModel;
    @Output()
    public submited: EventEmitter<PostModel>;

    constructor() {
        this.model = new PostModel();
        this.submited = new EventEmitter<PostModel>();
     }

    public ngOnInit(): void { }

    public submit(model: PostModel): void {
        this.submited.emit(model);
    }
}
