import { Component, OnInit } from '@angular/core';
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

  constructor(private commentService: CommentService, private route: ActivatedRoute,
    private alertService: AlertService) {}

  public ngOnInit(): void {
    this.comment = new CommentModel();
    this.comment.postId = this.route.snapshot.params['id'];
  }

  public submit(): void {
    this.commentService.addComment(this.comment).subscribe(response => {
        this.alertService.success('Comment succesfully added');
    });
  }

}
