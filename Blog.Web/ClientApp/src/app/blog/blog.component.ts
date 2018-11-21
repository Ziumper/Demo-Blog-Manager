import { Component, OnInit } from '@angular/core';
import { BlogModel } from './models/blog.model';
import { BlogService } from './blog.service';
import { ActivatedRoute } from '@angular/router';
import { CategoryModel } from '../category/models/category.model';
import { PostQueryModel } from '../post/models/post-query.model';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent implements OnInit {

  public blog: BlogModel;
  public postQueryModel: PostQueryModel;

  constructor(private blogService: BlogService, private route: ActivatedRoute) {
    this.blog = new BlogModel(0, '', new Date(), new Date(), new CategoryModel(0, ''));
    const blogId = this.route.snapshot.params['blogId'];
    const tagId = this.route.snapshot.params['tagId'];

    if (tagId) {
      this.postQueryModel = new PostQueryModel(1, 10, 1, true, '', tagId, blogId);
    } else {
      this.postQueryModel = new PostQueryModel(1, 10, 1, true, '', 0, blogId);
    }

  }

  public ngOnInit(): void {
    const id = this.route.snapshot.params['blogId'];
    if (id) {
      this.blogService.getBlogById(id).subscribe(response => {
        this.blog = response;
      });
    }
  }







}
