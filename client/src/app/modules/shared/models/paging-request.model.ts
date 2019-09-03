export class PagingRequestModel{
    constructor(private _pageIndex, private _pageSize) {
        this.pageIndex = _pageIndex;
        this.pageSize =_pageSize;
    }
    public pageIndex;
    public pageSize;
}