export class BasePagedModel<T> {
    public entites: Array<T>;
    public page: number;
    public count: number;
    public size: number;
}
