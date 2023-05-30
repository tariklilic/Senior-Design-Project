import { Product } from "./Product.model";

export class CartItem {
    public id: number;
    public product: Product;
    public quantity: number;

    constructor(id: number, product: Product, quantity: number) {
        this.id = id;
        this.product = product;
        this.quantity = quantity;
    }
}