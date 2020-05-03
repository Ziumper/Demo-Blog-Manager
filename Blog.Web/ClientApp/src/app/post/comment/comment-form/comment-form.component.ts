import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { CommentService } from '../comment.service';
import { CommentModel } from '../models/comment.model';
import { ActivatedRoute } from '@angular/router';
import { AlertService } from 'src/app/core/services/alert.service';

@Component({
  selector: 'app-comment-form',
  templateUrl: './comment-form.component.html',
  styleUrls: ['./comment-form.component.scss']
})
export class CommentFormComponent implements OnInit {

  public comment: CommentModel;

  @Output()
  public submited: EventEmitter<boolean>;

  @Input()
  public isEdit: boolean;

  @Input()
  public commentModel: CommentModel;

  constructor(private commentService: CommentService, private route: ActivatedRoute,
    private alertService: AlertService) {
        this.submited = new EventEmitter<boolean> ();
    }

  public ngOnInit(): void {
    if (this.isEdit && this.commentModel) {
      this.comment = this.commentModel;
    } else {
      this.comment = new CommentModel();
    }

    this.comment.postId = this.route.snapshot.params['id'];
  }

  public submit(): void {
    if(this.isEdit) {

    } else {
      this.commentService.addComment(this.comment).subscribe(response => {
        this.alertService.success('Comment succesfully added');
        this.submited.emit(true);
        this.commentService.emitCommentForm();
        this.comment = new CommentModel();
      });
    }
  }

}
