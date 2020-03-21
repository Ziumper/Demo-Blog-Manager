import { Component, OnInit } from '@angular/core';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-user-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
    public modal: NgbModalRef;

    constructor(private modalService: NgbModal) { }

    public open(content) {
        this.modal = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
    }

    public closeModal() {
        this.modal.close();
    }

    public ngOnInit(): void {}
}
