import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { CommentService } from '../comment.service';
import { CommentModel } from '../models/comment.model';
import { ActivatedRoute } from '@angular/router';
import { AlertService } from 'src/app/core/services/alert.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

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

  @Output()
  public editEnd: EventEmitter<boolean>;
  @Output()
  public edited: EventEmitter<CommentModel>;

  constructor(private commentService: CommentService, private route: ActivatedRoute,
    private alertService: AlertService) {
        this.submited = new EventEmitter<boolean> ();
        this.editEnd = new EventEmitter<boolean> ();
        this.edited = new EventEmitter<CommentModel> ();
    }

  public ngOnInit(): void {
    if (this.isEdit && this.commentModel) {
      this.comment = this.commentModel;
    } else {
      this.comment = new CommentModel();
    }

    this.setPostIdToCommentId();
  }

  public submit(): void {
    if (this.isEdit) {
      this.commentService.editComments(this.commentModel).subscribe(response => {
        this.alertService.success('Comment succesfully edited');
        this.edited.next(response);
        this.close();
      });
    } else {
      this.commentService.addComment(this.comment).subscribe(response => {
        this.alertService.success('Comment succesfully added');
        this.submited.emit(true);
        this.commentService.emitCommentForm();
        this.comment.content = '';
      });
    }
  }

  public close(): void {
    this.editEnd.next(true);
  }


  private setPostIdToCommentId(): void {
    this.comment.postId = this.route.snapshot.params['id'];
  }

}
