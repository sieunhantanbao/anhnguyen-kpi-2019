import { Claim } from './claim.model';

export class UserDetail {
    userName: string;
    email : string;
    fullName: string;
    claims: Claim[];
}