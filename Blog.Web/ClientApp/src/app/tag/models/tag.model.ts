export class TagModel {
    public id: number;
    public name: string;

    public equal(tag: TagModel): boolean {
        if (tag.id !== this.id) {
            return false;
        }
        if (tag.name !== this.name) {
            return false;
        }
        return true;
    }
}
