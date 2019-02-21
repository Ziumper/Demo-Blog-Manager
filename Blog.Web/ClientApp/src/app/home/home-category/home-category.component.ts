import { Component, OnInit, Input } from '@angular/core';
import { CategoryWithPostModel } from 'src/app/category/models/categoryWithPosts.model';
import { CategoryService } from 'src/app/category/category.service';
import { LocationService } from 'src/app/core/location.service';

@Component({
    selector: 'app-home-category',
    templateUrl: './home-category.component.html',
    styleUrls: ['./home-category.component.scss']
})
export class HomeCategoryComponent implements OnInit {

    public categories: Array<CategoryWithPostModel>;
    public defaultImageUrl: string;

    constructor(private categoryService: CategoryService,
        private locationService: LocationService) {
        this.categories = new Array<CategoryWithPostModel>();
        this.defaultImageUrl = this.locationService.getHostingUrl() + '/images/defaultImage.png';
        console.log(this.defaultImageUrl);
    }

    ngOnInit(): void {
        this.categoryService.getCategoriesWithPosts(4).subscribe(response => {
            this.categories = response;
          });
    }
}
