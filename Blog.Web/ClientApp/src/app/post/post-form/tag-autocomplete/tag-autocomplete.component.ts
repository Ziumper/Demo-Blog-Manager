import { Component, OnInit, Output, OnDestroy } from '@angular/core';
import { TagModel } from 'src/app/tag/models/tag.model';
import { TagService } from 'src/app/tag/tag.service';
import { Subject, Observable, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';


@Component({
    selector: 'app-tag-autocomplete',
    templateUrl: './tag-autocomplete.component.html',
    styleUrls: ['./tag-autocomplete.component.scss']
})
export class TagAutocompleteComponent implements OnInit, OnDestroy {

    public searchTerm: Subject<string>;
    public tagResults: Array<TagModel>;
    public tagSearchQuery: string;
    @Output()
    public selectedTags: Array<TagModel>;
    private search: Subscription;

    constructor(private tagService: TagService) {
        this.tagResults = new Array<TagModel>();
        this.selectedTags = new Array<TagModel>();
        this.tagSearchQuery = '';
        this.searchTerm = new Subject<string>();
    }

    public ngOnInit(): void {
        this.search = this.onSearch(this.searchTerm).subscribe();
    }

    public ngOnDestroy(): void {
        this.search.unsubscribe();
    }

    public addTag(tag: TagModel): void {
        // this.tagService.addTag(tag).subscribe();
        const isThereIsSuchTagInSelectedTagsArray = this.selectedTags.filter( t => t.equal(tag)).length > 0;
        if (isThereIsSuchTagInSelectedTagsArray) {
            return;
        } else {
            this.selectedTags.push(tag);
        }
    }

    private onSearch(searchTerm: Observable<string>): Observable<any> {
        return searchTerm.pipe(
            debounceTime(400),
            distinctUntilChanged(),
            switchMap((query: string) => {
                if (query.length > 0) {
                    this.tagService.getTagsByName(query).subscribe(response => {
                        this.tagResults = response;
                    });
                } else {
                    this.tagResults = new Array<TagModel>();
                }

                return new Observable<any>();
            })
        );
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
