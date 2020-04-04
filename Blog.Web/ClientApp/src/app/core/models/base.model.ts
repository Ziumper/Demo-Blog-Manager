import { Deserializable } from 'src/app/shared/interfaces/deserialization.model';

export class BaseModel implements Deserializable  {
    public id: number;
    public creationDate: Date;
    public modificationDate: Date;

    deserialize(input: any) {
        Object.assign(this, input);
        return this;
    }
}
