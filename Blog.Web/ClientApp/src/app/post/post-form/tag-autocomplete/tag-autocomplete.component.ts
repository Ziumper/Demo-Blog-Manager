import { Component, OnInit, Output } from '@angular/core';
import { TagModel } from 'src/app/tag/models/tag.model';
import { TagService } from 'src/app/tag/tag.service';


@Component({
    selector: 'app-tag-autocomplete',
    templateUrl: './tag-autocomplete.component.html',
    styleUrls: ['./tag-autocomplete.component.scss']
})
export class TagAutocompleteComponent implements OnInit {

    public tagResults: Array<TagModel>;
    public tagSearchQuery: string;
    @Output()
    public selectedTags: Array<TagModel>;

    constructor(private tagService: TagService) {
        this.tagResults = new Array<TagModel>();
        this.selectedTags = new Array<TagModel>();
        this.tagSearchQuery = '';
    }

    public ngOnInit(): void { }

    public addTag(tag: TagModel): void {
        // this.tagService.addTag(tag).subscribe();
        const isThereIsSuchTagInSelectedTagsArray = this.selectedTags.filter( t => t.equal(tag)).length > 0;
        if (isThereIsSuchTagInSelectedTagsArray) {
            return;
        } else {
            this.selectedTags.push(tag);
        }
    }

    public removeTag(tag: TagModel) {
        const newArray = this.selectedTags.filter(element => {
            return element !== tag;
        });
        this.selectedTags = newArray;
    }

    public addNewTag() {
        let newTagModel = new TagModel();
        newTagModel.name = this.tagSearchQuery;

        this.tagService.addTag(newTagModel).subscribe(response => {
            newTagModel = response;
            const isThereIsSuchTagInSelectedTagsArray = this.selectedTags.filter( t => t.equal(newTagModel)).length > 0;
            if (isThereIsSuchTagInSelectedTagsArray) {
                return;
            } else {
                this.selectedTags.push(newTagModel);
            }
        });
    }

}
