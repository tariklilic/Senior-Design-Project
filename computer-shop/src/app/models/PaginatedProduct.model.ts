import { Product } from "./Product.model";

export class PaginatedProduct {
    public products: Product[];
    public currentPage: number;
    public pages: number;

    constructor(products: Product[], currentPage: number, pages: number) {
        this.products = products;
        this.currentPage = currentPage;
        this.pages = pages;
    }
}