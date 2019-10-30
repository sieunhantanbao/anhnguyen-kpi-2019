import { UserDetail } from '../modules/shared/models/user-detail.model';

export interface IAppState {
    token: string;
    userDetail: UserDetail;
}